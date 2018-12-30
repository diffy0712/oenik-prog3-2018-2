// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ListNotificationsView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Notifications
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Views.Helpers;
    using GTDApp.Data;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     ListContainersView
    /// </summary>
    public class ListNotificationsView : AbstractView
    {
        /// <summary>
        ///     Gets or sets Notifications
        /// </summary>
        /// <value>IQueryable of Notification</value>
        public IQueryable<Notification> Notifications { get; set; }

        /// <summary>
        ///     Gets or sets Paginator
        /// </summary>
        /// <value>Paginator</value>
        public Paginator Paginator { get; set; }

        /// <summary>
        ///    Gets or sets Search
        /// </summary>
        /// <value>String</value>
        public string Search { get; set; }

        /// <summary>
        ///     Gets or sets SearchText
        /// </summary>
        /// <value>TextField</value>
        public TextField SearchText { get; set; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            this.AddSearchElements(win);

            this.AddButtons(win);

            TableHelper tableHelper = new TableHelper(2, 2);

            this.AddTableElements(win, tableHelper);

            this.AddPaginatorElements(win, new PaginatorHelper(tableHelper.X, tableHelper.CurrentY, this.Paginator));
        }

        /// <summary>
        ///     AddButtons
        /// </summary>
        /// <param name="win">Window</param>
        protected void AddButtons(Window win)
        {
            Button addNew = new Button(93, 1, "Add new Notification");
            Action addNewEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.CREATE_NOTIFICATION.ToString()); });
            addNew.Clicked = addNewEvent;
            win.Add(addNew);
        }

        /// <summary>
        ///     AddPaginatorElements
        /// </summary>
        /// <param name="win">Window</param>
        /// <param name="tableHelper">TableHelper</param>
        protected void AddTableElements(Window win, TableHelper tableHelper)
        {
            // Add Headers
            tableHelper.AddHeader("ID", 4);
            tableHelper.AddHeader("Name", 30);
            tableHelper.AddHeader("Type", 10);
            tableHelper.AddHeader("Notify Before", 15);
            tableHelper.AddHeader("Used in items", 12);
            tableHelper.AddHeader(string.Empty, 4);
            tableHelper.AddHeader(string.Empty, 4);

            tableHelper.AddRows(this.GetRows());

            // Add Rows
            tableHelper.Render(win);
        }

        /// <summary>
        ///     AddPaginatorElements
        /// </summary>
        /// <param name="win">Window</param>
        /// <param name="paginatorHelper">PaginatorHelper</param>
        protected void AddPaginatorElements(Window win, PaginatorHelper paginatorHelper)
        {
            Action paginatorAction = new Action(() =>
            {
                object[] parameters = new object[2];
                parameters[0] = this.SearchText.Text.ToString();
                parameters[1] = this.Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_NOTIFICATIONS.ToString(), parameters);
            });
            foreach (View view in paginatorHelper.Render(paginatorAction))
            {
                win.Add(view);
            }
        }

        /// <summary>
        ///     AddSearchElements
        /// </summary>
        /// <param name="win">Window</param>
        protected void AddSearchElements(Window win)
        {
            // Add Search
            var search = new Label("search for: ")
            {
                X = 2,
                Y = 1,
                Width = 10
            };
            this.SearchText = new TextField(string.Empty)
            {
                X = Pos.Right(search) + 1,
                Y = Pos.Top(search),
                Width = 30
            };
            this.SearchText.Text = this.Search;
            Button searchButton = new Button("Run Search...")
            {
                X = Pos.Right(this.SearchText) + 1,
                Y = Pos.Top(this.SearchText)
            };

            Action searchButtonEvent = new Action(() =>
            {
                object[] searchParameters = new object[2];
                searchParameters[0] = this.SearchText.Text.ToString();
                searchParameters[1] = this.Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_NOTIFICATIONS.ToString(), searchParameters);
            });
            searchButton.Clicked = searchButtonEvent;

            win.Add(search, this.SearchText, searchButton);
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
            return "List Notifications";
        }

        /// <summary>
        ///     GetRows
        /// </summary>
        /// <returns>List</returns>
        private List<List<View>> GetRows()
        {
            List<List<View>> rows = new List<List<View>>();

            foreach (var notification in this.Notifications)
            {
                Button editButton = new Button("Edit");
                Action editButtonEvent = new Action(
                    () =>
                    {
                        object[] parameters = new object[]
                        {
                        notification
                        };
                        ConsoleCore.CallRoute(RoutesEnum.UPDATE_NOTIFICATION.ToString(), parameters);
                    });
                editButton.Clicked = editButtonEvent;

                Button deleteButton = new Button("Delete");
                Action deleteButtonEvent = new Action(() =>
                {
                    object[] parameters = new object[]
                    {
                        notification
                    };
                    ConsoleCore.CallRoute(RoutesEnum.DELETE_NOTIFICATION.ToString(), parameters);
                });
                deleteButton.Clicked = deleteButtonEvent;

                rows.Add(new List<View>()
                {
                    new Label($"#{notification.notification_id}"),
                    new Label(notification.name),
                    new Label(notification.type),
                    new Label(notification.amount.ToString() + " " + notification.unit + "(s)"),
                    new Label(notification.Item_notification.Count().ToString()),
                    editButton,
                    deleteButton
                });
            }

            return rows;
        }
    }
}
