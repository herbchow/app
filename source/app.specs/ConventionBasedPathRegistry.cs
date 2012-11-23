using app.web.core.aspnet;
using app.web.core.stubs;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    using Machine.Specifications;

    [Subject(typeof (ConventionBasedPathRegistry))]
    public class ConventionBasedPathRegistrySpecs
    {
        public class concern : Observes<IGetThePathToAViewThatCanDisplay, ConventionBasedPathRegistry>
        {

        }

        public class when_getting_a_path_to_view_that_can_display_model : concern
        {
            private Because of =
                () => page_path = sut.get_the_path_to_the_template_for<ADummyModel>();

            //private It should_get_the_path_using_model_name_based_convention =
            //    () =>
            //        {
            //            page_path.ShouldBe();
            //        };

            private static string page_path;
        }
    }
}
