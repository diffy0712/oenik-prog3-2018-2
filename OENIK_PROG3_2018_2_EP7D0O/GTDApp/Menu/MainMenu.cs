// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="MainMenu.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Menu
{
    using GtdApp.ConsoleCore.Menu;

    /// <summary>
    ///     MainMenu
    /// </summary>
    public class MainMenu : IMenu
    {
        /// <summary>
        ///    Menu
        /// </summary>
        /// <value>Menu instnace</value>
        private Menu menu;

        /// <summary>
        ///     GetMenu
        /// </summary>
        /// <returns>Menu</returns>
        public Menu GetMenu()
        {
            this.menu = new Menu();
            MenuItem fileMenuItem = new MenuItem() { Name = "_File" };
            fileMenuItem.Items.Add(new MenuItem() { RouteName = RoutesEnum.DASHBOARD.ToString(), Name = "_Dashboard" });

            this.menu.Items.Add(fileMenuItem);

            MenuItem crudMenuItem = new MenuItem() { Name = "_GTD" };
            crudMenuItem.Items.Add(new MenuItem() { RouteName = RoutesEnum.LIST_CONTAINERS.ToString(), Name = "_List Containers" });
            crudMenuItem.Items.Add(new MenuItem() { RouteName = RoutesEnum.LIST_NOTIFICATIONS.ToString(), Name = "_List Notofications" });

            this.menu.Items.Add(crudMenuItem);

            return this.menu;
        }
    }
}
