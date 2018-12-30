// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Router.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Logic.Routing
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using GTDApp.Logic.Interfaces;

    /// <summary>
    ///     Router
    /// </summary>
    public class Router
    {
        /// <summary>
        ///     Gets or sets Controllers
        /// </summary>
        /// <value>List of IController</value>
        private List<IController> Controllers;

        /// <summary>
        ///     Fetch the controllers from the specified namespace
        /// </summary>
        /// <param name="nameSpace">Namespace to search IControllers in and calls the default controller method.</param>
        /// <returns>Router</returns>
        public static Router Init(string nameSpace)
        {
            Router router = new Router();
            router.Controllers = RouterHelper.LoadControllersFromDLLNamespace(nameSpace, null);

            return router;
        }

        /// <summary>
        ///     Call a Controller by name
        /// </summary>
        /// <param name="controllerName">controller name to call</param>
        /// <param name="parameters">Parameters to send</param>
        public void Call(string controllerName = null, object[] parameters = null)
        {
            Route routeToInvoke = RouterHelper.GetRouteToInvoke(this.Controllers, controllerName);

            RouterHelper.PrepareRouteParametersForInvoke(ref routeToInvoke, parameters);

            // IMPORTANT: In order to VS handle the exceptions
            //            from the method MethodInfo.Invoke as NOT
            //            internal .NET system error(which we cant handle)
            //            we must disable tools->options->debugging->Enable just my code
            // Source: https://stackoverflow.com/questions/2658908/why-is-targetinvocationexception-treated-as-uncaught-by-the-ide?noredirect=1&lq=1
            try
            {
                routeToInvoke.Method.Invoke(routeToInvoke.Controller, routeToInvoke.Parameters);
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
