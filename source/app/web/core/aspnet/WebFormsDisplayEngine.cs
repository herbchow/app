using System.Web;

namespace app.web.core.aspnet
{
    public class WebFormsDisplayEngine : IDisplayInformation
    {
        private ICreateViews view_factory;
        private IGetTheCurrentlyExecutingRequest current_request_resolution;

        public WebFormsDisplayEngine() : this(new ViewFactory(), () => HttpContext.Current)
        {

        }

        public WebFormsDisplayEngine(ICreateViews view_factory,
                                     IGetTheCurrentlyExecutingRequest current_request_resolution)
        {
            this.view_factory = view_factory;
            this.current_request_resolution = current_request_resolution;
        }

        public void display<PresentationModel>(PresentationModel model)
        {
            view_factory.create_view_that_can_render(model).ProcessRequest(current_request_resolution());
        }
    }
}