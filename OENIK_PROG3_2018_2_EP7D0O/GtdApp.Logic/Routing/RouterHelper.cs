// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RouterHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GtdApp.Logic.Attributes;
    using GtdApp.Logic.Exceptions;
    using GtdApp.Logic.Interfaces;
    using Attribute = System.Attribute;

    /// <summary>
    ///     RouterHelper
    /// </summary>
    /// <todo>
    ///     Caching?
    /// </todo>
    public static class RouterHelper
    {
        /// <summary>
        ///     LoadControllersFromNamespaceDLL
        ///     HelpMe/Fixme: Loading all instances into a list and than calling from it as needed
        ///                   might be too much if we have big or much controllers.
        ///                   Could I lazy load them or apply proxy maybe?
        /// </summary>
        /// <param name="nameSpace">Namespace to get the IControllers from</param>
        /// <param name="instanceParameters">instanceParameters</param>
        /// <returns>List of controller class instances</returns>
        public static List<IController> LoadControllersFromDLLNamespace(string nameSpace, object[] instanceParameters = null)
        {
            List<IController> controllers = new List<IController>();

            Assembly assembly = Assembly.GetEntryAssembly();
            if (assembly is null)
            {
                // In nUnit tests the Assembly.GetEntryAssembly is null,
                // so we can use getCallingAssembly instead
                assembly = Assembly.GetCallingAssembly();
            }

            IEnumerable<Type> q = from t in assembly.GetTypes()
                    where t.IsClass && t.Namespace == nameSpace
                    select t;

            foreach (Type aktType in q)
            {
                if (aktType.GetInterface(nameof(IController)) != null)
                {
                    object instance = Activator.CreateInstance(aktType, instanceParameters);
                    controllers.Add(instance as IController);
                }
            }

            return controllers;
        }

        /// <summary>
        ///     LoadDLL
        ///     HelpMe/Fixme: Loading all instances into a list and than calling from it as needed
        ///                   might be too much if we have big or much controllers.
        ///                   Could I lazy load them or apply proxy maybe?
        /// </summary>
        /// <param name="controllers">List of controllers</param>
        /// <param name="controllerName">Controller name to invoke</param>
        /// <returns>List of controller class instances</returns>
        /// <thinkme>
        ///     If we would pass multiple routes we might be able to call multiple ones.
        ///     Would that even be ever helpful?
        /// </thinkme>
        public static Route GetRouteToInvoke(List<IController> controllers, string controllerName)
        {
            List<Route> routes = GetRoutesByAttribute(controllers, typeof(RouteAttribute));
            foreach (Route route in routes)
            {
                if (route.Name == controllerName)
                {
                    return route;
                }
            }

            routes = GetRoutesByAttribute(controllers, typeof(DefaultRouteAttribute));
            if (routes.Count() > 0 && controllerName == null)
            {
                return routes[0];
            }

            throw new NoRouteFoundException("Could not find any route to call.");
        }

        /// <summary>
        ///     GetRoutesByAttribute
        /// </summary>
        /// <param name="controllers">List of controllers</param>
        /// <param name="type">Type</param>
        /// <returns>List of route class instances</returns>
        private static List<Route> GetRoutesByAttribute(List<IController> controllers, Type type)
        {
            List<Route> routes = new List<Route>();

            foreach (IController controller in controllers)
            {
                var methods = controller.GetType().GetMethods();
                foreach (MethodInfo methodInfo in methods)
                {
                    var allCustomAttributes = methodInfo.GetCustomAttributes();
                    if (allCustomAttributes != null)
                    {
                        foreach (Attribute customAttribute in allCustomAttributes)
                        {
                            if (customAttribute.GetType() == type)
                            {
                                Route route = new Route();
                                route.Method = methodInfo;
                                route.Controller = controller;
                                if (customAttribute.GetType() == typeof(RouteAttribute))
                                {
                                    RouteAttribute routeAttribute = customAttribute as RouteAttribute;
                                    route.Name = routeAttribute.Name.ToString();
                                }

                                routes.Add(route);
                            }
                        }
                    }
                }
            }

            return routes;
        }
    }
}
