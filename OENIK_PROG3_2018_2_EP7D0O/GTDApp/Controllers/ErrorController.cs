// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ErrorController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using GTDApp.Console.Views;
    using GTDApp.ConsoleCore.Controllers;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using Terminal.Gui;

    /// <summary>
    ///     ErrorController
    /// </summary>
    public class ErrorController : AbstractController
    {
        public ErrorController(BusinessLogic businessLogic, Router router) : base(businessLogic, router)
        {
        }

        /// <summary>
        ///     Fatal error message controller
        /// </summary>
        /// <param name="message">Message</param>
        [DefaultErrorRoute]
        public void Fatal(string message)
        {
            ErrorView view = new ErrorView()
            {
                Router = this.Router
            };

            view.Message = message;
            view.Render();
        }

        /// <summary>
        ///     DashboardController
        /// </summary>
        /// <param name="exception">Message</param>
        [Route("exception_error")]
        public void Exception(Exception exception)
        {
            ErrorView view = new ErrorView()
            {
                Router = this.Router
            };

            view.Exception = exception;
            view.Render();
        }
    }
}
