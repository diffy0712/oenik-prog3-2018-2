// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using GTDApp.Console.Attributes;
    using GTDApp.Console.Views;
    using Terminal.Gui;

    /// <summary>
    ///     DashboardController
    /// </summary>
    public class DashboardController : IController
    {
        /// <summary>
        ///     DashboardController
        /// </summary>
        /// <returns>Window</returns>
        [Default]
        [Route("dashboard")]
        public Window Index()
        {
            DashboardView view = new DashboardView();

            return view.Render();
        }
    }
}
