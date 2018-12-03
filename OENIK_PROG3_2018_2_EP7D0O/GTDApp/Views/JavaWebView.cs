// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using System.Linq;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Data;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     JavaWebView
    /// </summary>
    public class JavaWebView : AbstractView
    {
        private string response;

        public string Response { get => response; set => response = value; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            win.Add(new Label($"This is called JAVA response {response}") { X = 2, Y = 1 });
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
            return "Java Web";
        }
    }
}
