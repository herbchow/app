using System.Linq;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
    public class ConventionBasedPathRegistry : IGetThePathToAViewThatCanDisplay
    {
        public string get_the_path_to_the_template_for<Model>()
        {
            var modelType = typeof (Model);

            return string.Format("~/views/{0}Browser.aspx",
                                 !modelType.IsGenericType ? modelType.Name : 
                                 modelType.GetGenericArguments().First().Name);
        }
    }
}