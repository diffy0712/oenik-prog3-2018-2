// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Route.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Routing
{
    using System.Reflection;
    using GTDApp.Logic.Interfaces;

    /// <summary>
    ///         Route
    /// </summary>
    public class Route
    {
        /// <summary>
        ///         Controller class
        /// </summary>
        public IController Controller { get; set; }

        /// <summary>
        ///         Name of the route
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///         Method to call from class
        /// </summary>
        public MethodInfo Method { get; set; }

        /// <summary>
        ///         Parameters to pass to the method invoke
        /// </summary>
        public object[] Parameters { get; set; }
    }
}
