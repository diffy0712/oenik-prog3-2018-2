// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="JavaWebCallFailedException.cs" company="OENIK_PROG3_2018_2_EP7D0O">
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
    ///     JavaWebCallFailedException
    /// </summary>
    public class JavaWebCallFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JavaWebCallFailedException"/> class.
        ///     JavaWebCallFailedException
        /// </summary>
        public JavaWebCallFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JavaWebCallFailedException"/> class.
        ///     JavaWebCallFailedException
        /// </summary>
        /// <param name="message">Message string</param>
        public JavaWebCallFailedException(string message)
            : base(message)
        {
        }
    }
}
