// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using Terminal.Gui;

    /// <summary>
    ///     DashboardView
    /// </summary>
    public class DashboardView : IView
    {
        /// <summary>
        ///     render the view
        /// </summary>
        public void Render()
        {
            MainMenuBar mainMenuBar = new MainMenuBar();
            var tframe = Application.Top.Frame;
            var ntop = new Toplevel(tframe);

            ntop.Add(mainMenuBar.Render(ntop));

            var win = new Window("Dashboard")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            var name = new Label("Number of containers: 5 ") { X = 2, Y = 1 };

            // Add some content
            win.Add(
                name
            );

            ntop.Add(win);

            Application.Run(ntop);
        }
    }
}
