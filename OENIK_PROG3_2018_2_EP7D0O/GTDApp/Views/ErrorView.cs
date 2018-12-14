// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ErrorView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using System;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Views.Helpers;
    using Terminal.Gui;

    /// <summary>
    ///     ErrorView
    /// </summary>
    public class ErrorView : AbstractView
    {
        /// <summary>
        ///    Gets or sets Message
        /// </summary>
        /// <value>string</value>
        public string Message { get; set; }

        /// <summary>
        ///    Gets or sets Exception
        /// </summary>
        /// <value>Exception</value>
        public Exception Exception { get; set; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            if (this.Message != null)
            {
                win.Add(
                    //new Label(45, 10, this.Message)
                );
            }
            else if(this.Exception != null)
            {
                ExceptionHelper exceptionHelper = new ExceptionHelper(2,1, this.Exception);

                foreach (View view in exceptionHelper.Render())
                {
                    win.Add(view);
                }
            }
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
            return "Error";
        }
    }
}
