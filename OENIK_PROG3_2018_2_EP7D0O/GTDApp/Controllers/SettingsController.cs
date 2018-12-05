// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="SettingsController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using System.Linq;
    using GTDApp.Console.Views;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     SettingsController
    /// </summary>
    public class SettingsController : IController
    {
        /// <summary>
        ///     DashboardController
        /// </summary>
        [Default]
        [Route("settings")]
        public void Index()
        {
            SettingsView view = new SettingsView();
            view.Render();
        }
    }
}
