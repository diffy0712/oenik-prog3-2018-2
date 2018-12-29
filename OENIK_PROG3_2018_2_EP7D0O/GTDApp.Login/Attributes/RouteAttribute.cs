// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RouteAttribute.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Logic.Attributes
{
    using System;

    /// <summary>
    ///     RouteAttribute
    /// </summary>
    public class RouteAttribute : AbstractRouteAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RouteAttribute"/> class.
        /// RouteAttribute
        /// </summary>
        /// <param name="name">Name of route</param>
        public RouteAttribute(object name)
        {
            this.Name = name;
        }

        /// <summary>
        /// Gets or sets <see cref="Name"/>
        /// </summary>
        /// <value>The unique object of the router.</value>
        public object Name { get; set; }
    }
}
