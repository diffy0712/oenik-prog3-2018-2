// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ReviewView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using Terminal.Gui;

    /// <summary>
    ///     ReviewView
    /// </summary>
    public class ReviewView : IView
    {
        /// <summary>
        ///     render the view
        /// </summary>
        public Window Render()
        {
            var win = new Window("Review Container")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };
            return win;
        }
    }
}
