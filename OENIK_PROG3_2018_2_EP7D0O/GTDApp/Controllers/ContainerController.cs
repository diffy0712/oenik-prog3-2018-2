// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using System.Linq;
    using GTDApp.Logic;
    using GTDApp.Console.Attributes;
    using GTDApp.Console.Views;
    using GTDApp.Console.Views.Containers;
    using GTDApp.Data;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     ContainerController
    /// </summary>
    public class ContainerController : IController
    {

        /// <summary>
        ///     List containers
        /// </summary>
        [Route("list_containers")]
        public void List(string search = null, Paginator paginator = null)
        {
            if (paginator is null)
            {
                paginator = new Paginator();
            }
            if( search is null)
            {
                search = "";
            }
            var containers = BusinessLogic.ContainerRepository.SearchAll(search, paginator);

            ListContainersView listContainersView = new ListContainersView(containers, paginator, search);
            listContainersView.Render();
        }

        /// <summary>
        ///     Create container
        /// </summary>
        /// <param name="top">Top Level</param>
        [Route("create_container")]
        public void Create()
        {
            CreateContainerView createContainersView = new CreateContainerView();
            createContainersView.Render();
        }

        /// <summary>
        ///     Update container
        /// </summary>
        /// <param name="top">Top Level</param>
        [Route("update_container")]
        public void Update()
        {
            UpdateContainerView updateContainersView = new UpdateContainerView();
            updateContainersView.Render();
        }

        /// <summary>
        ///     Delete container
        /// </summary>
        [Route("delete_container")]
        public void Delete(Container container)
        {
            Action deleteAction = new Action(() =>
            {
                BusinessLogic.ContainerRepository.Remove(container);
                BusinessLogic.Context.SaveChanges();
            });

            DeleteContainerView deleteContainersView = new DeleteContainerView() { Container = container, DeleteAction = deleteAction };
            deleteContainersView.Render();
        }
    }
}
