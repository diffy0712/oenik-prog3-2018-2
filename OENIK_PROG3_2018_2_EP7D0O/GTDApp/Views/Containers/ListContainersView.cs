﻿// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ListContainersView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Controllers;
    using GTDApp.ConsoleCore.Views.Helpers;
    using GTDApp.Data;
    using GTDApp.Repository;
    using System;
    using System.Collections.Generic;
    using GTDApp.Logic;
    using Terminal.Gui;
    using GTDApp.Console.Menu;
    using GTDApp.Logic.Interfaces;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Menu;
    using System.Linq;

    /// <summary>
    ///     ListContainersView
    /// </summary>
    public class ListContainersView : AbstractView
    {
        /// <summary>
        ///     Gets or sets  ListContainersView
        /// </summary>
        private IQueryable<Container> Containers;

        /// <summary>
        ///     Gets or sets Paginator
        /// </summary>
        private Paginator Paginator;

        /// <summary>
        ///    Gets or sets Search
        /// </summary>
        /// <value>String</value>
        private string Search;

        /// <summary>
        /// Initializes a new instance of the <see cref="ListContainersView"/> class.
        ///     ListContainersView
        /// </summary>
        /// <param name="containers">Containers list</param>
        /// <param name="paginator">Paginator instance</param>
        /// <param name="search">Search string parameter</param>
        public ListContainersView(IQueryable<Container> containers, Paginator paginator, string search)
        {
            this.Containers = containers;
            this.Paginator = paginator;
            this.Search = search;
        }

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
                Router.Call("list_containers", searchParameters);
            });
            searchButton.Clicked = searchButtonEvent;

            win.Add(search, searchText, searchButton);

            Button addNew = new Button(96, 1, "Add new Container");
            Action addNewEvent = new Action(() => { Router.Call("create_container"); });
            addNew.Clicked = addNewEvent;
            win.Add(addNew);

            Dictionary<string, string> idDictionary = new Dictionary<string, string>();
            idDictionary.Add("name", "ID");
            idDictionary.Add("width", "3");

            Dictionary<string, string> nameDictionary = new Dictionary<string, string>();
            nameDictionary.Add("name", "Name");
            nameDictionary.Add("width", "30");

            Dictionary<string, string> typeDictionary = new Dictionary<string, string>();
            typeDictionary.Add("name", "Type");
            typeDictionary.Add("width", "20");

            Dictionary<string, string> editDictionary = new Dictionary<string, string>();
            editDictionary.Add("name", string.Empty);
            editDictionary.Add("width", "5");

            Dictionary<string, string> deleteDictionary = new Dictionary<string, string>();
            deleteDictionary.Add("name", string.Empty);
            deleteDictionary.Add("width", "5");
            List<Dictionary<string, string>> headers = new List<Dictionary<string, string>>
            {
                idDictionary,
                nameDictionary,
                typeDictionary,
                editDictionary,
                deleteDictionary,
            };

            List<List<View>> rows = this.GetRows();
            TableHelper tableHelper = new TableHelper(2, 2, headers, rows);
            foreach (View view in tableHelper.Render())
            {
                win.Add(view);
            }

            PaginatorHelper paginatorHelper = new PaginatorHelper(tableHelper.X, tableHelper.CurrentY, Paginator);

            Action paginatorAction = new Action(() => {
                object[] parameters = new object[2];
                parameters[0] = searchText.Text.ToString();
                parameters[1] = Paginator;
                Router.Call("list_containers", parameters);
            });
            foreach (View view in paginatorHelper.Render(paginatorAction))
            {
                win.Add(view);
            }
        }

        /// <summary>
        ///     GetRows
        /// </summary>
        /// <returns>List</returns>
        private List<List<View>> GetRows()
        {
            List<List<View>> rows = new List<List<View>>();

            foreach (Container item in this.Containers)
            {
                Button editButton = new Button("Edit");
                Action editButtonEvent = new Action(() => {});
                editButton.Clicked = editButtonEvent;

                Button deleteButton = new Button("Delete");
                Action deleteButtonEvent = new Action(() => {
                    Container container = item;
                    object[] parameters = new object[1];
                    parameters[0] = container;
                    Router.Call("delete_container", parameters);
                });
                deleteButton.Clicked = deleteButtonEvent;

                rows.Add(new List<View>() { new Label($"#{item.container_id}"), new Label(item.name), new Label(item.type), editButton, deleteButton });
            }
            return rows;
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
    }
}
