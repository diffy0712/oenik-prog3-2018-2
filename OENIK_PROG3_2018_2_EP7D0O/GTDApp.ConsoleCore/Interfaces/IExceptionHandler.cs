// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IExceptionHandler.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.ConsoleCore.Interfaces
{
    using System;

    /// <summary>
    ///     IExceptionHandler
    /// </summary>
    public interface IExceptionHandler
    {
        /// <summary>
        ///     Handle
        /// </summary>
        /// <param name="callback">callback function</param>
        void Handle(Action callback);
    }
}
