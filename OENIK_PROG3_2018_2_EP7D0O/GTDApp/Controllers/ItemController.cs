// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ItemController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using GTDApp.Console.Menu;
    using GTDApp.ConsoleCore.Controllers;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;

    /// <summary>
    ///     ItemController
    /// </summary>
    public class ItemController : AbstractController
    {
        public ItemController(BusinessLogic businessLogic, Router router) : base(businessLogic, router)
        {
        }

        /// <summary>
        ///     Create item
        /// </summary>
        [Route(RoutesEnum.LIST_ITEMS)]
        public void Create()
        {
        }

        /// <summary>
        ///     Update item
        /// </summary>
        [Route(RoutesEnum.UPDATE_ITEM)]
        public void Update()
        {
        }

        /// <summary>
        ///     Delete item
        /// </summary>
        [Route(RoutesEnum.DELETE_ITEM)]
        public void Delete()
        {
        }
    }
}
