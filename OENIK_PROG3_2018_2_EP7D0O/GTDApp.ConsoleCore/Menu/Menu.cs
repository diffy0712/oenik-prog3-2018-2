// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Menu.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
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
        ///     items
        /// </summary>
        public List<MenuItem> Items;

        /// <summary>
        /// Initializes a new instance of the <see cref="Menu"/> class.
        ///     Menu
        /// </summary>
        public Menu()
        {
            this.Items = new List<MenuItem>();
        }
    }
}
