using System.Web;
using app.web.core;
using developwithpassion.specifications.rhinomocks;

namespace app.specs
{
    using Machine.Specifications;

    [Subject(typeof (ViewNameParser))]
    public class ViewNameParserSpec
    {
         public abstract class concern : Observes<IGetViewNameFromRequest,ViewNameParser>
         {
             
         }

         public class when_getting_the_command_that_can_run_a_request : concern
         {
             private Establish c = () =>
             {
                 queryValue = "departments";
                 queryString = "view=" + queryValue;
                 httpRequest = new HttpRequest("","http://localhost:8080",queryString);
             };

             private Because b = () =>
                                     {
                                         result = sut.parse_view_name(httpRequest);
                                     };

             It should_return_query_string = () =>
                                           {
                                               result.ShouldEqual(queryValue);
                                           };

             private static HttpRequest httpRequest;
             private static string result;
             private static string queryString;
             private static string queryValue;
         }

    }
}
