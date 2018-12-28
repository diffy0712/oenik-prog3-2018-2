// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.ConsoleCore.View;
    using GTDApp.ConsoleCore.Views;
    using GTDApp.Data;
    using GTDApp.Logic.Interfaces;
    using System;
    using System.Linq;
    using Terminal.Gui;

    /// <summary>
    ///     DashboardView
    /// </summary>
    public class DashboardView : AbstractView
    {
        public int NumberOfContainers { get; set; }
        public int NumberOfItems { get; set; }

        /// <summary>
        ///     Content
        /// </summary>
        /// <param name="win">Window instance</param>
        protected override void Content(Window win)
        {
            win.Add(new Label($"Number of containers: {NumberOfContainers}") { X = 2, Y = 1 });
            Button addNewContainer = new Button(30, 1, "Add new Container");
            Action addNewContainerEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.CREATE_CONTAINER.ToString()); });
            addNewContainer.Clicked = addNewContainerEvent;
            Button listContainers = new Button(52, 1, "List Containers");
            Action listContainersEvent = new Action(() => { ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString()); });
            listContainers.Clicked = listContainersEvent;
            win.Add(addNewContainer);
            win.Add(listContainers);

            win.Add(new Label($"Number of items: {NumberOfItems}") { X = 2, Y = 3 });
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
