// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="AbstractController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Controllers
{
    using System;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using Terminal.Gui;

    /// <summary>
    ///     AbstractController
    /// </summary>
    public abstract class AbstractController : IController
    {
        public AbstractController(BusinessLogic businessLogic, Router router)
        {
            BusinessLogic = businessLogic;
            Router = router;
        }

        public BusinessLogic BusinessLogic { get; set; }
        public Router Router { get; set; }
    }
}
