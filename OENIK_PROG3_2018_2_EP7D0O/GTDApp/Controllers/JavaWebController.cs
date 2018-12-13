// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="JavaWebController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using GTDApp.Console.Menu;
    using GTDApp.Console.Views;
    using GTDApp.ConsoleCore.Controllers;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Exceptions;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using System;

    /// <summary>
    ///     JavaWebController
    /// </summary>
    public class JavaWebController : AbstractController
    {
        public JavaWebController(BusinessLogic businessLogic, Router router) : base(businessLogic, router)
        {
        }

        /// <summary>
        ///     Create item
        /// </summary>
        [Route(MainMenuEnum.JAVA_WEB)]
        public void Index()
        {
            try
            {
                JavaWebView view = new JavaWebView()
                {
                    Router = this.Router
                };

                string javaWebUrl = "http://localhost:8080/GTDAppWebServer/GTDAppServlet";
                view.Response = Common.JSONApiCall(javaWebUrl);

                view.Render();
            }
            catch (JSONApiCallFailedException ex)
            {
                throw ex;
            }
        }
    }
}
