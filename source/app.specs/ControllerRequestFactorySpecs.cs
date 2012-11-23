using System.Web;
using app.specs.utility;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    using Machine.Specifications;

    [Subject(typeof (ControllerRequestFactory))]
    public class ControllerRequestFactorySpecs
    {
        public class concern : Observes<ICreateControllerRequests, ControllerRequestFactory>
        {

        }

        public class when_creating_controller_request_from_raw_http_context : concern
        {
            private Establish context =
                () =>
                    {
                        view_name_parser = depends.on<IGetViewNameFromRequest>();
                        action_name_parser = depends.on<IGetActionNameFromRequest>();
                    };
            private Because of =
                () =>
                    {
                        raw_request = ObjectFactory.web.create_request_with_query_string("?view=departments&action=main");
                        controllerRequest = sut.create_a_controller_request_from(raw_request);
                    };

            private It should_not_be_null =
                () => controllerRequest.ShouldNotBeNull();

            private static IContainRequestDetails controllerRequest;
            private static IGetViewNameFromRequest view_name_parser;
            private static IGetActionNameFromRequest action_name_parser;
            private static HttpContext raw_request;
        }
    }
}
