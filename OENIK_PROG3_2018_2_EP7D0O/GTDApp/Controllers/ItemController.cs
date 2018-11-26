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

    /// <summary>
    ///     ItemController
    /// </summary>
    public class ItemController : IController
    {
        /// <summary>
        ///     Create item
        /// </summary>
        [Route("create_item")]
        public void Create()
        {
        }

        /// <summary>
        ///     Update item
        /// </summary>
        [Route("update_item")]
        public void Update()
        {
        }

        /// <summary>
        ///     Delete item
        /// </summary>
        [Route("delete_item")]
        public void Delete()
        {
        }
    }
}
