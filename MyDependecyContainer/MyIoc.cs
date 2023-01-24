using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDependecyContainer
{
    public class MyIoc
    {
        private readonly List<EnteredObject> _registeredObjects = new List<EnteredObject>();

        public void Register<T>()
        {
            var type = typeof(T);

            if (IsRegistered(type))
            {
                throw new Exception($"Type {type} is already registered.");
            }

            _registeredObjects.Add(new EnteredObject(type));
        }

        public void RegisterSingleton<T>()
        {
            var type = typeof(T);

            if (IsRegistered(type))
            {
                throw new Exception($"Type {type} is already registered.");
            }

            _registeredObjects.Add(new EnteredObject(type, true));
        }

        public T Resolve<T>()
        {
            var type = typeof(T);

            if (!IsRegistered(type))
            {
                throw new Exception($"Type {type} is not registered.");
            }

            return (T)GetInstance(type);
        }

        private EnteredObject GetEnteredObject(Type type)
        {
            var result = _registeredObjects.FirstOrDefault(x => x.Type == type);

            if (result == null)
            {
                throw new Exception($"Type {type} is not registered.");
            }

            return result;
        }

        private object GetInstance(Type type)
        {
            var enteredObject = GetEnteredObject(type);

            var instance = enteredObject.SingletonInstance;
            if (instance != null) return instance;

            var parameters = GetParametersFromConstructor(type);

            return enteredObject.CreateInstance(parameters);
        }

        private object[] GetParametersFromConstructor(Type type)
        {
            var constructorInfo = type.GetConstructors().Single();
            var parameters = constructorInfo.GetParameters();

            var result = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                result[i] = GetInstance(parameters[i].ParameterType);
            }

            return result;
        }

        private bool IsRegistered(Type type)
        {
            return _registeredObjects.Any(x => x.Type == type);
        }
    }
}
