// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Route.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Routing
{
    using System.Reflection;
    using System.Runtime.InteropServices;
    using GtdApp.Logic.Interfaces;

    /// <summary>
    ///         Route
    /// </summary>
    public class Route
    {
        /// <summary>
        ///     Gets or sets Controller
        /// </summary>
        /// <value>IController</value>
        public IController Controller { get; set; }

        /// <summary>
        ///     Gets or sets Name
        /// </summary>
        /// <value>string</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Method
        /// </summary>
        /// <value>_MethodInfo</value>
        public _MethodInfo Method { get; set; }

        /// <summary>
        ///     Gets or sets Parameters
        /// </summary>
        /// <value>object[]</value>
        public object[] Parameters { get; set; }
    }
}
