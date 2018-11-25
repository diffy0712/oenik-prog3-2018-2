// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="CreateContainerView.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Views.Containers
{
    using GTDApp.Data;
    using System;
    using Terminal.Gui;

    /// <summary>
    ///     CreateContainerView
    /// </summary>
    public class DeleteContainerView : IView
    {
        public Container Container;

        public Action DeleteAction;

        /// <summary>
        ///     Editor
        /// </summary>
        public void Render()
        {
            var d = new Dialog(
            $"Are you sure you want to delete #{Container.container_id} - {Container.name}", 50, 20,
            new Button("Ok", is_default: true) { Clicked = () => { DeleteAction.Invoke(); Application.RequestStop(); Router.Call("list_containers"); } },
            new Button("Cancel") { Clicked = () => { Application.RequestStop(); } });
            Application.Run(d);
        }
    }
}
