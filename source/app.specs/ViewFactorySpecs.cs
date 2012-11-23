using System.Web;
using Machine.Specifications;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;

namespace app.specs
{
    [Subject(typeof (ViewFactory))]
    public class ViewFactorySpecs
    {
        public abstract class concern : Observes<ICreateViews, ViewFactory>
        {
        }

        public class when_creating_the_view_for_a_model : concern
        {
            private Establish that = () =>
                {
                    model_to_show = new ADummyModel();
                    expected_view = fake.an<IDisplayA<ADummyModel>>();
                    page = "blah.aspx";

                    view_path_registry = depends.on<IGetThePathToAViewThatCanDisplay>();

                    view_path_registry.setup(x => x.get_the_path_to_the_template_for<ADummyModel>()).Return(page);
                    depends.on<ICreateAspxPageInstances>((path, type) =>
                        {
                            path.ShouldEqual(page);
                            type.ShouldEqual(typeof (IDisplayA<ADummyModel>));
                            return expected_view;
                        });
                };

            private Because of = () =>
                                 result = sut.create_view_that_can_render(model_to_show);

            private It should_return_the_expected_view_handler = () =>
                                                                 result.ShouldBeTheSameAs(expected_view);

            private It should_provide_the_template_with_its_data = () =>
                                                                   expected_view.model.ShouldEqual(model_to_show);


            private static ADummyModel model_to_show;
            private static IHttpHandler result;

            private static IDisplayA<ADummyModel> expected_view;
            private static IGetThePathToAViewThatCanDisplay view_path_registry;
            private static string page;
        }
    }

    public class ADummyModel
    {
    }

    public class ADummyModelView
    {
    }

    public class TheWrongViewType
    {
    }
}