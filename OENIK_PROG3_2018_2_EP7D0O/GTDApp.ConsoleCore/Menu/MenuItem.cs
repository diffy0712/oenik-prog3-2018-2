// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="MenuItem.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Menu
{
    using System.Collections.Generic;
 
    /// <summary>
    ///     MenuItem
    /// </summary>
    public class MenuItem
    {
        /// <summary>
        ///     Name
        /// </summary>
        public string Name;

        /// <summary>
        ///     RouteName
        /// </summary>
        public string RouteName;

        /// <summary>
        ///     Items
        /// </summary>
        public List<MenuItem> Items;

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        ///     MenuItem
        /// </summary>
        public MenuItem()
        {
            this.Items = new List<MenuItem>();
        }
    }
}
