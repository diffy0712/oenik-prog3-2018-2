// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RoutesEnum.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    ///     Available routes to call
    /// </summary>
    internal enum RoutesEnum
    {
        DASHBOARD,
        SETTINGS,
        REVIEW,
        QUIT,
        LIST_CONTAINERS,
        CREATE_CONTAINER,
        UPDATE_CONTAINER,
        DELETE_CONTAINER,
        LIST_ITEMS,
        UPDATE_ITEM,
        DELETE_ITEM,
        JAVA_WEB,
        FATAL_ERROR,
        EXCEPTION_ERROR
    }
}
