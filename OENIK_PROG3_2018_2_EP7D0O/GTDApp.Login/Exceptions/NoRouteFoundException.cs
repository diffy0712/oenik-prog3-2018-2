// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="NoRouteFoundException.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
