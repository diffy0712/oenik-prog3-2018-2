// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Router.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GTDApp.Console.Attributes;
    using GTDApp.Console.Controllers;
    using GTDApp.Console.Views;
    using GTDApp.Repository;
    using Terminal.Gui;
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
        public static void Init()
        {
            Controllers = new List<IController>();
            LoadDLL();
        }

        /// <summary>
        ///     Call Controller
        /// </summary>
        /// <param name="top">Toplevel element</param>
        public static void Call()
        {
            Call(null);
        }

        /// <summary>
        ///     Call Controller
        /// </summary>
        /// <param name="controllerName">ControllerName</param>
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

            ErrorController errorController = new ErrorController();
            errorController.Fatal($"No controller ({controllerName}) found!");
        }

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
        ///     Controllers
        /// </summary>
        /// <returns>List</returns>
        private static List<IController> Controllers;

        /// <summary>
        ///     Router
        /// </summary>
        private static void LoadDLL()
        {
            string nspace = "GTDApp.Console.Controllers";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
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
