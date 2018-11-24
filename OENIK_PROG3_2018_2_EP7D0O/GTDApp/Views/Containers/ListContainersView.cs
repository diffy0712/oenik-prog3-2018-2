// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ListContainersView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views
{
    using System;
    using Terminal.Gui;

    /// <summary>
    ///     ListContainersView
    /// </summary>
    public class ListContainersView : IView
    {
        /// <summary>
        ///     render the view
        /// </summary>
        /// <returns>Window</returns>
        public Window Render()
        {
            var win = new Window("List Container")
            {
                X = 0,
                Y = 1,
                Width = Dim.Fill(),
                Height = Dim.Fill()
            };

            Button addNew = new Button(1, 1, "Add new Container");
            Action addNewEvent = new Action(() => {  });
            addNew.Clicked = addNewEvent;

            win.Add(
                addNew
            );

            return win;
        }
    }


}
