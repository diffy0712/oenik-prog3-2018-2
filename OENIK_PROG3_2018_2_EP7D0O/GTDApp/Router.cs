// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Router.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GTDApp.Console.Attributes;
    using GTDApp.Console.Controllers;
    using GTDApp.Console.Views;
    using Terminal.Gui;
    using Attribute = System.Attribute;

    /// <summary>
    ///     Router
    /// </summary>
    public class Router
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Router"/> class.
        ///     Router
        /// </summary>
        /// <returns>bool</returns>
        public Router()
        {
            this.Controllers = new List<IController>();
            this.LoadDLL();
        }

        /// <summary>
        ///     Call Controller
        /// </summary>
        /// <param name="top">Toplevel element</param>
        public void Call(Toplevel top)
        {
            this.Call(top, null);
        }

        /// <summary>
        ///     Call Controller
        /// </summary>
        /// <param name="top">Toplevel element</param>
        /// <param name="controllerName">ControllerName</param>
        public void Call(Toplevel top, string controllerName = null)
        {
            MainMenuBar mainMenuBar = new MainMenuBar();

            Window win = null;

            var tframe = top.Frame;
            var ntop = new Toplevel(tframe);

            ntop.Add(mainMenuBar.Render(ntop, this));

            foreach (IController controller in this.Controllers)
            {
                var methods = controller.GetType().GetMethods();
                foreach (MethodInfo methodInfo in methods)
                {
                    var allCustomAttributes = methodInfo.GetCustomAttributes();
                    foreach (Attribute customAttribute in allCustomAttributes)
                    {
                        if (controllerName is null && customAttribute is DefaultAttribute)
                        {
                            win = methodInfo.Invoke(controller, null) as Window;
                            continue;
                        }

                        if (customAttribute is RouteAttribute)
                        {
                            RouteAttribute routeAttribute = customAttribute as RouteAttribute;

                            if (routeAttribute.Name == controllerName)
                            {
                                win = methodInfo.Invoke(controller, null) as Window;
                                continue;
                            }
                        }
                    }
                }
            }

            if (win == null)
            {
                ErrorController controller = new ErrorController();
                win = controller.Fatal($"No controller ({controllerName}) found!");
            }

            ntop.Add(win);

            Application.Run(ntop);
        }

        /// <summary>
        ///     Controllers
        /// </summary>
        /// <returns>List</returns>
        private List<IController> Controllers;

        /// <summary>
        ///     Router
        /// </summary>
        private void LoadDLL()
        {
            string nspace = "GTDApp.Console.Controllers";

            var q = from t in Assembly.GetExecutingAssembly().GetTypes()
                    where t.IsClass && t.Namespace == nspace
                    select t;
            foreach (Type aktType in q)
            {
                if (aktType.GetInterface(nameof(IController)) != null)
                {
                    object instance = Activator.CreateInstance(aktType);
                    this.Controllers.Add(instance as IController);
                }
            }
        }
    }
}
