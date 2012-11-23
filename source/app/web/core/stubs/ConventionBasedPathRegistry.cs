using System;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
    public class ConventionBasedPathRegistry : IGetThePathToAViewThatCanDisplay
    {
        public string get_the_path_to_the_template_for<Model>()
        {
            // TODO: convention based logic
            throw new NotImplementedException();
        }
    }
}