// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ItemController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Console.Controllers
{
    using System;
    using System.Collections.Generic;
    using GTDApp.Console.Views.Containers;
    using GTDApp.Console.Views.Containers.Items;
    using GTDApp.Console.Views.Items;
    using GTDApp.Console.Views.Modals;
    using GTDApp.ConsoleCore;
    using GTDApp.Data;
    using GTDApp.Logic;
    using GTDApp.Logic.Attributes;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Logic.Routing;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     ItemController
    /// </summary>
    public class ItemController : IController
    {
        /// <summary>
        ///     List item
        /// </summary>
        [Route(RoutesEnum.LIST_ITEMS)]
        public void List(Container container, string search = null, Paginator paginator = null)
        {
            search = search is null ? String.Empty : search;
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
        [Route(RoutesEnum.CREATE_ITEM)]
        public void Create(Container container)
        {
            ManageItemView manageView = new ManageItemView();

            Item item = new Item();
            item.title = String.Empty;
            item.Container = container;
            item.description = String.Empty;

            manageView.Notifications = ConsoleCore.BusinessLogic.NotificationRepository.GetAll();
            manageView.Container = container;
            manageView.Item = item;
            manageView.Creation = true;

            manageView.Render();
        }

        /// <summary>
        ///     Update item
        /// </summary>
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
        [Route(RoutesEnum.DELETE_ITEM)]
        public void Delete(Item item)
        {
            Action deleteAction = null;

            Container container = item.Container;
            if (BusinessLogic.IsItemRemovable(item))
            {
                deleteAction = new Action(() =>
                {
                    ConsoleCore.BusinessLogic.RemoveItem(item);
                    Application.RequestStop();
                    object[] parameters = new object[] {
                        container,
                        null,
                        null
                    };
                    ConsoleCore.CallRoute(RoutesEnum.LIST_ITEMS.ToString(),parameters);
                });
            }

            DeleteItemView deleteContainersView = new DeleteItemView() { Item = item, DeleteAction = deleteAction };
            deleteContainersView.Render();
        }
    }
}
