using System;
using System.Collections.Generic;
using app.web.application;
using app.web.application.models;
using app.web.core.aspnet;

namespace app.web.core.stubs
{
    public class StubPathRegistry : IGetThePathToAViewThatCanDisplay
    {
        public string get_the_path_to_the_template_for<Model>()
        {
            var templates = new Dictionary<Type, string>
                {
                    {typeof (IEnumerable<Department>), path_for("DepartmentBrowser")},
                    {typeof (IEnumerable<Product>), path_for("ProductBrowser")}
                };

            return templates[typeof (Model)];
        }

        private string path_for(string page)
        {
            return string.Format("~/views/{0}.aspx", page);
        }
    }
}