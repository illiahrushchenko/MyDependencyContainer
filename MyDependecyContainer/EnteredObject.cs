using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDependecyContainer
{
    public class EnteredObject
    {
        public Type Type { get; }

        public bool IsSingleton { get; }

        public object SingletonInstance { get; private set; }

        public EnteredObject(Type type, bool isSingleton = false)
        {
            Type = type;
            IsSingleton = isSingleton;
        }

        public object CreateInstance(params object[] args)
        {
            var instance = Activator.CreateInstance(Type, args);
            if (IsSingleton)
                SingletonInstance = instance;
            return instance;
        }
    }
}
