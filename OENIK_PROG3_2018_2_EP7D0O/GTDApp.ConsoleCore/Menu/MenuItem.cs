// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="MenuItem.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
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
        /// Initializes a new instance of the <see cref="MenuItem"/> class.
        ///     MenuItem
        /// </summary>
        public MenuItem()
        {
            this.Items = new List<MenuItem>();
        }

        /// <summary>
        ///     Gets or sets Items
        /// </summary>
        /// <value>List of MenuItem</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Items
        /// </summary>
        /// <value>List of MenuItem</value>
        public string RouteName { get; set; }

        /// <summary>
        ///     Gets or sets Items
        /// </summary>
        /// <value>List of MenuItem</value>
        public List<MenuItem> Items { get; set; }
    }
}
