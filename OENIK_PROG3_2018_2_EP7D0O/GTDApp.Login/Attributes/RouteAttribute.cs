// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RouteAttribute.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Attributes
{
    using System;

    /// <summary>
    ///     RouteAttribute
    /// </summary>
    public class RouteAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteAttribute"/> class.
        /// RouteAttribute
        /// </summary>
        /// <param name="name">Name of route</param>
        public RouteAttribute(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets <see cref="Name"/>
        /// </summary>
        /// <value>The name of the router.</value>
        public string Name { get; set; }
    }
}
