// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Program.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console
{
    using System;
    using GtdApp.Console.Exceptions;
    using GtdApp.ConsoleCore;
    using GtdApp.ConsoleCore.Interfaces;
    using GtdApp.Logic;
    using GtdApp.Logic.Routing;

    /// <summary>
    ///     Entry Point
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Start the Program
        /// </summary>
        public static void Main()
        {
            BusinessLogic businessLogic = BusinessLogic.Init();
            Router router = Router.Init("GtdApp.Console.Controllers");
            IExceptionHandler exceptionHandler = new DetailedExceptionHandler();

            // IExceptionHandler exceptionHandler = new NullExceptionHandler();
            ConsoleCore.Init(router, businessLogic, exceptionHandler);
            ConsoleCore.CallRoute();
        }
    }
}
