// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="SettingsController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using GTDApp.Console.Menu;
    using GTDApp.Console.Views;
    using GTDApp.ConsoleCore.Controllers;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;

    /// <summary>
    ///     SettingsController
    /// </summary>
    public class SettingsController : AbstractController
    {
        public SettingsController(BusinessLogic businessLogic, Router router) : base(businessLogic, router)
        {
        }

        /// <summary>
        ///     SettingsController
        /// </summary>
        [Route(RoutesEnum.SETTINGS)]
        public void Index()
        {
            SettingsView view = new SettingsView()
            {
                Router = this.Router
            };
            view.Render();
        }
    }
}
