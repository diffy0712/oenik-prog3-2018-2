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
        // Dashboard
        DASHBOARD,
        // Containers
        LIST_CONTAINERS,
        CREATE_CONTAINER,
        MANAGE_CONTAINER_ACTION,
        UPDATE_CONTAINER,
        DELETE_CONTAINER,
        // Items
        LIST_ITEMS,
        CREATE_ITEM,
        MANAGE_ITEM_ACTION,
        UPDATE_ITEM,
        DELETE_ITEM,
        // Notifications
        LIST_NOTIFICATIONS,
        CREATE_NOTIFICATION,
        MANAGE_NOTIFICATION_ACTION,
        UPDATE_NOTIFICATION,
        DELETE_NOTIFICATION,
        // Java API Call
        JAVA_WEB,
        // Errors
        FATAL_ERROR,
        EXCEPTION_ERROR,
        DEFAULT_ERROR
    }
}
