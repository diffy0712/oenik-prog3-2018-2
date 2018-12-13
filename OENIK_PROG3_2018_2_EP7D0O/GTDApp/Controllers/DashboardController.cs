// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using System.Linq;
    using GTDApp.Console.Menu;
    using GTDApp.Console.Views;
    using GTDApp.ConsoleCore.Controllers;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using Terminal.Gui;

    /// <summary>
    ///     DashboardController
    /// </summary>
    public class DashboardController : AbstractController
    {
        public DashboardController(BusinessLogic businessLogic, Router router) : base(businessLogic, router)
        {
        }

        /// <summary>
        ///     DashboardController
        /// </summary>
        [DefaultRoute]
        [Route(RoutesEnum.DASHBOARD)]
        public void Index()
        {
            DashboardView view = new DashboardView() {
                Router = this.Router
            };

            view.NumberOfContainers = BusinessLogic.ContainerRepository.GetAll().Count();
            view.Render();
        }
    }
}
