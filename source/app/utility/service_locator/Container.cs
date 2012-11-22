using System;
using System.Collections.Generic;

namespace app.utility.service_locator
{
    public class Container : IFindDependencies
    {
        private Dictionary<Type, object> _registry;

        public Container()
        {
            _registry = new Dictionary<Type, object>();
        }
        
        public TDependency an<TDependency>()
        {
            if (!_registry.ContainsKey(typeof(TDependency)))
                throw new DependencyNotFoundException();

            return (TDependency) _registry[typeof (TDependency)];
        }

        public void register_dependency_instance<TDependency>(TDependency dependency)
        {
            _registry.Add(typeof(TDependency), dependency);
        }
        
        public void register_dependency<TDependency, TImplementationType>()
        {
            _registry.Add(typeof(TDependency), Activator.CreateInstance<TImplementationType>());
        }
    }
}