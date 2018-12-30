// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="AbstractView.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.View
{
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     AbstractView
    /// </summary>
    public abstract class AbstractView : IView
    {
        /// <summary>
        ///     Render
        /// </summary>
        public void Render()
        {
            Application.Init();
            Toplevel top = new Toplevel(Application.Top.Frame);
            MenuHelper mainMenuBar = new MenuHelper(top, this.GetMenu().GetMenu());

            var win = new Window(this.GetTitle())
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            this.Content(win);

            top.Add(win);

            Application.Run(top);
        }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window</param>
        protected abstract void Content(Window win);

        /// <summary>
        ///     Get menu
        /// </summary>
        /// <returns>IMenu</returns>
        protected abstract IMenu GetMenu();

        /// <summary>
        ///     Get Titlte
        /// </summary>
        /// <returns>string</returns>
        protected abstract string GetTitle();
    }
}
