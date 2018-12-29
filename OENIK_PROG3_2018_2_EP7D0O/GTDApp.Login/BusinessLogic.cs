// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="BusinessLogic.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic
{
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Net;
    using GTDApp.Data;
    using GTDApp.Logic.Exceptions;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Repository;
    using GTDApp.Repository.Interfaces;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///      BusinessLogic
    /// </summary>
    public class BusinessLogic
    {
        /// <summary>
        ///      BusinessLogic
        /// </summary>
        private GtdEntityDataModel context;

        /// <summary>
        ///      BusinessLogic
        /// </summary>
        private IContainerRepository containerRepository;

        /// <summary>
        ///      itemRepository
        /// </summary>
        private IItemRepository itemRepository;

        /// <summary>
        ///      INotificationRepository
        /// </summary>
        private INotificationRepository notificationRepository;

        /// <summary>
        ///      INotificationRepository
        /// </summary>
        private IItem_NotificationRepository item_NotificationRepository;

        /// <summary>
        ///      BusinessLogic
        /// </summary>
        public static BusinessLogic Init()
        {
            GtdEntityDataModel Context = new GtdEntityDataModel();
            IContainerRepository ContainerRepository = new ContainerRepository(Context);
            IItemRepository ItemRepository = new ItemRepository(Context);
            INotificationRepository notificationRepository = new NotificationRepository(Context);
            IItem_NotificationRepository Item_NotificationRepository = new Item_notificationRepository(Context);

            BusinessLogic businessLogic = new BusinessLogic()
            {
                context = Context,
                containerRepository = ContainerRepository,
                itemRepository = ItemRepository,
                notificationRepository = notificationRepository,
                item_NotificationRepository = Item_NotificationRepository
            };

            return businessLogic;
        }

        /// <summary>
        ///      Gets or sets Context
        /// </summary>
        /// <value>GtdEntityDataModel</value>
        public GtdEntityDataModel Context { get => context; set => context = value; }

        /// <summary>
        ///      Gets or sets ContainerRepository
        /// </summary>
        /// <value>ContainerRepository</value>
        public IContainerRepository ContainerRepository { get => containerRepository; set => containerRepository = value; }

        /// <summary>
        ///      Gets or sets ContainerRepository
        /// </summary>
        /// <value>ContainerRepository</value>
        public IItemRepository ItemRepository { get => itemRepository; set => itemRepository = value; }

        /// <summary>
        ///      Gets or sets NotificationRepository
        /// </summary>
        /// <value>ContainerRepository</value>
        public INotificationRepository NotificationRepository { get => notificationRepository; set => notificationRepository = value; }

        /// <summary>
        ///      Gets or sets IItem_NotificationRepository
        /// </summary>
        /// <value>item_NotificationRepository</value>
        public IItem_NotificationRepository Item_NotificationRepository { get => item_NotificationRepository; set => item_NotificationRepository = value; }
        
        /// <summary>
        ///      A container is empty if it has no item.
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <returns>Boolean</returns>
        public static bool IsContainerRemovable(Container container)
        {
            return container.Item.Count == 0;
        }

        /// <summary>
        ///        An item is empty if it has no notification
        /// </summary>
        /// <param name="item">Container instance</param>
        /// <returns>Boolean</returns>
        public static bool IsItemRemovable(Item item)
        {
            return item.Item_notification.Count == 0;
        }

        /// <summary>
        ///      A notification is empty if it has no item.
        /// </summary>
        /// <param name="item">Container instance</param>
        /// <returns>Boolean</returns>
        public static bool IsNotificationRemovable(Notification notification)
        {
            return notification.Item_notification.Count == 0;
        }

        /// <summary>
        ///      RemoveContainer
        /// </summary>
        /// <param name="container">Container instance</param>
        public void RemoveContainer(Container container)
        {
            ContainerRepository.Remove(container);
            Context.SaveChanges();
        }

        /// <summary>
        ///      RemoveItem
        /// </summary>
        /// <param name="item">Item instance</param>
        public void RemoveItem(Item item)
        {
            ItemRepository.Remove(item);
            Context.SaveChanges();
        }

        /// <summary>
        ///      Remove Notification
        /// </summary>
        /// <param name="notification">Notification instance</param>
        public void RemoveNotification(Notification notification)
        {
            NotificationRepository.Remove(notification);
            Context.SaveChanges();
        }

        /// <summary>
        ///      RemoveContainer
        /// </summary>
        /// <param name="container">Container instance</param>
        public List<string> SaveContainer(Container container)
        {
            List<string> response = null;

            try
            {
                if (container.container_id == 0)
                {
                    ContainerRepository.Add(container);
                }

                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbValidationEx)
            {
                foreach (DbEntityValidationResult entityErr in
                   dbValidationEx.EntityValidationErrors)
                {
                    response = new List<string>();
                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        response.Add(error.ErrorMessage);
                    }
                }
            }

            return response;
        }

        /// <summary>
        ///      RemoveContainer
        /// </summary>
        /// <param name="item">Item instance</param>
        public List<string> SaveItem(Item item)
        {
            List<string> response = null;

            try
            {
                if (item.item_id == 0)
                {
                    ItemRepository.Add(item);
                }

                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbValidationEx)
            {
                foreach (DbEntityValidationResult entityErr in
                   dbValidationEx.EntityValidationErrors)
                {
                    response = new List<string>();
                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        response.Add(error.ErrorMessage);
                    }
                }
            }

            return response;
        }

        /// <summary>
        ///      Remove Notification
        /// </summary>
        /// <param name="notification">Notification instance</param>
        public List<string> SaveNotification(Notification notification)
        {
            List<string> response = null;

            try
            {
                if (notification.notification_id == 0)
                {
                    NotificationRepository.Add(notification);
                }

                Context.SaveChanges();
            }
            catch (DbEntityValidationException dbValidationEx)
            {
                foreach (DbEntityValidationResult entityErr in
                   dbValidationEx.EntityValidationErrors)
                {
                    response = new List<string>();
                    foreach (DbValidationError error in entityErr.ValidationErrors)
                    {
                        response.Add(error.ErrorMessage);
                    }
                }
            }

            return response;
        }

        public List<Item> GenerateItemsFromJSON(string json)
        {
            List<Item> items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Item>>(json);
            return items;
        }

        public bool ItemHasNotification(Item item, Notification notification)
        {
            return ( GetItemNotificationConnection(item, notification) != null ) ? true : false;
        }

        public void RemoveItemNotification(Item item, Notification notification)
        {
            Item_notification item_Notification = GetItemNotificationConnection(item, notification);
            item_NotificationRepository.Remove(item_Notification);
        }

        public Item_notification GetItemNotificationConnection(Item item, Notification notification)
        {
            foreach (Item_notification item_Notification in item.Item_notification)
            {
                if (item_Notification.Notification == notification)
                {
                    return item_Notification;
                }
            }

            return null;
        }
    }
}
