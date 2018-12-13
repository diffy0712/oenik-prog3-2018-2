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
            Route routeToInvoke = RouterHelper.GetRouteToInvoke(Controllers, controllerName);

            RouterHelper.PrepareRouteParametersForInvoke(ref routeToInvoke, parameters);

            // IMPORTANT: In order to VS handle the exceptions
            //            from the method MethodInfo.Invoke as NOT
            //            internal .NET system error(which we cant handle)
            //            we must disable tools->options->debugging->Enable just my code
            // Source: https://stackoverflow.com/questions/2658908/why-is-targetinvocationexception-treated-as-uncaught-by-the-ide?noredirect=1&lq=1
            this.BusinessLogic.ExceptionHandler.Handle(() => {
                try
                {
                    routeToInvoke.Method.Invoke(routeToInvoke.Controller, routeToInvoke.Parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
             });
        }

        private List<IController> Controllers;

        private BusinessLogic BusinessLogic;
    }
}
