// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using Terminal.Gui;

    /// <summary>
    ///     SettingsView
    /// </summary>
    public class SettingsView : AbstractView
    {
        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            win.Add(new FrameView(new Rect(2, 1, 50, 5), "DebugMode")
            {
                new RadioGroup (
                    1,
                    0,
                    new[] { "Enabled - Shows detailed exception.", "Disabled - Shows generic error message.", "None - No Error handling." },
                    0)
            });
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
            return "Settings";
        }
    }
}
