// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ItemController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GtdApp.Console.Controllers
{
    using System;
    using System.Collections.Generic;
    using GtdApp.Console.Views.Containers;
    using GtdApp.Console.Views.Containers.Items;
    using GtdApp.Console.Views.Items;
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
    ///     ItemController
    /// </summary>
    public class ItemController : IController
    {
        /// <summary>
        ///     List item
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <param name="search">Search string</param>
        /// <param name="paginator">Paginator instance</param>
        [Route(RoutesEnum.LIST_ITEMS)]
        public void List(Container container, string search = null, Paginator paginator = null)
        {
            search = search is null ? string.Empty : search;
            paginator = paginator is null ? new Paginator() : paginator;
            var items = ConsoleCore.BusinessLogic.ItemRepository.SearchAllByContainer(container, search, paginator);

            ListItemsView listItemsView = new ListItemsView()
            {
                Items = items,
                Paginator = paginator,
                Search = search,
                Container = container
            };
            listItemsView.Render();
        }

        /// <summary>
        ///     Create item
        /// </summary>
        /// <param name="container">Container instance</param>
        [Route(RoutesEnum.CREATE_ITEM)]
        public void Create(Container container)
        {
            ManageItemView manageView = new ManageItemView();

            Item item = new Item();
            item.title = string.Empty;
            item.Container = container;
            item.description = string.Empty;

            manageView.Notifications = ConsoleCore.BusinessLogic.NotificationRepository.GetAll();
            manageView.Container = container;
            manageView.Item = item;
            manageView.Creation = true;

            manageView.Render();
        }

        /// <summary>
        ///     Update item
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <param name="item">Item instance</param>
        [Route(RoutesEnum.UPDATE_ITEM)]
        public void Update(Container container, Item item)
        {
            ManageItemView manageView = new ManageItemView();
            manageView.Notifications = ConsoleCore.BusinessLogic.NotificationRepository.GetAll();
            manageView.Container = container;
            manageView.Item = item;
            manageView.Creation = false;

            manageView.Render();
        }

        /// <summary>
        ///     Create action
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <param name="item">Item instance</param>
        [Route(RoutesEnum.MANAGE_ITEM_ACTION)]
        public void ManageAction(Container container, Item item)
        {
            item.Container = container;
            List<string> validation = ConsoleCore.BusinessLogic.SaveItem(item);

            if (validation == null)
            {
                ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), new object[] { container, null, null });
            }
            else
            {
                ValidationErrorMessageModalView validationErrorMessageModalView = new ValidationErrorMessageModalView();
                validationErrorMessageModalView.Render();
            }
        }

        /// <summary>
        ///     Delete item
        /// </summary>
        /// <param name="item">Item instance</param>
        [Route(RoutesEnum.DELETE_ITEM)]
        public void Delete(Item item)
        {
            Action deleteAction = null;

            Container container = item.Container;
            if (ConsoleCore.BusinessLogic.IsItemRemovable(item))
            {
                deleteAction = new Action(() =>
                {
                    ConsoleCore.BusinessLogic.RemoveItem(item);
                    Application.RequestStop();
                    object[] parameters = new object[]
                    {
                        container,
                        null,
                        null
                    };
                    ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(), parameters);
                });
            }

            DeleteItemView deleteContainersView = new DeleteItemView() { Item = item, DeleteAction = deleteAction };
            deleteContainersView.Render();
        }
    }
}
