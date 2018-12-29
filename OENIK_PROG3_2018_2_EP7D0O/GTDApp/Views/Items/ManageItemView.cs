// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ManageItemView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers.Items
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GTDApp.Console.Menu;
    using GTDApp.Console.Views.Modals;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Views.Helpers;
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
        public IQueryable Notifications;

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

            win.Add(
                title,
                titleText,
                description,
                descriptionText
            );

            DateTime fromDateTime= (Item.from_date.HasValue) ? Item.from_date.Value : DateTime.Now.AddDays(1);
            DateInputHelper fromDateInputHelper = new DateInputHelper(2,5, fromDateTime);
            fromDateInputHelper.Render(win, "From Date");

            DateTime toDateTime= (Item.from_date.HasValue) ? Item.to_date.Value : DateTime.Now.AddDays(1).AddHours(2);
            DateInputHelper toDateInputHelper = new DateInputHelper(34,5, toDateTime);
            toDateInputHelper.Render(win, "To Date");
            
            FrameView typeView = new FrameView(new Rect(65, 5, 48, 15), "Notifications to enable");

            int prevY = 0;
            Dictionary<Notification, CheckBox> notificationCheckboxes = new Dictionary<Notification, CheckBox>();
            foreach(Notification notification in Notifications)
            {
                CheckBox checkBox = new CheckBox(1, prevY++, notification.name, ConsoleCore.BusinessLogic.ItemHasNotification(Item, notification));
                notificationCheckboxes.Add(notification, checkBox);
                typeView.Add(
                    checkBox
                );
            }

            win.Add(typeView);


            Button manageButton = new Button(85, 24, "Save");
            Action manageButtonEvent = new Action(() =>
            {
                DateTime? fromDate = fromDateInputHelper.GetOutput();
                DateTime? toDate = toDateInputHelper.GetOutput();
                if (fromDate is null || toDate is null)
                {
                    ValidationErrorMessageModalView validationErrorMessageModalView = new ValidationErrorMessageModalView();
                    validationErrorMessageModalView.Render();
                    return;
                }

                Item.title = titleText.Text.ToString();
                Item.description = descriptionText.Text.ToString();
                Item.from_date = fromDate;
                Item.to_date = toDate;

                foreach (KeyValuePair<Notification, CheckBox> entry in notificationCheckboxes)
                {
                    if (entry.Value.Checked && !ConsoleCore.BusinessLogic.ItemHasNotification(Item, entry.Key))
                    {
                        Item.Item_notification.Add(new Item_notification() { Item = Item, Notification = entry.Key });
                    }
                    else if (entry.Value.Checked != true && ConsoleCore.BusinessLogic.ItemHasNotification(Item, entry.Key))
                    {
                        ConsoleCore.BusinessLogic.RemoveItemNotification(Item, entry.Key);
                    }
                };

                object[] parameters = new object[] {
                        Container,
                        Item
                    };
                ConsoleCore.CallRoute(RoutesEnum.MANAGE_ITEM_ACTION.ToString(), parameters);
            });
            manageButton.Clicked = manageButtonEvent;
            
            Button backToListButton = new Button(96, 24, "Back To List");
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
            
            win.Add(
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
