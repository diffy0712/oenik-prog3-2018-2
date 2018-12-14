// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DashboardController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System.Linq;
    using GTDApp.Console.Views;
    using GTDApp.ConsoleCore;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;

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
            view.Render();
        }
    }
}
