namespace app.web.core
{
    public class RequestCommand : IProcessOneRequest
    {
        private IMatchARequest request_specification;
        private ISupportAUserFeature feature;

        public RequestCommand(IMatchARequest request_specification, ISupportAUserFeature feature)
        {
            this.request_specification = request_specification;
            this.feature = feature;
        }

        public void run(IContainRequestDetails request)
        {
            feature.run(request);
        }

        public bool can_process(IContainRequestDetails request)
        {
            return request_specification(request);
        }
    }
}