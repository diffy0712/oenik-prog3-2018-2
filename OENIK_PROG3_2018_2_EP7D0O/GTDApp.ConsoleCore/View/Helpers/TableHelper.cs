// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="TableHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.ConsoleCore.Views.Helpers
{
    using System.Collections.Generic;
    using System.Linq;
    using Terminal.Gui;

    /// <summary>
    ///     TableHelper
    /// </summary>
    public class TableHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TableHelper"/> class.
        ///     TableHelper
        /// </summary>
        /// <param name="x">X</param>
        /// <param name="y">Y</param>
        /// <param name="padding">Padding</param>
        public TableHelper(int x, int y, int padding = 5)
        {
            this.Padding = padding;
            this.X = x;
            this.Y = y++;
            this.CurrentX = x;
            this.CurrentY = y;
            this.Headers = new List<Dictionary<string, string>>();
            this.Rows = new List<List<View>>();

            this.ViewContainer = new List<View>();
        }

        /// <summary>
        ///     Gets or sets X
        /// </summary>
        /// <value>int</value>
        public int X { get; set; }

        /// <summary>
        ///     Gets or sets CurrentX
        /// </summary>
        /// <value>int</value>
        public int CurrentX { get; set; }

        /// <summary>
        ///     Gets or sets CurrentX
        /// </summary>
        /// <value>int</value>
        public int Y { get; set; }

        /// <summary>
        ///     Gets or sets CurrentY
        /// </summary>
        /// <value>int</value>
        public int CurrentY { get; set; }

        /// <summary>
        ///     Gets or sets Padding
        /// </summary>
        /// <value>int</value>
        private int Padding { get; set; }

        /// <summary>
        ///     Gets or sets MaximumWidth
        /// </summary>
        /// <value>int</value>
        private int MaximumWidth { get; set; }

        /// <summary>
        ///     Gets or sets ViewContainer
        /// </summary>
        /// <value>List of View</value>
        private List<View> ViewContainer { get; set; }

        /// <summary>
        ///     Gets or sets headers
        /// </summary>
        /// <value>List of header key and value pairs</value>
        private List<Dictionary<string, string>> Headers { get; set; }

        /// <summary>
        ///     Gets or sets rows
        /// </summary>
        /// <value>List of List of View</value>
        private List<List<View>> Rows { get; set; }

        /// <summary>
        ///     AddHeader
        /// </summary>
        /// <param name="title">Title</param>
        /// <param name="width">Width</param>
        public void AddHeader(string title, int width)
        {
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            dictionary.Add("name", title);
            dictionary.Add("width", width.ToString());

            this.Headers.Add(dictionary);
        }

        /// <summary>
        ///     AddRows
        /// </summary>
        /// <param name="rows">List of list of rows</param>
        public void AddRows(List<List<View>> rows)
        {
            foreach (List<View> row in rows)
            {
                this.Rows.Add(row);
            }
        }

        /// <summary>
        ///     Render the table
        /// </summary>
        /// <param name="win">Window</param>
        public void Render(Window win)
        {
            this.AddHeader();
            this.AddRows();
            foreach (View view in this.ViewContainer)
            {
                win.Add(view);
            }
        }

        /// <summary>
        ///     Render the table
        /// </summary>
        /// <param name="view">View</param>
        public void Render(View view)
        {
            this.AddHeader();
            this.AddRows();
            foreach (View view_2 in this.ViewContainer)
            {
                view.Add(view_2);
            }
        }

        /// <summary>
        ///     AddRows
        /// </summary>
        private void AddRows()
        {
            foreach (List<View> view in this.Rows)
            {
                this.ResetX();
                foreach (Dictionary<string, string> header in this.Headers)
                {
                    View cellView = view.First();
                    cellView.X = this.CurrentX;
                    cellView.Y = this.CurrentY;
                    this.AddCell(cellView, int.Parse(header["width"]) + this.Padding);
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
            foreach (Dictionary<string, string> header in this.Headers)
            {
                this.AddCell(new Label(header["name"]) { X = this.CurrentX, Y = this.CurrentY }, int.Parse(header["width"]) + this.Padding);
            }

            this.MaximumWidth = this.CurrentX;

            this.CurrentY++;
            this.CurrentY++;
        }

        /// <summary>
        ///     ResetX
        /// </summary>
        private void ResetX()
        {
            this.CurrentX = this.X;
        }

        /// <summary>
        ///     AddCell
        /// </summary>
        /// <param name="view">View</param>
        /// <param name="width">Width</param>
        private void AddCell(View view, int width)
        {
            this.ViewContainer.Add(view);
            this.CurrentX += width;
        }
    }
}
