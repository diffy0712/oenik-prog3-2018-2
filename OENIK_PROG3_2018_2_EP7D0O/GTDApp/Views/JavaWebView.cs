// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="JavaWebView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Views
{
    using System.Collections.Generic;
    using GtdApp.Console.Menu;
    using GtdApp.ConsoleCore.Menu;
    using GtdApp.ConsoleCore.View;
    using GtdApp.ConsoleCore.Views.Helpers;
    using GtdApp.Data;
    using Terminal.Gui;

    /// <summary>
    ///     JavaWebView
    /// </summary>
    public class JavaWebView : AbstractView
    {
        /// <summary>
        ///     Gets or sets Response
        /// </summary>
        /// <value>List of items</value>
        public List<Item> Response { get; set; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            TableHelper tableHelper = new TableHelper(1, 0);

            List<List<View>> rows = new List<List<View>>();

            foreach (Item item in this.Response)
            {
                rows.Add(new List<View>()
                {
                    new Label($"{item.title}"),
                    new Label($"{item.description}")
                });
            }

            tableHelper.AddHeader("Title", 20);
            tableHelper.AddHeader("Description", 30);

            tableHelper.AddRows(rows);
            tableHelper.Render(win);
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
            return "Java endpoint call response items!";
        }
    }
}
