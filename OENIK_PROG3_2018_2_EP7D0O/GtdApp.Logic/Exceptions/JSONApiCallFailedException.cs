// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="JSONApiCallFailedException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Exceptions
{
    using System;

    /// <summary>
    ///     JSONApiCallFailedException
    /// </summary>
    public class JSONApiCallFailedException : Exception
    {
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
