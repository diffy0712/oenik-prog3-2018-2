// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ReviewController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
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
    ///     ReviewController
    /// </summary>
    public class ReviewController : AbstractController
    {
        public ReviewController(BusinessLogic businessLogic, Router router) : base(businessLogic, router)
        {
        }

        /// <summary>
        ///     Index containers
        /// </summary>
        [Route(RoutesEnum.REVIEW)]
        public void Index()
        {
            ReviewView reviewView = new ReviewView()
            {
                Router = this.Router
            };
            reviewView.Render();
        }
    }
}
