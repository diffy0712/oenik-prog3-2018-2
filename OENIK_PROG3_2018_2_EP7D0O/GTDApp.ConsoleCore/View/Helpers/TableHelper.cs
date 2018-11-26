// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="CommonHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views.Helpers
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Terminal.Gui;

    /// <summary>
    ///     TableHelper
    /// </summary>
    public class TableHelper
    {
        int PADDING = 5;

        /// <summary>
        ///     X
        /// </summary>
        public int X;

        /// <summary>
        ///     X
        /// </summary>
        public int CurrentX;

        /// <summary>
        ///     Y
        /// </summary>
        public int Y;

        /// <summary>
        ///     X
        /// </summary>
        public int CurrentY;

        /// <summary>
        ///     MaximumWidth
        /// </summary>
        private int MaximumWidth;

        /// <summary>
        ///     ViewContainer
        /// </summary>
        private List<View> ViewContainer;

        private List<Dictionary<string, string>> Headers;

        private List<List<View>> Rows;

        /// <summary>
        /// Initializes a new instance of the <see cref="TableHelper"/> class.
        ///     TableHelper
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        public TableHelper(int x, int y, List<Dictionary<string, string>> headers, List<List<View>> rows)
        {
            this.X = x;
            this.Y = y++;
            this.CurrentX = x;
            this.CurrentY = y;
            this.Headers = headers;
            this.Rows = rows;

            this.ViewContainer = new List<View>();
        }

        /// <summary>
        ///     addHeader
        /// </summary>
        /// <returns>List</returns>
        public List<View> Render()
        {
            this.AddHeader();
            this.AddRows();

            return ViewContainer;
        }

        /// <summary>
        ///     AddRows
        /// </summary>
        private void AddRows()
        {
            foreach(List<View> view in this.Rows)
            {
                this.ResetX();
                foreach (Dictionary<string, string> header in Headers)
                {
                    View cellView = view.First();
                    cellView.X = this.CurrentX;
                    cellView.Y = this.CurrentY;
                    this.AddCell(cellView, int.Parse(header["width"]) + PADDING);
                    view.RemoveAt(0);
                }
                this.CurrentY++;
            }
        }

        /// <summary>
        ///     addHeader
        /// </summary>
        private void AddHeader()
        {
            foreach (Dictionary<string, string> header in Headers)
            {
                this.AddCell(new Label(header["name"]) { X = this.CurrentX, Y = this.CurrentY }, int.Parse(header["width"]) + PADDING);
            }

            this.MaximumWidth = this.CurrentX;

            this.CurrentY++;
            this.CurrentY++;
        }

        private void ResetX()
        {
            this.CurrentX = this.X;
        }

        private void AddCell(View view, int width)
        {
            this.ViewContainer.Add(view);
            this.CurrentX += width;
        }
       
    }
}
