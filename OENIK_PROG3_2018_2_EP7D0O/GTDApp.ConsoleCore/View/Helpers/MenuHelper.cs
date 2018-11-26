// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="MainMenuBar.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views
{
    using GTDApp.ConsoleCore.Menu;
    using GTDApp.Logic;
    using GUI = Terminal.Gui;

    /// <summary>
    ///     MenuHelper
    /// </summary>
    public class MenuHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MenuHelper"/> class.
        ///     MenuHelper
        /// </summary>
        /// <param name="top">Top level element</param>
        /// <param name="menu">Menu</param>
        public MenuHelper(GUI.Toplevel top, Menu menu)
        {
            GUI.MenuBarItem[] menubarItems = new GUI.MenuBarItem[menu.Items.Count];

            for (int i = 0; i < menu.Items.Count; i++)
            {
                GUI.MenuItem[] menuItemChildren = new GUI.MenuItem[menu.Items[i].Items.Count];

                for (int k = 0; k < menu.Items[i].Items.Count; k++)
                {
                    MenuItem menuItem = menu.Items[i].Items[k];
                    menuItemChildren[k] = new GUI.MenuItem(menuItem.Name, string.Empty, () => { Router.Call(menuItem.RouteName); });
                }

                GUI.MenuBarItem menuBarItem = new GUI.MenuBarItem(menu.Items[i].Name, menuItemChildren);

                menubarItems[i] = menuBarItem;
            }

            GUI.MenuBar menuBar = new GUI.MenuBar(menubarItems);

            top.Add(menuBar);
        }
    }
}
