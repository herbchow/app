using app.web.core;

namespace app.web.application.catalogbrowsing
{
    public delegate PresentationData IGetPresentationDataFromARequest<PresentationData>(IContainRequestDetails input);

    public interface IFetchAReport<PresentationData>
    {
        PresentationData fetch_using(IContainRequestDetails request);
    }
}