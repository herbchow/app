using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace app.utility.service_locator
{
    public class Container : IFindDependencies
    {
        private Dictionary<Type, object> instance_registry;
        private Dictionary<Type, Type> type_registry;

        public Container()
        {
            type_registry = new Dictionary<Type, Type>();
            instance_registry = new Dictionary<Type, object>();
        }

        public void register_dependency_instance<TDependency>(TDependency dependency)
        {
            instance_registry.Add(typeof (TDependency), dependency);
        }

        public void register_dependency<TDependency, TImplementationType>()
        {
            type_registry.Add(typeof (TDependency), typeof (TImplementationType));
        }

        public TDependency an<TDependency>()
        {
            return (TDependency) resolve_dependency(typeof (TDependency));
        }

        private object resolve_dependency(Type dependencyType)
        {
            if(instance_registry.ContainsKey(dependencyType))
            {
                return instance_registry[dependencyType];
            }

            if(type_registry.ContainsKey(dependencyType))
            {
                Type implementation_type = type_registry[dependencyType];
                object dependency = create_depency_instance(dependencyType, implementation_type);
                
                instance_registry.Add(dependencyType, dependency);

                return dependency;
            }

            throw new DependencyNotRegisteredException(dependencyType.Name);
        }

        private object create_depency_instance(Type dependencyType, Type implementation_type)
        {
            ConstructorInfo constructor = implementation_type.GetConstructors()[0];
            ParameterInfo[] constructorParameters = constructor.GetParameters();

            if (constructorParameters.Length == 0)
            {
                return Activator.CreateInstance(implementation_type);
            }
            
            var parameters = new List<object>(constructorParameters.Length);
            parameters.AddRange(constructorParameters.Select(parameterInfo => resolve_dependency(parameterInfo.ParameterType)));

            return constructor.Invoke(parameters.ToArray());
        }
    }
}