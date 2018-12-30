// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="JavaWebController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Controllers
{
    using GtdApp.Console.Views;
    using GtdApp.ConsoleCore;
    using GtdApp.Logic;
    using GtdApp.Logic.Attributes;
    using GtdApp.Logic.Exceptions;
    using GtdApp.Logic.Interfaces;
    using GtdApp.Logic.Routing;

    /// <summary>
    ///     JavaWebController
    /// </summary>
    public class JavaWebController : IController
    {
        /// <summary>
        ///     Create item
        /// </summary>
        [Route(RoutesEnum.JAVA_WEB)]
        public void Index()
        {
            JavaWebView view = new JavaWebView();

            string javaWebUrl = "http://localhost:8080/GTDAppWebServer/GTDAppServlet";
            view.Response = ConsoleCore.BusinessLogic.GenerateItemsFromJSON(Common.JSONApiCall(javaWebUrl));

            view.Render();
        }
    }
}
