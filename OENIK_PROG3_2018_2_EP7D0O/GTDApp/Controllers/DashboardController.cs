// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Controllers
{
    using System;
    using System.Linq;
    using GtdApp.Console.Views;
    using GtdApp.ConsoleCore;
    using GtdApp.Logic.Attributes;
    using GtdApp.Logic.Interfaces;
    using GtdApp.Logic.Routing;
    using GtdApp.Repository;

    /// <summary>
    ///     DashboardController
    /// </summary>
    public class DashboardController : IController
    {
        /// <summary>
        ///     DashboardController
        /// </summary>
        [DefaultRoute]
        [Route(RoutesEnum.DASHBOARD)]
        public void Index()
        {
            DashboardView view = new DashboardView();
            view.NumberOfContainers = ConsoleCore.BusinessLogic.ContainerRepository.GetAll().Count();
            view.NumberOfItems = ConsoleCore.BusinessLogic.ItemRepository.GetAll().Count();
            view.NumberOfNotifications = ConsoleCore.BusinessLogic.NotificationRepository.GetAll().Count();
            view.AggregatesByContainerType = ConsoleCore.BusinessLogic.ContainerRepository.GetAggregatesByContainerType(string.Empty, new Paginator());
            view.UpcomingNotifications = ConsoleCore.BusinessLogic.Item_NotificationRepository.GetUpcomingNotifications(string.Empty, new Paginator());
            view.AggregatesByNotificationType = ConsoleCore.BusinessLogic.NotificationRepository.GetAggregatesByNotificationType(string.Empty, new Paginator());
            view.Render();
        }
    }
}
