// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="TestController.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests.Router.Controllers
{
    using System;
    using GtdApp.Logic.Attributes;
    using GtdApp.Logic.Interfaces;
    using GtdApp.Logic.Routing;
    using GtdApp.Logic.Tests.Router.Exceptions;

    /// <summary>
    ///     ContainerController
    /// </summary>
    public class TestController : IController
    {
        /// <summary>
        ///     DefaultRoute
        /// </summary>
        [DefaultRoute]

        [Route("DefaultRoute")]
        public void DefaultRoute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Create container
        /// </summary>
        [Route("TestRoute")]
        public void TestRoute()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Test controller with parameter
        /// </summary>
        /// <param name="id">Example parameter</param>
        [Route("TestRouteWithParameter")]
        public void TestRouteWithParameters(int id)
        {
            throw new TestRouteWithParametersPassedException(id.ToString());
        }

        /// <summary>
        ///     Test controller with an exception thrown
        /// </summary>
        [Route("TestRouteWithException")]
        public void TestRouteWithException()
        {
            throw new Exception("Test exception.");
        }
    }
}
