// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ItemController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;

    /// <summary>
    ///     ItemController
    /// </summary>
    public class ItemController : IController
    {
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
