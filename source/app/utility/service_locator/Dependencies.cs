using System;

namespace app.utility.service_locator
{
    public class Dependencies
    {
        public static IResolveTheContainerConfiguredAtStartup resolution = () =>
            {
                throw new NotImplementedException("This needs to be configured by a startup process");
            };

        public static IFindDependencies fetch
        {
            get { return resolution(); }
        }
    }
}