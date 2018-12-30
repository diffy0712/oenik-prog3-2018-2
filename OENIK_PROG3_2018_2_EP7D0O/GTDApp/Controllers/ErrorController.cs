// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ErrorController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Controllers
{
    using System;
    using GtdApp.Console.Views;
    using GtdApp.Logic.Attributes;
    using GtdApp.Logic.Interfaces;
    using GtdApp.Logic.Routing;

    /// <summary>
    ///     ErrorController
    /// </summary>
    public class ErrorController : IController
    {
        /// <summary>
        ///     Fatal error message controller
        /// </summary>
        /// <param name="message">Message</param>
        [Route(RoutesEnum.DEFAULT_ERROR)]
        public void Default(string message)
        {
            ErrorView view = new ErrorView();

            view.Message = message;
            view.Render();
        }

        /// <summary>
        ///     DashboardController
        /// </summary>
        /// <param name="exception">Message</param>
        [Route(RoutesEnum.EXCEPTION_ERROR)]
        public void Exception(Exception exception)
        {
            ErrorView view = new ErrorView();

            view.Exception = exception;
            view.Render();
        }
    }
}
