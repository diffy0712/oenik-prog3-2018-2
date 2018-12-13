// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="GenericExceptionHandler.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Exceptions
{
    using System;
    using GTDApp.Logic.Interfaces;

    /// <summary>
    ///     GenericExceptionHandler
    /// </summary>
    public class GenericExceptionHandler : IExceptionHandler
    {
        /// <summary>
        ///     Handle
        /// </summary>
        /// <param name="callback">callback function</param>
        public virtual void Handle(Action callback)
        {
            try
            {
                callback();
            }
            finally
            {
                finallyErrorCall();
            }
        }

        /// <summary>
        ///     finallyErrorCall
        /// </summary>
        public static void finallyErrorCall()
        {
            object[] parameters = new string[]
                {
                    $"An error occured during the previous operation."
                };
            
        }
    }
}
