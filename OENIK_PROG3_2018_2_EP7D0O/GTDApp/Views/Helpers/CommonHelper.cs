// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="CommonHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Helpers
{
    using System;
    using Terminal.Gui;

    /// <summary>
    ///     CommonHelper
    /// </summary>
    public class CommonHelper
    {
        /// <summary>
        ///     CommonHelper
        /// </summary>
        /// <returns>Label</returns>
        public static Label GetHr(Rect rect)
        {
            Label line = new Label(rect, string.Empty);
            ColorScheme colorScheme = new ColorScheme();
            line.TextColor = colorScheme.Normal;

            return line;
        }
    }
}
