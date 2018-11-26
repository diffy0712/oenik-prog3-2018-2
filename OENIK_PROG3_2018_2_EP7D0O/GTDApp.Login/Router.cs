// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Router.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using Attribute = System.Attribute;

    /// <summary>
    ///     Router
    /// </summary>
    public static class Router
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Router"/> class.
        ///     Router
        /// </summary>
        public static void Init(string nameSpace)
        {
            Controllers = new List<IController>();
            LoadDLL(nameSpace);
        }

        /// <summary>
        ///     Call Controller
        /// </summary>
        public static void Call()
        {
            Call(null);
        }

        /// <summary>
        ///     Call a Controller by name
        /// </summary>
        /// <param name="controllerName">controller name to call</param>
        /// <param name="obj">Parameters to send</param>
        public static void Call(string controllerName = null, object[] obj = null)
        {
            foreach (IController controller in Controllers)
            {
                var methods = controller.GetType().GetMethods();
                foreach (MethodInfo methodInfo in methods)
                {
                    var allCustomAttributes = methodInfo.GetCustomAttributes();
                    foreach (Attribute customAttribute in allCustomAttributes)
                    {
                        if (controllerName is null && customAttribute is DefaultAttribute)
                        {
                            Invoke(methodInfo, controller, obj);
                            return;
                        }

                        if (customAttribute is RouteAttribute)
                        {
                            RouteAttribute routeAttribute = customAttribute as RouteAttribute;

                            if (routeAttribute.Name == controllerName)
                            {
                                Invoke(methodInfo, controller, obj);
                                return;
                            }
                        }
                    }
                }
            }

            if (controllerName == "fatal_error")
            {
                throw new Exception("No controller found to invoke!");
            }

            object[] parameters = new string[]
            {
                $"No controller ({controllerName}) found!"
            };

            Call("fatal_error", parameters);
        }

        /// <summary>
        ///     Invokes a method in a controller instance
        /// </summary>
        /// <param name="methodInfo">Method to call</param>
        /// <param name="controller">Controller to call</param>
        /// <param name="obj">Parameters to send</param>
        public static void Invoke(MethodInfo methodInfo, IController controller, object[] obj)
        {
            if (obj is null && methodInfo.GetParameters().Length > 0)
            {
                obj = new object[methodInfo.GetParameters().Length];
                for (int i = 0; i < obj.Length; i++)
                {
                    obj[i] = null;
                }
            }

            methodInfo.Invoke(controller, obj);
        }

        /// <summary>
        ///     Controllers list
        /// </summary>
        private static List<IController> Controllers;

        /// <summary>
        ///     Router
        /// </summary>
        /// <param name="nameSpace">Namespace to get the IControllers from</param>
        private static void LoadDLL(string nameSpace)
        {
            var q = from t in Assembly.GetEntryAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nameSpace
                    select t;

            foreach (Type aktType in q)
            {
                if (aktType.GetInterface(nameof(IController)) != null)
                {
                    object instance = Activator.CreateInstance(aktType);
                    Controllers.Add(instance as IController);
                }
            }
        }
    }
}
