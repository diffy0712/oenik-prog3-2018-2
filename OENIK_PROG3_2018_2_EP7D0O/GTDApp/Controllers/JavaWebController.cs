// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="JavaWebController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using GTDApp.Console.Views;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;

    /// <summary>
    ///     JavaWebController
    /// </summary>
    public class JavaWebController : IController
    {
        /// <summary>
        ///     Create item
        /// </summary>
        [Route("java_web")]
        public void Index()
        {
            JavaWebView view = new JavaWebView();

            string javaWebUrl = "http://localhost:8080/GTDAppWebServer/GTDAppServlet";
            view.Response = BusinessLogic.JavaWebCall(javaWebUrl);

            view.Render();
        }
    }
}
