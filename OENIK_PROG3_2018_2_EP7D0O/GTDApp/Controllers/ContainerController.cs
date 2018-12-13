// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using GTDApp.Console.Menu;
    using GTDApp.Console.Views;
    using GTDApp.Console.Views.Containers;
    using GTDApp.ConsoleCore.Controllers;
    using GTDApp.Data;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     ContainerController
    /// </summary>
    public class ContainerController : AbstractController
    {
        public ContainerController(BusinessLogic businessLogic, Router router)
            : base(businessLogic, router)
        {
        }

        /// <summary>
        ///     List containers
        /// </summary>
        /// <param name="search">String to search for</param>
        /// <param name="paginator">Paginator Object</param>
        [Route(RoutesEnum.LIST_CONTAINERS)]
        public void List(string search = null, Paginator paginator = null)
        {
            search = search is null ? String.Empty : search;
            paginator = paginator is null ? new Paginator() : paginator;
            var containers = BusinessLogic.ContainerRepository.SearchAll(search, paginator);

            ListContainersView listContainersView = new ListContainersView()
            {
                Containers = containers,
                Paginator = paginator,
                Search = search,
                Router = this.Router
            };
            listContainersView.Render();
        }

        /// <summary>
        ///     Create container
        /// </summary>
        [Route(RoutesEnum.CREATE_CONTAINER)]
        public void Create()
        {
            CreateContainerView createContainersView = new CreateContainerView()
            {
                Router = this.Router
            };

            createContainersView.Render();
        }

        /// <summary>
        ///     Update container
        /// </summary>
        [Route(RoutesEnum.UPDATE_CONTAINER)]
        public void Update()
        {
            UpdateContainerView updateContainersView = new UpdateContainerView() {
                Router = this.Router
            };
            updateContainersView.Render();
        }

        /// <summary>
        ///     Delete container
        /// </summary>
        /// <param name="container">Container instance</param>
        [Route(RoutesEnum.DELETE_CONTAINER)]
        public void Delete(Container container)
        {
            Action deleteAction = null;

            if (BusinessLogic.IsContainerRemovable(container))
            {
                deleteAction = new Action(() =>
                {
                    BusinessLogic.RemoveContainer(container);
                    Application.RequestStop(); Router.Call(RoutesEnum.LIST_CONTAINERS.ToString());
                });
            }

            DeleteContainerView deleteContainersView = new DeleteContainerView() { Container = container, DeleteAction = deleteAction };
            deleteContainersView.Render();
        }
    }
}
