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
        ///     Gets or sets Items
        /// </summary>
        /// <value>IQueryable of items</value>
        public IQueryable<Item> Items { get; set; }

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
        ///    Gets or sets SearchText
        /// </summary>
        /// <value>TextField</value>
        public TextField SearchText { get; set; }

        /// <summary>
        ///    Gets or sets Container
        /// </summary>
        /// <value>Container</value>
        public Container Container { get; set; }

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
        /// <param name="win">Window instance</param>
        protected void AddButtons(Window win)
        {
            Button addNew = new Button(72, 1, "Add new Item");
            Action addNewEvent = new Action(
                () =>
                {
                    object[] parameters = new object[]
                    {
                        this.Container
                    };
                    ConsoleCore.CallRoute(RoutesEnum.CREATE_ITEM.ToString(), parameters);
                });
            addNew.Clicked = addNewEvent;
            win.Add(addNew);

            Button backToListButton = new Button(90, 1, "Back To Container List");
            Action backToListButtonEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString()); });
            backToListButton.Clicked = backToListButtonEvent;

            win.Add(backToListButton);
        }

        /// <summary>
        ///     AddTableElements
        /// </summary>
        /// <param name="win">Window instance</param>
        /// <param name="tableHelper">Table Helper</param>
        protected void AddTableElements(Window win, TableHelper tableHelper)
        {
            tableHelper.AddHeader("ID", 3);
            tableHelper.AddHeader("Title", 68);
            tableHelper.AddHeader("Notifications", 10);
            tableHelper.AddHeader(string.Empty, 4);
            tableHelper.AddHeader(string.Empty, 4);

            tableHelper.AddRows(this.GetRows());

            tableHelper.Render(win);
        }

        /// <summary>
        ///     AddPaginatorElements
        /// </summary>
        /// <param name="win">Window instance</param>
        /// <param name="paginatorHelper">Paginator Helper</param>
        protected void AddPaginatorElements(Window win, PaginatorHelper paginatorHelper)
        {
            Action paginatorAction = new Action(() =>
            {
                object[] parameters = new object[3];
                parameters[0] = this.Container;
                parameters[1] = this.SearchText.Text.ToString();
                parameters[2] = this.Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), parameters);
            });
            foreach (View view in paginatorHelper.Render(paginatorAction))
            {
                win.Add(view);
            }
        }

        /// <summary>
        ///     AddSearchElements
        /// </summary>
        /// <param name="win">Window instance</param>
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
                object[] searchParameters = new object[3];
                searchParameters[0] = this.Container;
                searchParameters[1] = this.SearchText.Text.ToString();
                searchParameters[2] = this.Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), searchParameters);
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
                Button editButton = new Button("Edit");
                Action editButtonEvent = new Action(() =>
                {
                    Item itemInstance = item;
                    object[] parameters = new object[]
                    {
                        this.Container,
                        itemInstance
                    };
                    ConsoleCore.CallRoute(RoutesEnum.UPDATE_ITEM.ToString(), parameters);
                });
                editButton.Clicked = editButtonEvent;

                Button deleteButton = new Button("Delete");
                Action deleteButtonEvent = new Action(() =>
                {
                    Item itemInstance = item;
                    object[] parameters = new object[]
                    {
                        itemInstance
                    };
                    ConsoleCore.CallRoute(RoutesEnum.DELETE_ITEM.ToString(), parameters);
                });
                deleteButton.Clicked = deleteButtonEvent;

                rows.Add(new List<View>()
                {
                    new Label($"#{item.item_id}"),
                    new Label(item.title),
                    new Label(item.Item_notification.Count().ToString()),
                    editButton,
                    deleteButton
                });
            }

            return rows;
        }
    }
}
