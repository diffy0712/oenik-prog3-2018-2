// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="NotificationController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using System.Collections.Generic;
    using GTDApp.Console.Views;
    using GTDApp.Console.Views.Containers;
    using GTDApp.Console.Views.Modals;
    using GTDApp.Console.Views.Notifications;
    using GTDApp.ConsoleCore;
    using GTDApp.Data;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     ContainerController
    /// </summary>
    public class NotificationController : IController
    {
        /// <summary>
        ///     List notifications
        /// </summary>
        /// <param name="search">String to search for</param>
        /// <param name="paginator">Paginator Object</param>
        [Route(RoutesEnum.LIST_NOTIFICATIONS)]
        public void List(string search = null, Paginator paginator = null)
        {
            search = search is null ? string.Empty : search;
            paginator = paginator is null ? new Paginator() : paginator;
            var notifications = ConsoleCore.BusinessLogic.NotificationRepository.SearchAll(search, paginator);

            ListNotificationsView listView = new ListNotificationsView()
            {
                Notifications = notifications,
                Paginator = paginator,
                Search = search
            };
            listView.Render();
        }

        /// <summary>
        ///     Create container
        /// </summary>
        [Route(RoutesEnum.CREATE_NOTIFICATION)]
        public void Create()
        {
            ManageNotificationView manageView = new ManageNotificationView();

            Notification notification = new Notification();
            notification.name = string.Empty;
            notification.amount = 0;
            notification.unit = string.Empty;
            notification.type = string.Empty;

            manageView.Notification = notification;
            manageView.Creation = true;

            manageView.Render();
        }

        /// <summary>
        ///     Update notification
        /// </summary>
        /// <param name="notification">Notification instance</param>
        [Route(RoutesEnum.UPDATE_NOTIFICATION)]
        public void Update(Notification notification)
        {
            ManageNotificationView manageView = new ManageNotificationView();
            manageView.Notification = notification;
            manageView.Creation = false;

            manageView.Render();
        }

        /// <summary>
        ///     Create action
        /// </summary>
        /// <param name="notification">Notification instance</param>
        [Route(RoutesEnum.MANAGE_NOTIFICATION_ACTION)]
        public void ManageAction(Notification notification)
        {
            List<string> validation = ConsoleCore.BusinessLogic.SaveNotification(notification);

            if (validation == null)
            {
                ConsoleCore.CallRoute(RoutesEnum.LIST_NOTIFICATIONS.ToString(), new object[] { null, null });
            }
            else
            {
                ValidationErrorMessageModalView validationErrorMessageModalView = new ValidationErrorMessageModalView();
                validationErrorMessageModalView.Render();
            }
        }

        /// <summary>
        ///     Delete notification
        /// </summary>
        /// <param name="notification">Notification instance</param>
        [Route(RoutesEnum.DELETE_NOTIFICATION)]
        public void Delete(Notification notification)
        {
            Action deleteAction = null;

            if (BusinessLogic.IsNotificationRemovable(notification))
            {
                deleteAction = new Action(() =>
                {
                    ConsoleCore.BusinessLogic.RemoveNotification(notification);
                    Application.RequestStop();
                    ConsoleCore.CallRoute(RoutesEnum.LIST_NOTIFICATIONS.ToString());
                });
            }

            DeleteNotificationView deleteView = new DeleteNotificationView() { Notification = notification, DeleteAction = deleteAction };
            deleteView.Render();
        }
    }
}
