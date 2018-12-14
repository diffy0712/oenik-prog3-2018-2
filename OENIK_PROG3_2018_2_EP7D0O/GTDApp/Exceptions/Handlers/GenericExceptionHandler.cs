// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="GenericExceptionHandler.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Exceptions
{
    using System;
    using GTDApp.ConsoleCore;
    using GTDApp.ConsoleCore.Interfaces;
    using GTDApp.Logic.Routing;

    /// <summary>
    ///     GenericExceptionHandler
    /// </summary>
    public class GenericExceptionHandler : IExceptionHandler
    {
        /// <summary>
        ///     Handle
        /// </summary>
        /// <param name="callback">callback function</param>
        public void Handle(Action callback)
        {
            try
            {
                callback();
            }
            catch (Exception ex)
            {
                object[] parameters = new object[]
                {
                    "An error occured, during execution."
                };
                ConsoleCore.CallRoute(RoutesEnum.EXCEPTION_ERROR.ToString(), parameters);
            }
        }
    }
}
