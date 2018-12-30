﻿// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="MainMenu.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Menu
{
    using GTDApp.ConsoleCore.Menu;

    /// <summary>
    ///     MainMenu
    /// </summary>
    public class MainMenu : IMenu
    {
        /// <summary>
        ///    Menu
        /// </summary>
        /// <value>Menu instnace</value>
        private Menu _menu;

        /// <summary>
        ///     GetMenu
        /// </summary>
        /// <returns>Menu</returns>
        public Menu GetMenu()
        {
            this._menu = new Menu();
            MenuItem fileMenuItem = new MenuItem() { Name = "_File" };
            fileMenuItem.Items.Add(new MenuItem() { RouteName = RoutesEnum.DASHBOARD.ToString(), Name = "_Dashboard" });
            fileMenuItem.Items.Add(new MenuItem() { RouteName = RoutesEnum.JAVA_WEB.ToString(), Name = "_Java Web" });

            this._menu.Items.Add(fileMenuItem);

            MenuItem crudMenuItem = new MenuItem() { Name = "_GTD" };
            crudMenuItem.Items.Add(new MenuItem() { RouteName = RoutesEnum.LIST_CONTAINERS.ToString(), Name = "_List Containers" });
            crudMenuItem.Items.Add(new MenuItem() { RouteName = RoutesEnum.LIST_NOTIFICATIONS.ToString(), Name = "_List Notofications" });

            this._menu.Items.Add(crudMenuItem);

            return this._menu;
        }
    }
}
