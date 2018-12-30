// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ListContainersView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
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
    public class ListContainersView : AbstractView
    {
        /// <summary>
        ///    Gets or sets Container
        /// </summary>
        /// <value>Container</value>
        public IQueryable<Container> Containers { get; set; }

        /// <summary>
        ///    Gets or sets Paginator
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
            Button addNew = new Button(96, 1, "Add new Container");
            Action addNewEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.CREATE_CONTAINER.ToString()); });
            addNew.Clicked = addNewEvent;
            win.Add(addNew);
        }

        /// <summary>
        ///     AddPaginatorElements
        /// </summary>
        /// <param name="win">Window instance</param>
        /// <param name="tableHelper">Table Helper</param>
        protected void AddTableElements(Window win, TableHelper tableHelper)
        {
            // Add Headers
            tableHelper.AddHeader("ID", 3);
            tableHelper.AddHeader("Name", 41);
            tableHelper.AddHeader("Type", 20);
            tableHelper.AddHeader("Items", 3);
            tableHelper.AddHeader(string.Empty, 4);
            tableHelper.AddHeader(string.Empty, 4);
            tableHelper.AddHeader(string.Empty, 4);

            tableHelper.AddRows(this.GetRows());

            // Add Rows
            tableHelper.Render(win);
        }

        /// <summary>
        ///     AddPaginatorElements
        /// </summary>
        /// <param name="win">Window instance</param>
        /// <param name="paginatorHelper">Pagination helper</param>
        protected void AddPaginatorElements(Window win, PaginatorHelper paginatorHelper)
        {
            Action paginatorAction = new Action(() =>
            {
                object[] parameters = new object[2];
                parameters[0] = this.SearchText.Text.ToString();
                parameters[1] = this.Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString(), parameters);
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
                object[] searchParameters = new object[2];
                searchParameters[0] = this.SearchText.Text.ToString();
                searchParameters[1] = this.Paginator;
                ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString(), searchParameters);
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
            return "List Containers";
        }

        /// <summary>
        ///     GetRows
        /// </summary>
        /// <returns>List</returns>
        private List<List<View>> GetRows()
        {
            List<List<View>> rows = new List<List<View>>();

            foreach (var item in this.Containers)
            {
                Button itemsButton = new Button("Items");
                Action itemsButtonEvent = new Action(() =>
                {
                    Container container = item;
                    object[] parameters = new object[]
                    {
                        container,
                        null,
                        null
                    };
                    ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), parameters);
                });
                itemsButton.Clicked = itemsButtonEvent;

                Button editButton = new Button("Edit");
                Action editButtonEvent = new Action(() =>
                {
                    Container container = item;
                    object[] parameters = new object[]
                    {
                        container
                    };
                    ConsoleCore.CallRoute(RoutesEnum.UPDATE_CONTAINER.ToString(), parameters);
                });
                editButton.Clicked = editButtonEvent;

                Button deleteButton = new Button("Delete");
                Action deleteButtonEvent = new Action(() =>
                {
                    Container container = item;
                    object[] parameters = new object[1];
                    parameters[0] = container;
                    ConsoleCore.CallRoute(RoutesEnum.DELETE_CONTAINER.ToString(), parameters);
                });
                deleteButton.Clicked = deleteButtonEvent;

                rows.Add(new List<View>()
                {
                    new Label($"#{item.container_id}"),
                    new Label(item.name),
                    new Label(item.type),
                    new Label(item.Item.Count.ToString()),
                    itemsButton,
                    editButton,
                    deleteButton
                });
            }

            return rows;
        }
    }
}
