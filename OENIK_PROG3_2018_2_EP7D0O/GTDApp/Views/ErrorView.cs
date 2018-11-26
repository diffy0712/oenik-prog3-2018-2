// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ErrorView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     ErrorView
    /// </summary>
    public class ErrorView : IView
    {
        public string Message { get; set; }

        /// <summary>
        ///     render the view
        /// </summary>
        public void Render()
        {
            var tframe = Application.Top.Frame;
            var ntop = new Toplevel(tframe);

            MenuHelper mainMenuBar = new MenuHelper(ntop, MainMenu.GetMenu());

            ColorScheme colorScheme = new ColorScheme();
            var win = new Window("Error Container")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            Label message = new Label(45,10, Message);

            // Add some content
            win.Add(
                message
            );

            ntop.Add(win);

            Application.Run(ntop);
        }
    }
}
