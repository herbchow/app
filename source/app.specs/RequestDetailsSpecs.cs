using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    using Machine.Specifications;

    [Subject(typeof (RequestDetails))]
    public class RequestDetailsSpecs
    {
        public abstract class concern : Observes<IContainRequestDetails, RequestDetails>
        {

        }
    }
}
