// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ReviewView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using Terminal.Gui;

    /// <summary>
    ///     ReviewView
    /// </summary>
    public class ReviewView : AbstractView
    {
        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
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
            return "Review";
        }
    }
}
