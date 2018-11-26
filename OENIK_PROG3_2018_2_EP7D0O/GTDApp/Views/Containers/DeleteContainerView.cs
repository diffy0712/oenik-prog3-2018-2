// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="CreateContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using System;
    using GTDApp.Data;
    using GTDApp.Logic;
    using GTDApp.Logic.Interfaces;
    using Terminal.Gui;

    /// <summary>
    ///     CreateContainerView
    /// </summary>
    public class DeleteContainerView : IView
    {
        /// <summary>
        ///     Container
        /// </summary>
        public Container Container;

        /// <summary>
        ///     CreateContainerView
        /// </summary>
        public Action DeleteAction;

        /// <summary>
        ///     Editor
        /// </summary>
        public void Render()
        {
            Dialog d;

            if (DeleteAction is null)
            {
                d = new Dialog(
                    $"You are unable to delete container #{this.Container.container_id} - {this.Container.name}",
                    80,
                    8,
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } }
                );
            }
            else
            {
                d = new Dialog(
                    $"Are you sure you want to delete #{this.Container.container_id} - {this.Container.name}",
                    80,
                    8,
                    new Button("Ok", is_default: true) { Clicked = () => { this.DeleteAction.Invoke(); Application.RequestStop(); Router.Call("list_containers"); } },
                    new Button("Cancel") { Clicked = () => { Application.RequestStop(); } }
                );
            }

            Application.Run(d);
        }
    }
}
