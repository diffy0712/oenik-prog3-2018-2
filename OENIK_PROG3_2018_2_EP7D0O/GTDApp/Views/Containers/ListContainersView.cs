// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ListContainersView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Views.Helpers;
    using GTDApp.Data;
    using GTDApp.Repository;
    using System;
    using System.Collections.Generic;
    using Terminal.Gui;

    /// <summary>
    ///     ListContainersView
    /// </summary>
    public class ListContainersView : IView
    {
        IEnumerable<Container> Containers;

        public ListContainersView(IEnumerable<Container> containers)
        {
            this.Containers = containers;
        }

        /// <summary>
        ///     render the view
        /// </summary>
        public void Render()
        {
            MainMenuBar mainMenuBar = new MainMenuBar();
            var tframe = Application.Top.Frame;
            var ntop = new Toplevel(tframe);

            ntop.Add(mainMenuBar.Render(ntop));

            var win = new Window("List Container")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

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
            List<Dictionary<string,string>> headers = new List<Dictionary<string, string>>
            {
                idDictionary,
                nameDictionary,
                typeDictionary,
                editDictionary,
                deleteDictionary,
            };

            List<List<View>> rows = this.GetRows();
            TableHelper tableHelper = new TableHelper(2,1, headers, rows);
            foreach (View view in tableHelper.Render())
            {
                win.Add(view);
            }

            Button addNew = new Button(96, 0, "Add new Container");
            Action addNewEvent = new Action(() => { Router.Call("create_container"); });
            addNew.Clicked = addNewEvent;
            win.Add(addNew);

            ntop.Add(win);

            Application.Run(ntop);
        }

        private List<List<View>> GetRows()
        {
            List<List<View>> rows = new List<List<View>>();

            foreach (Container item in this.Containers)
            {
                Button editButton = new Button("Edit");
                Action editButtonEvent = new Action(() => { });
                editButton.Clicked = editButtonEvent;

                Button deleteButton = new Button("Delete");
                Action deleteButtonEvent = new Action(() => { });
                deleteButton.Clicked = deleteButtonEvent;

                rows.Add(new List<View>() { new Label($"#{item.container_id}"), new Label(item.name), new Label(item.type), editButton, deleteButton });
            }
            return rows;
        }
    }


}
