// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Box10Helper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views.Helpers
{
    using System;
    using Terminal.Gui;

    /// <summary>
    ///     Box10Helper
    /// </summary>
    public class Box10Helper : View
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Box10Helper"/> class.
        ///     Box10Helper
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        public Box10Helper(int x, int y) 
            : base(new Rect(x, y, 10, 10))
        {
        }

        /// <summary>
        ///     Redraw
        /// </summary>
        /// <param name="region">Rect instance</param>
        public override void Redraw(Rect region)
        {
            //Driver.SetAttribute(ColorScheme.Focus);

            for (int y = 0; y < 10; y++)
            {
                Move(0, y);
                for (int x = 0; x < 10; x++)
                {

                    Driver.AddRune((Rune)('0' + (x + y) % 10));
                }
            }

        }
    }
}
