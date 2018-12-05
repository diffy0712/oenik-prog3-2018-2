// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IExceptionHandler.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>



namespace GTDApp.Logic.Interfaces
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
