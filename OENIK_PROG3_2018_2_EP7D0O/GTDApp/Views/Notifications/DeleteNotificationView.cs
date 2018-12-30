// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DeleteNotificationView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Notifications
{
    using System;
    using GTDApp.Data;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     DeleteNotificationView
    /// </summary>
    public class DeleteNotificationView : IView
    {
        /// <summary>
        ///     Gets or sets Notification
        /// </summary>
        /// <value>Notification</value>
        public Notification Notification { get; set; }

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
                    $"Unable to delete notification #{this.Notification.notification_id} - {this.Notification.name}. Maybe an item uses it!",
                    100,
                    8,
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } });
            }
            else
            {
                d = new Dialog(
                    $"Are you sure you want to delete #{this.Notification.notification_id} - {this.Notification.name}",
                    80,
                    8,
                    new Button("Ok", is_default: true) { Clicked = () => { this.DeleteAction.Invoke(); } },
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } });
            }

            Application.Run(d);
        }
    }
}
