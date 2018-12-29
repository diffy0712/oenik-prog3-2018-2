// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RoutesEnum.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console
{
    /// <summary>
    ///     Available routes to call
    /// </summary>
    internal enum RoutesEnum
    {
        /// <summary>
        ///     DASHBOARD
        /// </summary>
        DASHBOARD,

        /// <summary>
        ///     List containers
        /// </summary>
        LIST_CONTAINERS,

        /// <summary>
        ///     Create container route
        /// </summary>
        CREATE_CONTAINER,

        /// <summary>
        ///     Manage container action route
        /// </summary>
        MANAGE_CONTAINER_ACTION,

        /// <summary>
        ///     Update container route
        /// </summary>
        UPDATE_CONTAINER,

        /// <summary>
        ///     Delete container route
        /// </summary>
        DELETE_CONTAINER,

        /// <summary>
        ///     List items route
        /// </summary>
        LIST_ITEMS,

        /// <summary>
        ///     Create item route
        /// </summary>
        CREATE_ITEM,

        /// <summary>
        ///     Manage item action route
        /// </summary>
        MANAGE_ITEM_ACTION,

        /// <summary>
        ///     Update item route
        /// </summary>
        UPDATE_ITEM,

        /// <summary>
        ///     Delete item route
        /// </summary>
        DELETE_ITEM,

        /// <summary>
        ///     List notificaions route
        /// </summary>
        LIST_NOTIFICATIONS,

        /// <summary>
        ///     Create notificaion route
        /// </summary>
        CREATE_NOTIFICATION,

        /// <summary>
        ///     Manage notificaion action route
        /// </summary>
        MANAGE_NOTIFICATION_ACTION,

        /// <summary>
        ///     Update notificaion route
        /// </summary>
        UPDATE_NOTIFICATION,

        /// <summary>
        ///     Delete notification route
        /// </summary>
        DELETE_NOTIFICATION,

        /// <summary>
        ///     Java web route
        /// </summary>
        JAVA_WEB,

        /// <summary>
        ///     Fatal error route
        /// </summary>
        FATAL_ERROR,

        /// <summary>
        ///     Exception handler error route
        /// </summary>
        EXCEPTION_ERROR,

        /// <summary>
        ///     Default error route
        /// </summary>
        DEFAULT_ERROR
    }
}
