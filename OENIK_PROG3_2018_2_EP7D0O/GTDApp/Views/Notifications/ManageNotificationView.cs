// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ManageNotificationView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Notifications
{
    using System;
    using System.Linq;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.Data;
    using Terminal.Gui;

    /// <summary>
    ///     ManageContainerView
    /// </summary>
    public class ManageNotificationView : AbstractView
    {
        public bool Creation = true;
        public Notification Notification;

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            var name = new Label("Name: ") { X = 2, Y = 1 };
            var amount = new Label("Amount: ")
            {
                X = Pos.Left(name),
                Y = Pos.Bottom(name) + 1,
                Width = 25
            };
            var nameText = new TextField(Notification.name)
            {
                X = Pos.Right(amount),
                Y = Pos.Top(name),
                Width = 85
            };
            var amountText = new TextField(Notification.amount.ToString())
            {
                X = Pos.Left(nameText),
                Y = Pos.Top(amount),
                Width = Dim.Width(nameText),
            };
            string[] unitsArray = new[] {
                "min",
                "day",
            };

            int unitSelected = 0;

            if (!Creation)
            {
                for (int i = 0; i < unitsArray.Length; i++)
                {
                    if (unitsArray[i] == Notification.unit)
                    {
                        unitSelected = i;
                    }
                }
            }

            RadioGroup unitGroup = new RadioGroup(
                1,
                0,
                unitsArray,
                unitSelected
            );

            FrameView unitView = new FrameView(new Rect(2, 5, 110, 5), "Unit to notify."){
                unitGroup
            };


            string[] typesArray = new[] {
                "email",
                "sms"
            };

            int typeSelected = 0;

            if (!Creation) {
                for (int i = 0; i < typesArray.Length; i++)
                {
                    if( typesArray[i] == Notification.type)
                    {
                        typeSelected = i;
                    }
                }
            }

            RadioGroup typeGroup = new RadioGroup(
                1,
                0,
                typesArray,
                typeSelected
            );

            FrameView typeView = new FrameView(new Rect(2, 11, 110, 5), "Type of Notification"){
                typeGroup
            };


            Button manageButton = new Button(85, 19, "Save");
            Action manageButtonEvent = new Action(() =>
            {
                Notification.name = nameText.Text.ToString();
                Notification.amount = int.Parse(amountText.Text.ToString());
                Notification.type = typesArray[typeGroup.Selected].ToString();
                Notification.unit = unitsArray[unitGroup.Selected].ToString();
                object[] parameters = new object[] {
                    Notification
                };
                ConsoleCore.CallRoute(RoutesEnum.MANAGE_NOTIFICATION_ACTION.ToString(), parameters);
            });
            manageButton.Clicked = manageButtonEvent;

            Button backToListButton = new Button(96, 19, "Back To List");
            Action backToListButtonEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.LIST_NOTIFICATIONS.ToString()); });
            backToListButton.Clicked = backToListButtonEvent;

            // Add some content
            win.Add(
                name,
                nameText,
                amount,
                amountText,
                unitView,
                typeView,
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
            return (Creation) ? "Create Notification" : "Edit Notification";
        }
    }
}
