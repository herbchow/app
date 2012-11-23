using app.web.core.aspnet;

namespace app.web.core
{
    public class RequestDetails : IContainRequestDetails
    {
        private readonly IGetTheCurrentlyExecutingRequest get_request;

        public RequestDetails(IGetTheCurrentlyExecutingRequest get_request)
        {
            this.get_request = get_request;
        }

        public string get_view_name()
        {
            return ExtractViewNameFromPath(get_request().Request.Path);
        }

        public string get_action()
        {
            return ExtractActionFromPath(get_request().Request.Path);
        }

        private string ExtractActionFromPath(string path)
        {
            throw new System.NotImplementedException();
        }

        private string ExtractViewNameFromPath(string path)
        {
            throw new System.NotImplementedException();
        }

        public ModelData map<ModelData>()
        {
            return (ModelData) get_request().Items["Model"];
        }
    }
}