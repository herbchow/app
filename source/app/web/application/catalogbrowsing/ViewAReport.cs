using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public class ViewAReport<PresentationData> : ISupportAUserFeature
    {
        private IDisplayInformation display_engine;
        private IGetPresentationDataFromARequest<PresentationData> query;

        public ViewAReport(IDisplayInformation display_engine, IGetPresentationDataFromARequest<PresentationData> query)
        {
            this.display_engine = display_engine;
            this.query = query;
        }

        public void run(IContainRequestDetails request)
        {
            display_engine.display(query(request));
        }
    }
}