// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="RouterTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests.Router
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.InteropServices;
    using GtdApp.Data;
    using GtdApp.Logic.Interfaces;
    using GtdApp.Logic.Routing;
    using GtdApp.Logic.Tests.Router.Controllers;
    using GtdApp.Logic.Tests.Router.Exceptions;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    ///      RouterTests
    /// </summary>
    public class RouterTests
    {
        /// <summary>
        ///      Gets or sets Router instance
        /// </summary>
        /// <value>Router</value>
        protected Router Router { get; set; }

        /// <summary>
        ///     The Setup of the RouterTests
        /// </summary>
        [SetUp]
        public void SetUp()
        {
            this.Router = new Router();
            this.Router.Controllers = new List<IController>()
            {
                new TestController()
            };
        }

        /// <summary>
        ///     CallRoute calls once the invoke method of a controller method
        /// </summary>
        [Test]
        public void DoesCallRouteInvokesMethod()
        {
            string routeName = "TestRoute";
            object[] parameters = null;
            Mock<_MethodInfo> method = new Mock<_MethodInfo>();
            method.Setup(x => x.Invoke(routeName, parameters)).Returns(true);

            Route route = new Route()
            {
                Controller = this.Router.Controllers.First(),
                Method = method.Object,
                Name = routeName,
                Parameters = parameters
            };

            this.Router.CallRoute(route, null);
            method.Verify(x => x.Invoke(route.Controller, route.Parameters), Times.Once);
        }

        /// <summary>
        ///     CallRoute invokes the appropriate method or throws exception.
        /// </summary>
        /// <param name="routeName">Route name to call</param>
        /// <param name="parameters">Parameters to pass with</param>
        [TestCase("TestRoute", new object[] { "asdsad" })]
        public void DoesCallRouteThrowsInvalidParameterException(string routeName, object[] parameters)
        {
            IController controller = this.Router.Controllers.First();
            Route route = new Route()
            {
                Controller = controller,
                Method = controller.GetType().GetMethod(routeName),
                Name = routeName,
                Parameters = parameters
            };

            Assert.That(() => this.Router.CallRoute(route, route.Parameters), Throws.TypeOf<TargetParameterCountException>());
        }

        /// <summary>
        ///     CallRoute invokes the appropriate method or throws exception.
        /// </summary>
        /// <param name="routeName">Route name to call</param>
        /// <param name="parameters">Parameters to pass with</param>
        [TestCase("TestRouteWithException", null)]
        public void DoesCallRouteThrowsException(string routeName, object[] parameters)
        {
            IController controller = this.Router.Controllers.First();
            Route route = new Route()
            {
                Controller = controller,
                Method = controller.GetType().GetMethod(routeName),
                Name = routeName,
                Parameters = parameters
            };

            Assert.That(() => this.Router.CallRoute(route, route.Parameters), Throws.TypeOf<Exception>());
        }

        /// <summary>
        ///     CallRoute invokes the appropriate method or throws exception.
        /// </summary>
        /// <param name="routeName">Route name to call</param>
        /// <param name="parameters">Parameters to pass with</param>
        [TestCase("TestRouteWithParameters", new object[] { 2 })]
        public void DoesCallRouteWithParametersPassesParameters(string routeName, object[] parameters)
        {
            IController controller = this.Router.Controllers.First();
            Route route = new Route()
            {
                Controller = controller,
                Method = controller.GetType().GetMethod(routeName),
                Name = routeName,
                Parameters = parameters
            };

            Assert.That(() => this.Router.CallRoute(route, route.Parameters), !Throws.TypeOf<TargetParameterCountException>());
            Assert.That(() => this.Router.CallRoute(route, route.Parameters), Throws.TypeOf<TestRouteWithParametersPassedException>());
        }
    }
}
