using System.IO;
using System.Xml.Serialization;
using app.web.core.aspnet;

namespace app.web.core
{
    public class RequestDetails : IContainRequestDetails
    {
        private readonly IGetTheCurrentlyExecutingRequest _getRequest;

        public RequestDetails(IGetTheCurrentlyExecutingRequest get_request)
        {
            _getRequest = get_request;
        }

        public ModelData map<ModelData>()
        {
            var serialziedModel = _getRequest().Request.Form["Model"];
            var xmlSerializer = new XmlSerializer(typeof (ModelData));
            
            return (ModelData) xmlSerializer.Deserialize(new StringReader(serialziedModel));
        }
    }
}