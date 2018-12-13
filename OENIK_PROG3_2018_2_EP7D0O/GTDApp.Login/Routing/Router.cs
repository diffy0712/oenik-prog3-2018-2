// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Router.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Routing
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
    public class Router
    {
        /// <summary>
        ///     Fetch the controllers from the specified namespace
        /// </summary>
        /// <param name="nameSpace">Namespace to search IControllers in and calls the default controller method.</param>
        /// <returns>Router</returns>
        public static Router Init(string nameSpace)
        {
            BusinessLogic businessLogic = BusinessLogic.Init();
            Router router = new Router()
            {
                BusinessLogic = businessLogic
            };
            router.Controllers = RouterHelper.LoadControllersFromDLLNamespace(nameSpace, new object[2] { businessLogic, router });

            return router;
        }

        /// <summary>
        ///     Call Controller
        /// </summary>
        /// <param name="parameters">Parameters to pass to the default method</param>
        public void CallDefault(object[] parameters = null)
        {
            Call(null, parameters);
        }

        /// <summary>
        ///     Call a Controller by name
        /// </summary>
        /// <param name="controllerName">controller name to call</param>
        /// <param name="parameters">Parameters to send</param>
        public void Call(string controllerName = null, object[] parameters = null)
        {
            Route routeToEnvoke = RouterHelper.GetRouteToInvoke(Controllers, controllerName);

            RouterHelper.PrepareRouteParametersForInvoke(ref routeToEnvoke, parameters);

            this.BusinessLogic.ExceptionHandler.Handle(() => {
                routeToEnvoke.Method.Invoke(routeToEnvoke.Controller, routeToEnvoke.Parameters);
            });
        }

        private List<IController> Controllers;

        private BusinessLogic BusinessLogic;
    }
}
