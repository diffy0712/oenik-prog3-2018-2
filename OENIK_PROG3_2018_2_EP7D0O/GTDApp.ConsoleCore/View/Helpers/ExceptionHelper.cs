// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ExceptionHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views.Helpers
{
    using System;
    using System.Collections.Generic;
    using Terminal.Gui;

    /// <summary>
    ///     ExceptionHelper
    /// </summary>
    public class ExceptionHelper
    {
        /// <summary>
        ///    Gets or sets Exception
        /// </summary>
        /// <value>Exception</value>
        public Exception Exception { get; set; }

        /// <summary>
        ///     ViewContainer
        /// </summary>
        private List<View> viewContainer;

        /// <summary>
        ///     x
        /// </summary>
        private readonly int x;

        /// <summary>
        ///     currentX
        /// </summary>
        private int currentX;

        /// <summary>
        ///     y
        /// </summary>
        private readonly int y;

        /// <summary>
        ///     X
        /// </summary>
        private int currentY;

        /// <summary>
        ///     ExceptionHelper
        /// </summary>
        /// <param name="exception">An exception to display</param>
        public ExceptionHelper(int x, int y, Exception exception)
        {
            this.x = x;
            this.y = y;
            this.currentX = x;
            this.currentY = y;

            this.Exception = exception;
            this.viewContainer = new List<View>();
        }

        /// <summary>
        ///     Render
        ///     Todo: Create Algorithm, which loops through the exceptions
        ///           and writes a trace.
        /// </summary>
        /// <returns>List</returns>
        public List<View> Render()
        {
            this.viewContainer.Add(
                new Label($"{this.Exception.Message}")
                {
                    X = this.currentX,
                    Y = this.currentY
                });
           
            return this.viewContainer;
        }
    }
}
