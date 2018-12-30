// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DeleteItemView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Views.Items
{
    using System;
    using GtdApp.Data;
    using GtdApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     DeleteItemView
    /// </summary>
    public class DeleteItemView : IView
    {
        /// <summary>
        ///     Gets or sets Item
        /// </summary>
        /// <value>Item</value>
        public Item Item { get; set; }

        /// <summary>
        ///     Gets or sets DeleteAction
        /// </summary>
        /// <value>Action</value>
        public Action DeleteAction { get; set; }

        /// <summary>
        ///     Editor
        /// </summary>
        public void Render()
        {
            Dialog d;

            if (this.DeleteAction is null)
            {
                d = new Dialog(
                    $"Unable to delete item #{this.Item.item_id} - {this.Item.title}",
                    100,
                    8,
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } });
            }
            else
            {
                d = new Dialog(
                    $"Are you sure you want to delete #{this.Item.item_id} - {this.Item.title}",
                    80,
                    8,
                    new Button("Ok", is_default: true) { Clicked = () => { this.DeleteAction.Invoke(); } },
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } });
            }

            Application.Run(d);
        }
    }
}
