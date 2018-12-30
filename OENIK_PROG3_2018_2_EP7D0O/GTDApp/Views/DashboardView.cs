// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Views.Helpers;
    using GTDApp.Data.Dto;
    using Terminal.Gui;

    /// <summary>
    ///     DashboardView
    /// </summary>
    public class DashboardView : AbstractView
    {
        /// <summary>
        ///     Gets or sets NumberOfContainers
        /// </summary>
        /// <value>int</value>
        public int NumberOfContainers { get; set; }

        /// <summary>
        ///     Gets or sets NumberOfItems
        /// </summary>
        /// <value>int</value>
        public int NumberOfItems { get; set; }

        /// <summary>
        ///     Gets or sets NumberOfNotifications
        /// </summary>
        /// <value>int</value>
        public int NumberOfNotifications { get; set; }

        /// <summary>
        ///     Gets or sets AggregatesByContainerType
        /// </summary>
        /// <value>IQueryable</value>
        public IQueryable<object> AggregatesByContainerType { get; set; }

        /// <summary>
        ///     Gets or sets UpcomingNotifications
        /// </summary>
        /// <value>IQueryable</value>
        public IQueryable<object> UpcomingNotifications { get; set; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            this.ContainerLine(win);
            this.NotificationLine(win);
            this.ItemLine(win);
            this.AggregatesByContainerTypeBlock(win);
            this.UpcomingNotificationsBlock(win);
        }

        /// <summary>
        ///     Upcoming Notifications Block render
        /// </summary>
        /// <param name="win">Window instance</param>
        protected void UpcomingNotificationsBlock(Window win)
        {
            FrameView typeView = new FrameView(new Rect(59, 7, 58, 19), "Upcoming Notifications!");
            TableHelper tableHelper = new TableHelper(1, 0);
            List<List<View>> rows = new List<List<View>>();

            foreach (UpcomingNotificationsDto item in this.UpcomingNotifications)
            {
                rows.Add(new List<View>()
                {
                    new Label($"{DateTime.Parse(item.day.ToString()).ToString("dd MMM yyyy")}"),
                    new Label($"{item.item_count}"),
                    new Label($"{item.notification_count}"),
                });
            }

            tableHelper.AddHeader("Day", 10);
            tableHelper.AddHeader("Items", 10);
            tableHelper.AddHeader("Notifications", 10);

            tableHelper.AddRows(rows);
            tableHelper.Render(typeView);
            win.Add(typeView);
        }

        /// <summary>
        ///     Aggregates By Container Type Block render
        /// </summary>
        /// <param name="win">Window instance</param>
        protected void AggregatesByContainerTypeBlock(Window win)
        {
            FrameView typeView = new FrameView(new Rect(1, 7, 57, 19), "Aggregates by container types!");
            TableHelper tableHelper = new TableHelper(1, 0);

            List<List<View>> rows = new List<List<View>>();

            foreach (AggregatesByContainerTypeDto item in this.AggregatesByContainerType)
            {
                rows.Add(new List<View>()
                {
                    new Label($"{item.container_type}"),
                    new Label($"{item.container_count}"),
                    new Label($"{item.item_count}"),
                    new Label($"{item.notification_count}")
                });
            }

            tableHelper.AddHeader("Type", 10);
            tableHelper.AddHeader("Containers", 8);
            tableHelper.AddHeader("Items", 5);
            tableHelper.AddHeader("Notifications", 8);

            tableHelper.AddRows(rows);
            tableHelper.Render(typeView);
            win.Add(typeView);
        }

        /// <summary>
        ///     ItemLine
        /// </summary>
        /// <param name="win">Window instance</param>
        protected void ItemLine(Window win)
        {
            win.Add(new Label($"Number of items: {this.NumberOfItems}") { X = 2, Y = 5 });
        }

        /// <summary>
        ///     ContainerLine
        /// </summary>
        /// <param name="win">Window instance</param>
        protected void ContainerLine(Window win)
        {
            win.Add(new Label($"Number of containers: {this.NumberOfContainers}") { X = 2, Y = 1 });
            Button addNewContainer = new Button(30, 1, "Add new Container");
            addNewContainer.Clicked = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.CREATE_CONTAINER.ToString()); });
            Button listContainers = new Button(55, 1, "List Containers");
            listContainers.Clicked = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString()); });
            win.Add(addNewContainer);
            win.Add(listContainers);
        }

        /// <summary>
        ///     NotificationLine
        /// </summary>
        /// <param name="win">Window instance</param>
        protected void NotificationLine(Window win)
        {
            win.Add(new Label($"Number of notifications: {this.NumberOfNotifications}") { X = 2, Y = 3 });
            Button addNewNotification = new Button(30, 3, "Add new Notification");
            addNewNotification.Clicked = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.CREATE_NOTIFICATION.ToString()); });
            Button listNotifications = new Button(55, 3, "List Notifications");
            listNotifications.Clicked = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.LIST_NOTIFICATIONS.ToString()); });
            win.Add(addNewNotification);
            win.Add(listNotifications);
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
            return "Dashboard";
        }
    }
}
