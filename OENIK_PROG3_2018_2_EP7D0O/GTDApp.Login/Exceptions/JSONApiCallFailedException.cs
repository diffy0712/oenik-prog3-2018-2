// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="JSONApiCallFailedException.cs" company="OENIK_PROG3_2018_2_EP7D0O">
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
    ///     JSONApiCallFailedException
    /// </summary>
    public class JSONApiCallFailedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="JSONApiCallFailedException"/> class.
        ///     JSONApiCallFailedException
        /// </summary>
        public JSONApiCallFailedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="JSONApiCallFailedException"/> class.
        ///     JSONApiCallFailedException
        /// </summary>
        /// <param name="message">Message string</param>
        public JSONApiCallFailedException(string message)
            : base(message)
        {
        }
    }
}
