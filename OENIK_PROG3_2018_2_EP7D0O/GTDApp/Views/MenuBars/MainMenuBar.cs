// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="MainMenuBar.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using GTDApp.Console.Controllers;
    using GTDApp.Console.Views.Helpers;
    using Terminal.Gui;

    /// <summary>
    ///     MainMenuBar
    /// </summary>
    public class MainMenuBar
    {
        /// <summary>
        ///     render
        /// </summary>
        /// <param name="top">Top level element</param>
        /// <returns>MenuBar</returns>
        public MenuBar Render(Toplevel top)
        {
            DashboardController dashboardController = new DashboardController();
            ReviewController reviewController = new ReviewController();
            ContainerController containerController = new ContainerController();
            string[][] menu = new string[2][];
            menu[0] = new string[4];
            menu[0][0] = "_File";
            menu[0][1] = "dashboard";
            menu[0][2] = "review";
            menu[0][3] = "quit";
            menu[1] = new string[3];
            menu[1][0] = "_CRUD And Java API";
            menu[1][1] = "list_containers";
            menu[1][2] = "java_web";

            MenuBarItem[] menubarItems = new MenuBarItem[menu.Length];

            for (int i = 0; i < menu.Length; i++)
            {
                MenuItem[] menuItemChildren = new MenuItem[menu[i].Length - 1];

                for (int k = 1; k < menu[i].Length; k++)
                {
                    string routeName = menu[i][k].ToString();
                    menuItemChildren[k - 1] = new MenuItem(routeName, string.Empty, () => { Router.Call(routeName); });
                }

                MenuBarItem menuBarItem = new MenuBarItem(menu[i][0], menuItemChildren);

                menubarItems[i] = menuBarItem;
            }

            MenuBar menuBar = new MenuBar(menubarItems);

            return menuBar;
        }
    }
}
