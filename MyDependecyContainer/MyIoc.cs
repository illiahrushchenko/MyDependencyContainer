using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDependecyContainer
{
    public class MyIoc
    {
        private readonly List<Type> _registeredTypes = new List<Type>();


        public void Register<T>()
        {
            if (IsRegistered(typeof(T))){
                throw new Exception($"Type {typeof(T)} is already registered.");
            }
            _registeredTypes.Add(typeof(T));
        }

        public T Resolve<T>()
        {
            if (!IsRegistered(typeof(T)))
            {
                throw new Exception($"Type {typeof(T)} is not registered.");
            }
            var parameters = GetParameters(typeof(T));

            return (T)Activator.CreateInstance(typeof(T), parameters);
        }

        private object[] GetParameters(Type type)
        {
            var constructorInfo = type.GetConstructors().Single();
            var parameters = constructorInfo.GetParameters();

            var result = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                result[i] = Activator.CreateInstance(parameters[i].ParameterType,
                    GetParameters(parameters[i].ParameterType));
            }

            return result;
        }

        private bool IsRegistered(Type type)
        {
            return _registeredTypes.Contains(type);
        }
    }
}
