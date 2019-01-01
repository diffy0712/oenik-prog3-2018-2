// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Controllers
{
    using System;
    using System.Collections.Generic;
    using GtdApp.Console.Views.Containers;
    using GtdApp.Console.Views.Modals;
    using GtdApp.ConsoleCore;
    using GtdApp.Data;
    using GtdApp.Logic;
    using GtdApp.Logic.Attributes;
    using GtdApp.Logic.Interfaces;
    using GtdApp.Logic.Routing;
    using GtdApp.Repository;
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
            search = search is null ? string.Empty : search;
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
            ManageContainerView manageContainersView = new ManageContainerView();

            Container container = new Container();
            container.name = string.Empty;
            container.purpose = string.Empty;
            container.principles = string.Empty;
            container.invisioned_outcome = string.Empty;
            container.type = string.Empty;

            manageContainersView.Container = container;
            manageContainersView.Creation = true;

            manageContainersView.Render();
        }

        /// <summary>
        ///     Update container
        /// </summary>
        /// <param name="container">Container instance</param>
        [Route(RoutesEnum.UPDATE_CONTAINER)]
        public void Update(Container container)
        {
            ManageContainerView manageContainersView = new ManageContainerView();
            manageContainersView.Container = container;
            manageContainersView.Creation = false;

            manageContainersView.Render();
        }

        /// <summary>
        ///     Create action
        /// </summary>
        /// <param name="container">Container instance</param>
        [Route(RoutesEnum.MANAGE_CONTAINER_ACTION)]
        public void ManageAction(Container container)
        {
            List<string> validation = ConsoleCore.BusinessLogic.SaveContainer(container);

            if (validation == null)
            {
                ConsoleCore.CallRoute(RoutesEnum.LIST_CONTAINERS.ToString(), new object[] { null, null });
            }
            else
            {
                ValidationErrorMessageModalView validationErrorMessageModalView = new ValidationErrorMessageModalView();
                validationErrorMessageModalView.Render();
            }
        }

        /// <summary>
        ///     Delete container
        /// </summary>
        /// <param name="container">Container instance</param>
        [Route(RoutesEnum.DELETE_CONTAINER)]
        public void Delete(Container container)
        {
            Action deleteAction = null;

            if (ConsoleCore.BusinessLogic.IsContainerRemovable(container))
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
