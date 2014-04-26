using System;
using System.Collections.Generic;

namespace ZTn.Bnet.Portable
{
    public class PortableInjector
    {
        private static readonly Dictionary<Type, object> Pairs = new Dictionary<Type, object>();

        public static void Register<T>(T instance) where T : class
        {
            Pairs.Add(typeof(T), instance);
        }

        public static T Resolve<T>() where T : class
        {
            object result;
            Pairs.TryGetValue(typeof(T), out result);

            if (result is T)
            {
                return (T)result;
            }

            return null;
        }
    }
}