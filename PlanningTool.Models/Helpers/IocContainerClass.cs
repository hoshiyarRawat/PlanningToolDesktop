using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlanningTool.Models.Helpers
{
    public static class IocContainer
    {
        private static Dictionary<Type, object> _instances = new Dictionary<Type, object>();
        private static Dictionary<Type, Type> _types = new Dictionary<Type, Type>();
        private static Dictionary<string, object> _namedInstances = new Dictionary<string, object>();


        /// <summary>
        /// Registers an interface (or abstract type) with a desired concrete type.
        /// </summary>
        /// <typeparam name="TInterface"></typeparam>
        /// <typeparam name="TConcrete"></typeparam>
        public static void RegisterType<TInterface, TConcrete>()
             where TConcrete : TInterface
        {
            //    _types.Add(typeof(TInterface), typeof(TConcrete));

            RegisterType<TInterface, TConcrete>(false);
        }

        public static void RegisterType<TInterface, TConcrete>(bool overrideExisting)
            where TConcrete : TInterface
        {
            if (overrideExisting)
            {
                _types[typeof(TInterface)] = typeof(TConcrete);
                return;
            }

            // This intentially throws error if already exists.
            _types.Add(typeof(TInterface), typeof(TConcrete));
        }


        public static void RemoveType<TInterface>()
        {
            _types.Remove(typeof(TInterface));
        }

        /// <summary>
        /// Resolves the interface or abstract type and returns the registered concrete type
        /// </summary>
        /// <typeparam name="TInterface">
        /// The interface for which to create a new object of the registered concrete type.
        /// </typeparam>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">In case implementation is not exist.</exception>
        public static TInterface ResolveType<TInterface>()
        {
            return ResolveTypeInternal<TInterface>(true);
        }

        /// <summary>
        /// Resolves the interface or abstract type and returns the registered concrete type
        /// </summary>
        /// <typeparam name="TInterface">
        /// The interface for which to create a new object of the registered concrete type.
        /// </typeparam>
        /// <returns></returns>
        public static TInterface ResolveTypeIfExists<TInterface>()
        {
            return ResolveTypeInternal<TInterface>(false);
        }

        private static TInterface ResolveTypeInternal<TInterface>(bool throwIfNotExist)
        {
            Type abstractType = typeof(TInterface);
            Type concreteType = null;

            // Attempt to Resolve Instance.
            if (_types.TryGetValue(abstractType, out concreteType))
            {
                return (TInterface)Activator.CreateInstance(concreteType);
            }

            // Attempt to Resolve Single Instance.
            var t = TryGetSingleInstanceOf<TInterface>();

            if (t != null)
            {
                return t;
            }

            if (throwIfNotExist)
            {
                throw new InvalidOperationException("Unregistered type " + abstractType.FullName);
            }

            return default(TInterface);
        }

        /// <summary>
        /// Registers an shared instance of an interface to be used
        /// </summary>
        /// <typeparam name="T">The interface type.</typeparam>
        /// <param name="instance">The instance to be used.</param>
        public static void RegisterSingleInstance<T>(T instance)
        {
            Type lookupType = typeof(T);
            _instances[lookupType] = instance;
        }

        public static void RemoveSingleInstance<T>()
        {
            Type lookupType = typeof(T);
            _instances.Remove(lookupType);
        }

        /// <summary>
        /// Gets the registered instance of a interface type.
        /// </summary>
        /// <typeparam name="T">The interface or abstract type.</typeparam>
        /// <returns>The registered instance.</returns>
        [Obsolete("Please call ResolveType instead.")]
        public static T GetSingleInstanceOf<T>()
        {
            T t = TryGetSingleInstanceOf<T>();
            if (t == null)
            {
                Type lookupType = typeof(T);
                throw new InvalidOperationException("Unregistered type " + lookupType.FullName);
            }

            return t;
        }

        public static T TryGetSingleInstanceOf<T>()
        {
            Type lookupType = typeof(T);
            if (_instances.ContainsKey(lookupType))
            {
                return (T)_instances[lookupType];
            }

            return default(T);
        }

        public static bool ContainsSingleInstanceOf<T>()
        {
            return _instances.ContainsKey(typeof(T));
        }
     
        public static void Dispose()
        {
            foreach (var instance in _instances)
            {
                DisposeHelper.AttemptDispose(instance.Value);
            }

            foreach (var instance in _namedInstances)
            {
                DisposeHelper.AttemptDispose(instance.Value);
            }

            _instances.Clear();
            _namedInstances.Clear();
        }

        /// <summary>
        /// Clear all entries in IocContainer.  
        /// The main purpose is to allow unit tests to be able to start from clean 
        /// starting point for each test as needed.
        /// </summary>
        public static void ClearAll()
        {
            _instances.Clear();
            _types.Clear();
            _namedInstances.Clear();
        }

        public static class DisposeHelper
        {
            public static void AttemptDispose(object o)
            {
                IDisposable iDisposable = o as IDisposable;
                if (iDisposable != null)
                {
                    iDisposable.Dispose();
                }

                o = null;
            }
        }
    }
}
