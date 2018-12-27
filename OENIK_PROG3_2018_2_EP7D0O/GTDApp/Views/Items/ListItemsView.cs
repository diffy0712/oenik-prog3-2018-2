// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ListItemsView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Items
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
    ///     ListItemsView
    /// </summary>
    public class ListItemsView : AbstractView
    {
        /// <summary>
        ///     Gets or sets  Items
        /// </summary>
        public IQueryable<Item> Items { get; set; }

        /// <summary>
        ///     Gets or sets Paginator
        /// </summary>
        public Paginator Paginator { get; set; }

        /// <summary>
        ///    Gets or sets Search
        /// </summary>
        /// <value>String</value>
        public string Search { get; set; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            // Add Search
            var search = new Label("search for: ")
            {
                X = 2,
                Y = 1,
                Width = 10
            };
            var searchText = new TextField(string.Empty)
            {
                X = Pos.Right(search) + 1,
                Y = Pos.Top(search),
                Width = 30
            };
            searchText.Text = Search;
            Button searchButton = new Button("Run Search...")
            {
                X = Pos.Right(searchText) + 1,
                Y = Pos.Top(searchText)
            };

            Action searchButtonEvent = new Action(() => {
                object[] searchParameters = new object[2];
                searchParameters[0] = searchText.Text.ToString();
                searchParameters[1] = Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), searchParameters);
            });
            searchButton.Clicked = searchButtonEvent;

            win.Add(search, searchText, searchButton);

            Button addNew = new Button(86, 1, "Add new Item");
            Action addNewEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.CREATE_ITEM.ToString()); });
            addNew.Clicked = addNewEvent;
            win.Add(addNew);

            Button backToListButton = new Button(100, 1, "Back To List");
            Action backToListButtonEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString()); });
            backToListButton.Clicked = backToListButtonEvent;

            win.Add(backToListButton);

            TableHelper tableHelper = new TableHelper(2, 2);

            tableHelper.AddHeader("ID",3);
            tableHelper.AddHeader("Title", 30);
            tableHelper.AddHeader("Notifications", 3);
            tableHelper.AddHeader(string.Empty, 5);
            tableHelper.AddHeader(string.Empty, 5);
            tableHelper.AddHeader(string.Empty, 5);

            tableHelper.AddRows(this.GetRows());

            tableHelper.Render(win);

            PaginatorHelper paginatorHelper = new PaginatorHelper(tableHelper.X, tableHelper.CurrentY, Paginator);

            Action paginatorAction = new Action(() => {
                object[] parameters = new object[2];
                parameters[0] = Items.First().Container_item.First();
                parameters[1] = searchText.Text.ToString();
                parameters[2] = Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), parameters);
            });
            foreach (View view in paginatorHelper.Render(paginatorAction))
            {
                win.Add(view);
            }
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
            return "List Items";
        }

        /// <summary>
        ///     GetRows
        /// </summary>
        /// <returns>List</returns>
        private List<List<View>> GetRows()
        {
            List<List<View>> rows = new List<List<View>>();

            foreach (var item in this.Items)
            {
                Button notificationsButton = new Button("Notifications");
                Action notificationsButtonEvent = new Action(() => {
                    object[] parameters = new object[] {

                    };
                    // ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), parameters);
                });
                notificationsButton.Clicked = notificationsButtonEvent;

                Button editButton = new Button("Edit");
                Action editButtonEvent = new Action(() => {
                    Item itemInstance = item;
                    object[] parameters = new object[] {
                        itemInstance
                    };
                    ConsoleCore.CallRoute(RoutesEnum.UPDATE_ITEM.ToString(), parameters);
                });
                editButton.Clicked = editButtonEvent;

                Button deleteButton = new Button("Delete");
                Action deleteButtonEvent = new Action(() => {
                    Item itemInstance = item;
                    object[] parameters = new object[] {
                        itemInstance
                    };
                    ConsoleCore.CallRoute(RoutesEnum.DELETE_CONTAINER.ToString(), parameters);
                });
                deleteButton.Clicked = deleteButtonEvent;

                rows.Add(new List<View>()
                {
                    new Label($"#{item.item_id}"),
                    new Label(item.title),
                    new Label(item.Item_notification.Count.ToString()),
                    new Label(item.Item_storage.Count.ToString()),
                    notificationsButton,
                    editButton,
                    deleteButton
                });
            }

            return rows;
        }
    }
}
