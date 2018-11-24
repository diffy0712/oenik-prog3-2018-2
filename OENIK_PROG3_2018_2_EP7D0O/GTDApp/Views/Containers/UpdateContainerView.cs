// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="UpdateContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using Terminal.Gui;

    /// <summary>
    ///     UpdateContainerView
    /// </summary>
    public class UpdateContainerView : IView
    {
        /// <summary>
        ///     Editor
        /// </summary>
        /// <param name="top">Top level</param>
        public Window Render()
        {
            //var tframe = top.Frame;
            //var ntop = new Toplevel(tframe);
            //MainMenuBar mainMenuBar = new MainMenuBar();

            //ntop.Add(mainMenuBar.Render(ntop));

            var win = new Window("Update Container")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            return win;

            //ntop.Add(win);

            //Application.Run(ntop);
        }
    }
}
