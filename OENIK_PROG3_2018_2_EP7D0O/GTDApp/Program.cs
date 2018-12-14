// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Program.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console
{
    using GTDApp.Console.Exceptions;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Interfaces;
    using GTDApp.Logic;
    using GTDApp.Logic.Routing;

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
            Router router = Router.Init("GTDApp.Console.Controllers");
            //IExceptionHandler exceptionHandler = new DetailedExceptionHandler();
            IExceptionHandler exceptionHandler = new NullExceptionHandler();

            ConsoleCore.Init(router, businessLogic, exceptionHandler);
            ConsoleCore.CallRoute();
        }
    }
}
