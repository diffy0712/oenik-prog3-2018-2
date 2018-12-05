// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DetailedExceptionHandler.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.Exceptions
{
    using System;
    using GTDApp.Logic.Interfaces;

    /// <summary>
    ///     DetailedExceptionHandler
    /// </summary>
    public class DetailedExceptionHandler : IExceptionHandler
    {
        public DetailedExceptionHandler()
        {
        }

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
            catch(Exception ex)
            {
                object[] parameters = new object[]
                {
                    ex
                };

                //Router.Call("exception_error", parameters); 
            }
            finally
            {
                GenericExceptionHandler.finallyErrorCall();
            }
        }
    }
}
