// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="QuitHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views.Helpers
{
    using Terminal.Gui;

    /// <summary>
    ///     QuitHelper
    /// </summary>
    public class QuitHelper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuitHelper"/> class.
        ///     QuitHelper
        /// </summary>
        /// <param name="top">Top level element</param>
        /// <returns>bool</returns>
        public QuitHelper(Toplevel top)
        {
            var n = MessageBox.Query(50, 7, "Quit", "Are you sure you want to quit?", "Yes", "No");
            if (n == 0) {
                top.Running = false;
            }
        }
    }
}
