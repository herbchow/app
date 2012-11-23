using System.Web;
using app.specs.utility;
using app.web.core;
using app.web.core.aspnet;
using developwithpassion.specifications.extensions;
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

        public class when_get_view_name_from_controller_request : concern
        {
            private Establish context =
                () =>
                    {
                        raw_request = ObjectFactory.web.create_request_with_query_string("view=departments&action=main");

                        depends.on<IGetTheCurrentlyExecutingRequest>(() => raw_request);
                        
                        view_name_parser = depends.on<IGetViewNameFromRequest>();
                        action_name_parser = depends.on<IGetActionNameFromRequest>();
                    };

            private Because of =
                () => sut.get_view_name();

            private It should_call_view_parser_to_get_view_name =
                () => view_name_parser.received(x => x.parse_view_name(raw_request.Request));  

            private static IGetViewNameFromRequest view_name_parser;
            private static IGetActionNameFromRequest action_name_parser;
            private static HttpContext raw_request;
        }
        
        public class when_get_action_name_from_controller_request : concern
        {
            private Establish context =
                () =>
                    {
                        raw_request = ObjectFactory.web.create_request_with_query_string("view=departments&action=main");

                        depends.on<IGetTheCurrentlyExecutingRequest>(() => raw_request);
                        
                        view_name_parser = depends.on<IGetViewNameFromRequest>();
                        action_name_parser = depends.on<IGetActionNameFromRequest>();
                    };

            private Because of =
                () => sut.get_action();

            private It should_call_view_parser_to_get_view_name =
                () => action_name_parser.received(x => x.parse_action_name(raw_request.Request));  

            private static IGetViewNameFromRequest view_name_parser;
            private static IGetActionNameFromRequest action_name_parser;
            private static HttpContext raw_request;
        }
    }
}
