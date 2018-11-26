// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="UpdateContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     UpdateContainerView
    /// </summary>
    public class UpdateContainerView : IView
    {
        /// <summary>
        ///     Editor
        /// </summary>
        public void Render()
        {
            var tframe = Application.Top.Frame;
            var ntop = new Toplevel(tframe);
            MenuHelper mainMenuBar = new MenuHelper(ntop, MainMenu.GetMenu());
            var win = new Window("Update Container")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            ntop.Add(win);

            Application.Run(ntop);
        }
    }
}
