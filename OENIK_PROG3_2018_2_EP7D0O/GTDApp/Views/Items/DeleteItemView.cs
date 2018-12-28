// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DeleteItemView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using System;
    using GTDApp.Data;
    using GTDApp.Logic;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     DeleteItemView
    /// </summary>
    public class DeleteItemView : IView
    {
        /// <summary>
        ///     Item
        /// </summary>
        public Item Item;

        /// <summary>
        ///     DeleteAction
        /// </summary>
        public Action DeleteAction;

        /// <summary>
        ///     Editor
        /// </summary>
        public void Render()
        {
            Dialog d;

            if (DeleteAction is null)
            {
                d = new Dialog(
                    $"Unable to delete item #{this.Item.item_id} - {this.Item.title}",
                    100,
                    8,
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } }
                );
            }
            else
            {
                d = new Dialog(
                    $"Are you sure you want to delete #{this.Item.item_id} - {this.Item.title}",
                    80,
                    8,
                    new Button("Ok", is_default: true) { Clicked = () => { this.DeleteAction.Invoke(); } },
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } }
                );
            }

            Application.Run(d);
        }
    }
}
