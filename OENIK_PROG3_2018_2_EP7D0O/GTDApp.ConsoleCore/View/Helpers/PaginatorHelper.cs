// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="PaginatorHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views.Helpers
{
    using System;
    using System.Collections.Generic;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     PaginatorHelper
    /// </summary>
    public class PaginatorHelper
    {
        /// <summary>
        ///     Paginator
        /// </summary>
        Paginator paginator;

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
        ///     ViewContainer
        /// </summary>
        private List<View> viewContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatorHelper"/> class.
        ///     PaginatorHelper
        /// </summary>
        /// <param name="x">X parameter</param>
        /// <param name="y">Y parameter</param>
        /// <param name="paginator">Paginator instance</param>
        public PaginatorHelper(int x, int y, Paginator paginator)
        {
            this.x = x;
            this.y = y;
            this.currentX = x;
            this.currentY = y;

            this.paginator = paginator;

            this.viewContainer = new List<View>();
        }

        /// <summary>
        ///     Render
        /// </summary>
        /// <returns>List</returns>
        /// <param name="paginatorAction">Paginator action to call on events</param>
        public List<View> Render(Action paginatorAction)
        {
            this.currentY++;
            this.viewContainer.Add(
                new Label($"Currently displaying page {this.paginator.CurrentPage} out of {this.paginator.MaximumPage}  ")
                {
                    X = this.currentX, Y = this.currentY
                });
            this.currentY++;

            if (this.paginator.IsPrev())
            {
                Button prevButton = new Button(this.currentX, this.currentY, "Prev");
                Action prevButtonEvent = new Action(() =>
                {
                    this.paginator.Prev();
                    paginatorAction.Invoke();
                });
                prevButton.Clicked = prevButtonEvent;
                this.viewContainer.Add(prevButton);
                this.currentX += 10;
            }

            if (this.paginator.IsNext())
            {
                Button nextButton = new Button(this.currentX, this.currentY, "Next");
                Action nextButtonEvent = new Action(() =>
                {
                    this.paginator.Next();
                    paginatorAction.Invoke();
                });
                nextButton.Clicked = nextButtonEvent;
                this.viewContainer.Add(nextButton);
            }

            return this.viewContainer;
        }
    }
}
