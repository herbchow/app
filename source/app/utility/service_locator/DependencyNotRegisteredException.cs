using System;

namespace app.utility.service_locator
{
    public class DependencyNotRegisteredException : Exception
    {
        public DependencyNotRegisteredException(string message) : base (message)
        {
            
        }
    }
}