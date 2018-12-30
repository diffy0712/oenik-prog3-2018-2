// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="NullExceptionHandler.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Exceptions
{
    using System;
    using GtdApp.ConsoleCore.Interfaces;

    /// <summary>
    ///     NullExceptionHandler
    /// </summary>
    public class NullExceptionHandler : IExceptionHandler
    {
        /// <summary>
        ///     Handle
        /// </summary>
        /// <param name="callback">callback function</param>
        public void Handle(Action callback)
        {
            callback();
        }
    }
}
