using System.Web;
using Machine.Specifications;
using app.specs.utility;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    [Subject(typeof(ActionNameParser))]
    public class ActionNameParserSpecs
    {
        public abstract class concern : Observes<IGetActionNameFromRequest, ActionNameParser>
        {
        }

        public class when_attempting_to_parse_the_action_name_in_query_string_when_it_exists : concern
        {
            Establish c = () =>
            {
                raw_request = ObjectFactory.web.create_request_with_query_string("view=departments&action=main");
            };

            Because b = () =>
                result = sut.parse_action_name(raw_request.Request);


            It should_parse_the_action_from_the_request = () =>
                result.ShouldEqual("main");

            static string result;
            static HttpContext raw_request;
        }

        public class when_attempting_to_parse_the_action_name_in_query_string_when_it_does_not_exist : concern
        {
            Establish c = () =>
            {
                raw_request = ObjectFactory.web.create_request_with_query_string("view=departments");
            };

            Because b = () =>
                result = sut.parse_action_name(raw_request.Request);


            It should_return_null = () =>
                result.ShouldBeNull();

            static string result;
            static HttpContext raw_request;
        }
    }
}
