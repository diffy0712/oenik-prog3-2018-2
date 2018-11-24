// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using GTDApp.Console.Attributes;
    using GTDApp.Console.Views;
    using GTDApp.Console.Views.Containers;
    using Terminal.Gui;

    /// <summary>
    ///     ContainerController
    /// </summary>
    public class ContainerController : IController
    {

        /// <summary>
        ///     List containers
        /// </summary>
        /// <param name="top">Top Level</param>
        [Route("list_containers")]
        public Window List()
        {
            ListContainersView listContainersView = new ListContainersView();
            return listContainersView.Render();
        }

        /// <summary>
        ///     Create container
        /// </summary>
        /// <param name="top">Top Level</param>
        [Route("create_container")]
        public Window Create()
        {
            CreateContainerView createContainersView = new CreateContainerView();
            return createContainersView.Render();
        }

        /// <summary>
        ///     Update container
        /// </summary>
        /// <param name="top">Top Level</param>
        [Route("update_container")]
        public Window Update()
        {
            UpdateContainerView updateContainersView = new UpdateContainerView();
            return updateContainersView.Render();
        }

        /// <summary>
        ///     Delete container
        /// </summary>
        [Route("delete_container")]
        public void Delete()
        {
        }
    }
}
