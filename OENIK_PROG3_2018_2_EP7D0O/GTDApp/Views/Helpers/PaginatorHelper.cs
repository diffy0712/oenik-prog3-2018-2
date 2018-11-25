// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="PaginatorHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Terminal.Gui;
    using GTDApp.Repository;

    /// <summary>
    ///     PaginatorHelper
    /// </summary>
    public class PaginatorHelper
    {
        Paginator Paginator;

        /// <summary>
        ///     X
        /// </summary>
        private int X;

        /// <summary>
        ///     X
        /// </summary>
        private int CurrentX;

        /// <summary>
        ///     Y
        /// </summary>
        private int Y = 0;

        /// <summary>
        ///     X
        /// </summary>
        private int CurrentY;

        /// <summary>
        ///     ViewContainer
        /// </summary>
        private List<View> ViewContainer;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaginatorHelper"/> class.
        ///     PaginatorHelper
        /// </summary>
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
        ///     Render
        /// </summary>
        /// <returns>List</returns>
        public List<View> Render(Action paginatorAction)
        {
            this.CurrentY++;
            ViewContainer.Add(new Label($"Currently displaying page {Paginator.CurrentPage} out of {Paginator.MaximumPage}  ") { X = this.CurrentX, Y = this.CurrentY });
            this.CurrentY++;

            if (Paginator.IsPrev())
            {
                Button prevButton = new Button(this.CurrentX, this.CurrentY, "Prev");
                Action prevButtonEvent = new Action(() => { Paginator.Prev(); paginatorAction.Invoke(); });
                prevButton.Clicked = prevButtonEvent; 
                ViewContainer.Add(prevButton);

                this.CurrentX += 10;
            }

            if (Paginator.IsNext())
            {
                Button nextButton = new Button(this.CurrentX, this.CurrentY, "Next");
                Action nextButtonEvent = new Action(() => { Paginator.Next(); paginatorAction.Invoke(); });
                nextButton.Clicked = nextButtonEvent;
                ViewContainer.Add(nextButton);
            }

            // Current page number of results - Previous - Next

            return ViewContainer;
        }
    }
}
