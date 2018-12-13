// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Interfaces
{
    using GTDApp.Logic.Routing;

    /// <summary>
    ///     IController
    /// </summary>
    public interface IController
    {
        /// <summary>
        ///     Gets or sets BusinessLogic<see cref="BusinessLogic"/>
        /// </summary>
        /// <value>BusinessLogic</value>
        BusinessLogic BusinessLogic
        {
            get;
            set;
        }

        /// <summary>
        ///     Gets or sets Router<see cref="Router"/>
        /// </summary>
        /// <value>Router</value>
        Router Router
        {
            get;
            set;
        }
    }
}
