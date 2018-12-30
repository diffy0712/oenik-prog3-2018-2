// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="GenericExceptionHandler.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Exceptions
{
    using System;
    using System.Reflection;
    using GtdApp.ConsoleCore;
    using GtdApp.ConsoleCore.Interfaces;
    using GtdApp.Logic.Exceptions;

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
            catch (NoRouteFoundException)
            {
                throw;
            }
            catch (TargetInvocationException)
            {
                object[] parameters = new object[]
                {
                    "An error occured, during execution."
                };
                ConsoleCore.CallRoute(RoutesEnum.EXCEPTION_ERROR.ToString(), parameters);
            }
            catch
            {
                throw;
            }
        }
    }
}
