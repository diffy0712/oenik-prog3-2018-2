// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ExceptionHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        /// Initializes a new instance of the <see cref="ExceptionHelper"/> class.
        ///     ExceptionHelper
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="exception">An exception to display</param>
        public ExceptionHelper(int x, int y, Exception exception)
        {
            this.X = x;
            this.Y = y;
            this.CurrentX = x;
            this.CurrentY = y;

            this.Exception = exception;
            this.ViewContainer = new List<View>();
        }

        /// <summary>
        ///     Gets or sets X
        /// </summary>
        /// <value>int</value>
        private int X { get; set; }

        /// <summary>
        ///     Gets or sets y
        /// </summary>
        /// <value>int</value>
        private int Y { get; set; }

        /// <summary>
        ///     Gets or sets currentX
        /// </summary>
        /// <value>int</value>
        private int CurrentX { get; set; }

        /// <summary>
        ///     Gets or sets X
        /// </summary>
        /// <value>int</value>
        private int CurrentY { get; set; }

        /// <summary>
        ///    Gets or sets ViewContainer
        /// </summary>
        /// <value>List of View</value>
        private List<View> ViewContainer { get; set; }

        /// <summary>
        ///    Gets or sets Exception
        /// </summary>
        /// <value>Exception</value>
        private Exception Exception { get; set; }

        /// <summary>
        ///     Render
        ///     Todo: Create Algorithm, which loops through the exceptions
        ///           and writes a trace.
        /// </summary>
        /// <returns>List</returns>
        public List<View> Render()
        {
            this.ViewContainer.Add(
                new Label($"{this.Exception.Message}")
                {
                    X = this.CurrentX,
                    Y = this.CurrentY
                });
            return this.ViewContainer;
        }
    }
}
