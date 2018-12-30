// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="NoRouteFoundException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Exceptions
{
    using System;

    /// <summary>
    ///     NoRouteFoundException
    /// </summary>
    public class NoRouteFoundException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoRouteFoundException"/> class.
        ///     NoRouteFoundException
        /// </summary>
        public NoRouteFoundException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NoRouteFoundException"/> class.
        ///     NoRouteFoundException
        /// </summary>
        /// <param name="message">Message string</param>
        public NoRouteFoundException(string message)
            : base(message)
        {
        }
    }
}
