// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Menu.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Menu
{
    using System.Collections.Generic;

    /// <summary>
    ///     Menu
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        ///     Menu
        /// </summary>
        public Menu()
        {
            this.Items = new List<MenuItem>();
        }

        /// <summary>
        ///     Gets or sets Items
        /// </summary>
        /// <value>List of MenuItem</value>
        public List<MenuItem> Items { get; set; }
    }
}
