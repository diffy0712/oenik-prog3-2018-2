// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ConsoleCore.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore
{
    using System;
    using GTDApp.ConsoleCore.Interfaces;
    using GTDApp.Logic;
    using GTDApp.Logic.Routing;

    /// <summary>
    ///     ConsoleCore
    /// </summary>
    public static class ConsoleCore
    {
        /// <summary>
        ///     Gets or sets Router
        /// </summary>
        /// <value>Router</value>
        public static Router Router { get; set; }

        /// <summary>
        ///     Gets or sets ExceptionHandler
        /// </summary>
        /// <value>IExceptionHandler</value>
        public static IExceptionHandler ExceptionHandler { get; set; }

        /// <summary>
        ///     Gets or sets BusinessLogic
        /// </summary>
        /// <value>BusinessLogic</value>
        public static BusinessLogic BusinessLogic { get; set; }

        /// <summary>
        ///     Init
        /// </summary>
        /// <value>BusinessLogic</value>
        /// <param name="router">Router instace</param>
        /// <param name="businessLogic">BusinessLogic instance</param>
        /// <param name="exeptionHandler">IExceptionHandler instace</param>
        public static void Init(Router router, BusinessLogic businessLogic, IExceptionHandler exeptionHandler)
        {
            Router = router;
            ExceptionHandler = exeptionHandler;
            BusinessLogic = businessLogic;
        }

        /// <summary>
        ///     CallRoute
        /// </summary>
        /// <value>BusinessLogic</value>
        /// <param name="controllerName">string of route</param>
        /// <param name="parameters">object[] of parameters to pass</param>
        public static void CallRoute(string controllerName = null, object[] parameters = null)
        {
            ExceptionHandler.Handle(() =>
            {
                try
                {
                    Router.Call(controllerName, parameters);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            });
        }
    }
}
