// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Program.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console
{
    using System;
    using GTDApp.Data;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     Entry Point
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Start Program
        /// </summary>
        public static void Main()
        {
            Router.Init();
            Application.Init();
            Router.Call();
        }
    }
}
