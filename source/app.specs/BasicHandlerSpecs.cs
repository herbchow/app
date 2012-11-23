using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.utility.service_locator;
using app.web.core;
using app.web.core.aspnet;
using app.web.core.stubs;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof (BasicHandler))]
    public class BasicHandlerSpecs
    {
        public abstract class concern : Observes<IHttpHandler,
                                            BasicHandler>
        {
        }

        public class when_processing_a_new_http_context : concern
        {
            private Establish c = () =>
                {
                    front_controller = depends.on<IProcessRequests>();
                    request_factory = depends.on<ICreateControllerRequests>();
                    a_raw_aspnet_request = ObjectFactory.web.create_request();
                    a_new_controller_request = fake.an<IContainRequestDetails>();

                    request_factory.setup(x => x.create_a_controller_request_from(a_raw_aspnet_request))
                                   .Return(a_new_controller_request);
                };

            private Because b = () =>
                                sut.ProcessRequest(a_raw_aspnet_request);

            private It should_delegate_the_processing_of_a_new_controller_request_to_the_front_controller = () =>
                                                                                                            front_controller
                                                                                                                .received
                                                                                                                (x =>
                                                                                                                 x
                                                                                                                     .process
                                                                                                                     (a_new_controller_request));

            private static IProcessRequests front_controller;
            private static IContainRequestDetails a_new_controller_request;
            private static HttpContext a_raw_aspnet_request;
            private static ICreateControllerRequests request_factory;
        }
    }
}