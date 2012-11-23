 using Machine.Specifications;
 using app.utility.service_locator;
 using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (Container))]
    public class ContainerSpecs
    {
        public abstract class concern : Observes<IFindDependencies, Container>
        {

        }

        public class when_getting_a_dependency_that_was_not_registered : concern
        {
            private Because of = () => spec.catch_exception(() => sut.an<IFoo>());

            private It should_throw_an_exception_if_dependency_not_registered =
                () => spec.exception_thrown.ShouldBeOfType<DependencyNotRegisteredException>();
        }

        public class when_getting_a_dependency_that_was_registered_by_instance : concern
        {
            private Because of = () =>
                {
                    dependency_to_register = new Foo();
                    sut.register_dependency_instance<IFoo>(dependency_to_register);
                    result = sut.an<IFoo>();
                };

            private It should_return_dependency_that_was_registered = () =>
                                                                      result.ShouldEqual(dependency_to_register);

            private static IFoo result;
            private static Foo dependency_to_register;
        }

        public class when_getting_a_dependency_that_has_dependencies : concern
        {
            private Because b = () =>
                {
                    Dependencies.resolution = () => sut;

                    sut.register_dependency<IFoo, Foo>();
                    sut.register_dependency<IBar, Bar>();

                    result = sut.an<IBar>();
                };

            private It should_return_dependency_of_correct_type =
                () => result.ShouldBeOfType<Bar>();

            private It should_resolve_child_dependency =
                () => result.Dependency.ShouldBeOfType<Foo>();

            private static IBar result;
        }
    }

    public interface IFoo
    {
    }

    public class Foo : IFoo
    {

    }

    public interface IBar
    {
        IFoo Dependency { get; }
    }

    public class Bar : IBar
    {
        private readonly IFoo _dependency;

        public Bar(IFoo dependency)
        {
            _dependency = dependency;
        }

        public IFoo Dependency
        {
            get { return _dependency; }
        }
    }
}
