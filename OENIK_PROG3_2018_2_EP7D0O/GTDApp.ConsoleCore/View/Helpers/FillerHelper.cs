// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="FillerHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views.Helpers
{
    using System;
    using Terminal.Gui;

    /// <summary>
    ///     Box10Helper
    /// </summary>
    public class FillerHelper : View
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FillerHelper"/> class.
        ///     FillerHelper
        /// </summary>
        /// <param name="rect">Rect</param>
        public FillerHelper(Rect rect)
            : base(rect)
        {
        }

        /// <summary>
        ///     Redraw
        /// </summary>
        /// <param name="region">Rect</param>
        public override void Redraw(Rect region)
        {
            Driver.SetAttribute(ColorScheme.Focus);
            var f = Frame;

            for (int y = 0; y < f.Width; y++)
            {
                Move(0, y);

                for (int x = 0; x < f.Height; x++)
                {
                    Rune r;
                    switch (x % 3)
                    {
                        case 0:
                            r = '.';
                            break;
                        case 1:
                            r = 'o';
                            break;
                        default:
                            r = 'O';
                            break;
                    }

                    Driver.AddRune(r);
                }
            }
        }
    }
}
