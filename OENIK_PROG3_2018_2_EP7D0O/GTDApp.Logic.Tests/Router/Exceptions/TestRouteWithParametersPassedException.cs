// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="TestRouteWithParametersPassedException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests.Router.Exceptions
{
    using System;

    /// <summary>
    ///     TestRouteWithParametersPassedException
    /// </summary>
    public class TestRouteWithParametersPassedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TestRouteWithParametersPassedException"/> class.
        ///     TestRouteWithParametersPassedException
        /// </summary>
        /// <param name="message">Message string</param>
        public TestRouteWithParametersPassedException(string message)
            : base(message)
        {
        }
    }
}
