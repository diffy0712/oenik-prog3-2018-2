// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ReviewController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>


namespace GTDApp.Console.Controllers
{
    using GTDApp.Console.Attributes;
    using GTDApp.Console.Views;
    using Terminal.Gui;

    /// <summary>
    ///     ReviewController
    /// </summary>
    public class ReviewController : IController
    {
        /// <summary>
        ///     Index containers
        /// </summary>
        /// <param name="top">Top Level</param>
        /// <returns>Window</returns>
        [Route("review")]
        public Window Index()
        {
            ReviewView reviewView = new ReviewView();
            return reviewView.Render();
        }
    }
}
