// <summary>
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
    public static class MainMenu
    {
        /// <summary>
        ///     Menu Instance
        /// </summary>
        private static Menu Menu;

        /// <summary>
        ///     GetMenu
        /// </summary>
        /// <returns>Menu</returns>
        public static Menu GetMenu()
        {
            Menu = new Menu();
            MenuItem fileMenuItem = new MenuItem() { Name = "_File" };
            fileMenuItem.Items.Add(new MenuItem() { RouteName = "dashboard" , Name = "_Dashboard" });
            fileMenuItem.Items.Add(new MenuItem() { RouteName = "review", Name = "_Review" });
            fileMenuItem.Items.Add(new MenuItem() { RouteName = "quit", Name = "_Quit" });

            Menu.Items.Add(fileMenuItem);

            MenuItem crudMenuItem = new MenuItem() { Name = "_CRUD And Java API" };
            crudMenuItem.Items.Add(new MenuItem() { RouteName = "list_containers", Name = "_List Containers" });
            crudMenuItem.Items.Add(new MenuItem() { RouteName = "java_web", Name = "Java Web" });

            Menu.Items.Add(crudMenuItem);

            return Menu;
        }
    }
}
