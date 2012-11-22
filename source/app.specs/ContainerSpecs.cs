 using Machine.Specifications;
 using app.utility.service_locator;
 using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (Container))]
    public class ContainerSpecs
    {
        public abstract class concern : Observes<IFindDependencies,
                                            Container>
        {

        }
        
        public class when_getting_a_dependency_that_was_not_registered : concern
        {
            private Because b = () =>
                                spec.catch_exception(() => sut.an<IFoo>());

            private It should_throw_an_exception_if_dependency_not_registered = () => spec.exception_thrown.ShouldBeOfType<DependencyNotFoundException>();
        }
        
        public class when_getting_a_dependency_that_was_registered_by_instance : concern
        {
            private Because b = () =>
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

        public class when_getting_a_dependency_that_has_dependencies: concern
        {
            private Because b = () =>
                {
                    sut.register_dependency<IFoo>(typeof(Foo));
                    sut.register_dependency<IBar>(typeof(Bar));

                    result = sut.an<IBar>();
                };

            private It should_return_dependency_of_correct_type =
                () => result.ShouldBeOfType<Bar>(); 
            
            private It should_resolve_child_dependency =
                () => result.Dependency.ShouldBeOfType<Foo>();

            private static IBar result;
        }
    }
}
