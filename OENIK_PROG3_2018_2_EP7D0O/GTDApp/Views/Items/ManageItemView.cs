// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ManageItemView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers.Items
{
    using System;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.Data;
    using Terminal.Gui;

    /// <summary>
    ///     ManageItemView
    /// </summary>
    public class ManageItemView : AbstractView
    {
        public bool Creation = true;
        public Item Item;
        public Container Container;

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            var title = new Label("Title: ") { X = 2, Y = 1 };
            var description = new Label("Description: ")
            {
                X = Pos.Left(title),
                Y = Pos.Bottom(title) + 1,
                Width = 25
            };
            var titleText = new TextField(Item.title)
            {
                X = Pos.Right(description),
                Y = Pos.Top(title),
                Width = 85
            };
            var descriptionText = new TextField(Item.description)
            {
                X = Pos.Left(titleText),
                Y = Pos.Top(description),
                Width = Dim.Width(titleText),
            };
            Button manageButton = new Button(85, 19, "Save");
            Action manageButtonEvent = new Action(() =>
            {
                Item.title = titleText.Text.ToString();
                Item.description = descriptionText.Text.ToString();
                object[] parameters = new object[] {
                    Container,
                    Item
                };
                ConsoleCore.CallRoute(RoutesEnum.MANAGE_ITEM_ACTION.ToString(), parameters);
            });
            manageButton.Clicked = manageButtonEvent;
            
            Button backToListButton = new Button(96, 19, "Back To List");
            Action backToListButtonEvent = new Action(
                () => {
                    object[] parameters = new object[]
                    {
                        Container,
                        null,
                        null
                    };
                    ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), parameters);
                }
            );
            backToListButton.Clicked = backToListButtonEvent;

            // Add some content
            win.Add(
                title,
                titleText,
                description,
                descriptionText,
                manageButton,
                backToListButton
            );
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
            return (Creation) ? "Create Item" : "Edit Item";
        }
    }
}
