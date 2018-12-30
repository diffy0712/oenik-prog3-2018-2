// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ValidationErrorMessageModalView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Views.Modals
{
    using GtdApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     ValidationErrorMessageModalView
    /// </summary>
    public class ValidationErrorMessageModalView : IView
    {
        /// <summary>
        ///     Editor
        /// </summary>
        public void Render()
        {
            Dialog d;
            d = new Dialog(
                $"Validation Error. Please fill the inputs correctly",
                100,
                8,
                new Button("OK") { Clicked = () => { Application.RequestStop(); } });

            Application.Run(d);
        }
    }
}
