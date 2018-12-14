// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RouterHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Exceptions;
    using GTDApp.Logic.Interfaces;
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
        ///     We push null to every parameter the method expects.
        ///     Fixme: This should not be here I assume I made some mistake
        ///            , because it throws exceptions for not having parameters.
        ///            so debug it and if needed fix.
        /// </summary>
        /// <param name="route">Route instance to use</param>
        /// <param name="parameters">Parameters to pass to the method</param>
        public static void PrepareRouteParametersForInvoke(ref Route route, object[] parameters = null)
        {
            if (parameters != null)
            {
                route.Parameters = parameters;
                return;
            }

            parameters = new object[route.Method.GetParameters().Length];
            for (int i = 0; i < parameters.Length; i++)
            {
                parameters[i] = null;
            }

            route.Parameters = parameters;
        }

        /// <summary>
        ///     LoadControllersFromNamespaceDLL
        ///     HelpMe/Fixme: Loading all instances into a list and than calling from it as needed
        ///                   might be too much if we have big or much controllers.
        ///                   Could I lazy load them or apply proxy maybe?
        /// </summary>
        /// <param name="nameSpace">Namespace to get the IControllers from</param>
        /// <returns>List of controller class instances</returns>
        public static List<IController> LoadControllersFromDLLNamespace(string nameSpace, object[] instanceParameters = null)
        {
            List<IController> controllers = new List<IController>();

            var q = from t in Assembly.GetEntryAssembly().GetTypes()
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
        ///     LoadDLL -- 
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
                                if (customAttribute.GetType() == typeof(RouteAttribute)) {
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
