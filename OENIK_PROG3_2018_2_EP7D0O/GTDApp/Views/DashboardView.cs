// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Data;
    using GTDApp.Logic.Interfaces;
    using System.Linq;
    using Terminal.Gui;

    /// <summary>
    ///     DashboardView
    /// </summary>
    public class DashboardView : AbstractView
    {
        /// <summary>
        ///     Gets or sets  NumberOfContainers
        /// </summary>
        private int numberOfContainers;

        public int NumberOfContainers { get => numberOfContainers; set => numberOfContainers = value; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            win.Add(new Label($"Number of containers: {NumberOfContainers}") { X = 2, Y = 1 });
        }

        /// <summary>
        ///     GetMenu
        /// </summary>
        /// <returns>IMenu</returns>
        protected override IMenu GetMenu()
        {
            return new MainMenu();
        }

        /// <summary>
        ///     GetTitle
        /// </summary>
        /// <returns>string</returns>
        protected override string GetTitle()
        {
            return "Dashboard";
        }
    }
}
