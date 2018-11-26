// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ErrorController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Console.Views;
    using Terminal.Gui;

    /// <summary>
    ///     ErrorController
    /// </summary>
    public class ErrorController : IController
    {
        /// <summary>
        ///     DashboardController
        /// </summary>
        /// <param name="message">Message</param>
        [Route("fatal_error")]
        public void Fatal(string message)
        {
            ErrorView view = new ErrorView();

            view.Message = message;
            view.Render();
        }
    }
}
