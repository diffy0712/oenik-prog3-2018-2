// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DeleteContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using System;
    using GTDApp.Data;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     CreateContainerView
    /// </summary>
    public class DeleteContainerView : IView
    {
        /// <summary>
        ///    Gets or sets Container
        /// </summary>
        /// <value>Container</value>
        public Container Container { get; set; }

        /// <summary>
        ///    Gets or sets DeleteAction
        /// </summary>
        /// <value>Action</value>
        public Action DeleteAction { get; set; }

        /// <summary>
        ///     Editor
        /// </summary>
        public void Render()
        {
            Dialog d;

            if (this.DeleteAction is null)
            {
                d = new Dialog(
                    $"Unable to delete container #{this.Container.container_id} - {this.Container.name}. Please empty it first.",
                    100,
                    8,
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } });
            }
            else
            {
                d = new Dialog(
                    $"Are you sure you want to delete #{this.Container.container_id} - {this.Container.name}",
                    80,
                    8,
                    new Button("Ok", is_default: true) { Clicked = () => { this.DeleteAction.Invoke(); } },
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } });
            }

            Application.Run(d);
        }
    }
}
