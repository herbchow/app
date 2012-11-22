using System;

namespace app.utility.service_locator
{
    public interface IFindDependencies
    {
        TDependency an<TDependency>();
        void register_dependency_instance<TDependency>(TDependency dependency);
        void register_dependency<TDependency>(Type implementationType);
    }
}