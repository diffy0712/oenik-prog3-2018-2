// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="MenuHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.ConsoleCore.Views
{
    using GtdApp.ConsoleCore.Menu;
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
                    menuItemChildren[k] = new GUI.MenuItem(
                        menuItem.Name,
                        string.Empty,
                        () =>
                        {
                            ConsoleCore.CallRoute(menuItem.RouteName);
                        });
                }

                GUI.MenuBarItem menuBarItem = new GUI.MenuBarItem(menu.Items[i].Name, menuItemChildren);

                menubarItems[i] = menuBarItem;
            }

            GUI.MenuBar menuBar = new GUI.MenuBar(menubarItems);

            top.Add(menuBar);
        }
    }
}
