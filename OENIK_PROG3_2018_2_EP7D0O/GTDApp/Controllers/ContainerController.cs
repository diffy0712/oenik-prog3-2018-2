// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using System.Collections.Generic;
    using GTDApp.Console.Views;
    using GTDApp.Console.Views.Containers;
    using GTDApp.Console.Views.Modals;
    using GTDApp.ConsoleCore;
    using GTDApp.Data;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.DTO;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
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
        /// <param name="search">String to search for</param>
        /// <param name="paginator">Paginator Object</param>
        [Route(RoutesEnum.LIST_CONTAINERS)]
        public void List(string search = null, Paginator paginator = null)
        {
            search = search is null ? String.Empty : search;
            paginator = paginator is null ? new Paginator() : paginator;
            var containers = ConsoleCore.BusinessLogic.ContainerRepository.SearchAll(search, paginator);

            ListContainersView listContainersView = new ListContainersView()
            {
                Containers = containers,
                Paginator = paginator,
                Search = search
            };
            listContainersView.Render();
        }

        /// <summary>
        ///     Create container
        /// </summary>
        [Route(RoutesEnum.CREATE_CONTAINER)]
        public void Create()
        {
            CreateContainerView createContainersView = new CreateContainerView();

            createContainersView.Render();
        }

        /// <summary>
        ///     Create action
        /// </summary>
        [Route(RoutesEnum.CREATE_CONTAINER_ACTION)]
        public void CreateAction(Container container)
        {
            List<string> validation = ConsoleCore.BusinessLogic.SaveContainer(container);

            if (validation == null)
            {
                ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString(), new object[]{ null, null});
            }
            else
            {
                ConsoleCore.CallRoute(RoutesEnum.UPDATE_CONTAINER.ToString(), new object[] { container });
                ValidationErrorMessageModalView validationErrorMessageModalView = new ValidationErrorMessageModalView();
                validationErrorMessageModalView.Render();
            }
        }

        /// <summary>
        ///     Update container
        /// </summary>
        [Route(RoutesEnum.UPDATE_CONTAINER)]
        public void Update(Container container)
        {
            UpdateContainerView updateContainersView = new UpdateContainerView();
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
                    ConsoleCore.BusinessLogic.RemoveContainer(container);
                    Application.RequestStop();
                    ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString());
                });
            }

            DeleteContainerView deleteContainersView = new DeleteContainerView() { Container = container, DeleteAction = deleteAction };
            deleteContainersView.Render();
        }
    }
}
