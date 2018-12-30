// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="PaginatorHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.ConsoleCore.Views.Helpers
{
    using System;
    using System.Collections.Generic;
    using GtdApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     PaginatorHelper
    /// </summary>
    public class PaginatorHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatorHelper"/> class.
        ///     PaginatorHelper
        /// </summary>
        /// <param name="x">X parameter</param>
        /// <param name="y">Y parameter</param>
        /// <param name="paginator">Paginator instance</param>
        public PaginatorHelper(int x, int y, Paginator paginator)
        {
            this.X = x;
            this.Y = y;
            this.CurrentX = x;
            this.CurrentY = y;

            this.Paginator = paginator;

            this.ViewContainer = new List<View>();
        }

        /// <summary>
        ///     Gets or sets y
        /// </summary>
        /// <value>int</value>
        private Paginator Paginator { get; set; }

        /// <summary>
        ///     Gets or sets y
        /// </summary>
        /// <value>int</value>
        private int X { get; set; }

        /// <summary>
        ///     Gets or sets CurrentX
        /// </summary>
        /// <value>int</value>
        private int CurrentX { get; set; }

        /// <summary>
        ///     Gets or sets y
        /// </summary>
        /// <value>int</value>
        private int Y { get; set; }

        /// <summary>
        ///     Gets or sets y
        /// </summary>
        /// <value>int</value>
        private int CurrentY { get; set; }

        /// <summary>
        ///     Gets or sets y
        /// </summary>
        /// <value>List of View</value>
        private List<View> ViewContainer { get; set; }

        /// <summary>
        ///     Render
        /// </summary>
        /// <returns>List</returns>
        /// <param name="paginatorAction">Paginator action to call on events</param>
        public List<View> Render(Action paginatorAction)
        {
            this.CurrentY++;

            if (this.Paginator.Maximum == 0)
            {
                this.ViewContainer.Add(
                new Label($"No entry found!")
                {
                    X = this.CurrentX,
                    Y = this.CurrentY
                });

                return this.ViewContainer;
            }

            this.ViewContainer.Add(
                new Label($"Currently displaying page {this.Paginator.CurrentPage} out of {this.Paginator.MaximumPage}  ")
                {
                    X = this.CurrentX, Y = this.CurrentY
                });
            this.CurrentY++;

            if (this.Paginator.IsPrev())
            {
                Button prevButton = new Button(this.CurrentX, this.CurrentY, "Prev");
                Action prevButtonEvent = new Action(() =>
                {
                    this.Paginator.Prev();
                    paginatorAction.Invoke();
                });
                prevButton.Clicked = prevButtonEvent;
                this.ViewContainer.Add(prevButton);
                this.CurrentX += 10;
            }

            if (this.Paginator.IsNext())
            {
                Button nextButton = new Button(this.CurrentX, this.CurrentY, "Next");
                Action nextButtonEvent = new Action(() =>
                {
                    this.Paginator.Next();
                    paginatorAction.Invoke();
                });
                nextButton.Clicked = nextButtonEvent;
                this.ViewContainer.Add(nextButton);
            }

            return this.ViewContainer;
        }
    }
}
