// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RouterHelperTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using GtdApp.Data;
    using GtdApp.Logic.Exceptions;
    using GtdApp.Logic.Interfaces;
    using GtdApp.Logic.Routing;
    using GtdApp.Logic.Tests.Controllers;
    using Moq;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    /// <summary>
    ///      RouterHelperTests
    ///      GtdApp.Logic.Tests.Controllers
    /// </summary>
    public class RouterHelperTests
    {
        /// <summary>
        ///     Tests if the method returns the approprate controllers
        /// </summary>
        [Test]
        public void DoesLoadControllersFromDLLNamespaceReturnControllerInstances()
        {
            Assert.That(RouterHelper.LoadControllersFromDLLNamespace("GtdApp.Logic.Tests.Controllers", null), !Is.Empty);
        }

        /// <summary>
        ///     DoesGetRouteToInvokeFindDefault
        /// </summary>
        [Test]
        public void DoesGetRouteToInvokeFindsDefault()
        {
            List<IController> controllers = new List<IController>()
            {
                new TestController()
            };
            Assert.That(RouterHelper.GetRouteToInvoke(controllers, null), Is.InstanceOf(typeof(Route)));
        }

        /// <summary>
        ///     DoesGetRouteToInvokeFindDefault
        /// </summary>
        /// <param name="controllerName">Controller name to test with</param>
        [TestCase("TestRoute")]
        public void DoesGetRouteToInvokeFindsNamedRoute(string controllerName)
        {
            List<IController> controllers = new List<IController>()
            {
                new TestController()
            };
            Assert.That(RouterHelper.GetRouteToInvoke(controllers, controllerName), Is.InstanceOf(typeof(Route)));
            Assert.That(RouterHelper.GetRouteToInvoke(controllers, controllerName).Method.Name, !Is.EqualTo("DefaultRoute"));
        }

        /// <summary>
        ///     DoesGetRouteToInvokeThrowsExceptionOnNotExistingRoute
        /// </summary>
        [Test]
        public void DoesGetRouteToInvokeThrowsExceptionOnNotExistingRoute()
        {
            List<IController> controllers = new List<IController>()
            {
                new EmptyController()
            };

            Assert.That(() => RouterHelper.GetRouteToInvoke(controllers, "NottExistingRoute"), Throws.TypeOf<NoRouteFoundException>());
        }
    }
}
