// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ConsoleCore.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore
{
    using GTDApp.ConsoleCore.Interfaces;
    using GTDApp.Logic;
    using GTDApp.Logic.Routing;
    using System;

    /// <summary>
    ///     ConsoleCore
    /// </summary>
    public static class ConsoleCore
    {
        public static Router Router { get; set; }
        private static IExceptionHandler ExceptionHandler { get; set; }
        public static BusinessLogic BusinessLogic { get; set; }

        public static void Init(Router router, BusinessLogic businessLogic, IExceptionHandler exeptionHandler)
        {
            Router = router;
            ExceptionHandler = exeptionHandler;
            BusinessLogic = businessLogic;
        }

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
