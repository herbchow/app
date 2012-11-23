using System.Web;
using System.Web.Compilation;
using app.web.core.stubs;

namespace app.web.core.aspnet
{
    public class ViewFactory : ICreateViews
    {
        private ICreateAspxPageInstances page_factory;
        private IGetThePathToAViewThatCanDisplay template_registry;

        public ViewFactory()
            : this((path, type) => BuildManager.CreateInstanceFromVirtualPath(path, type), new StubPathRegistry())
        {
            
        }

        public ViewFactory(ICreateAspxPageInstances page_factory, IGetThePathToAViewThatCanDisplay view_registry)
        {
            this.page_factory = page_factory;
            this.template_registry = view_registry;
        }

        public IHttpHandler create_view_that_can_render<PresentationModel>(PresentationModel data)
        {
            var view =
                (IDisplayA<PresentationModel>)
                page_factory(template_registry.get_the_path_to_the_template_for<PresentationModel>(),
                             typeof (IDisplayA<PresentationModel>));

            view.model = data;

            return view;
        }
    }
}