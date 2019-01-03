// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="BusinessLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic
{
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using GtdApp.Data;
    using GtdApp.Repository;
    using GtdApp.Repository.Interfaces;

    /// <summary>
    ///      BusinessLogic
    /// </summary>
    public class BusinessLogic
    {
        /// <summary>
        ///      Gets or sets BusinessLogic
        /// </summary>
        /// <value>GtdEntityDataModel</value>
        public GtdEntityDataModel Context { get; set; }

        /// <summary>
        ///      Gets or sets ContainerRepository
        /// </summary>
        /// <value>IContainerRepository</value>
        public IContainerRepository ContainerRepository { get; set; }

        /// <summary>
        ///      Gets or sets ItemRepository
        /// </summary>
        /// <value>IItemRepository</value>
        public IItemRepository ItemRepository { get; set; }

        /// <summary>
        ///      Gets or sets NotificationRepository
        /// </summary>
        /// <value>INotificationRepository</value>
        public INotificationRepository NotificationRepository { get; set; }

        /// <summary>
        ///      Gets or sets Item_NotificationRepository
        /// </summary>
        /// <value>IItem_NotificationRepository</value>
        public IItem_NotificationRepository Item_NotificationRepository { get; set; }

        /// <summary>
        ///      BusinessLogic
        /// </summary>
        /// <returns>new BusinessLogic instance</returns>
        public static BusinessLogic Init()
        {
            GtdEntityDataModel context = new GtdEntityDataModel();
            IContainerRepository containerRepository = new ContainerRepository(context);
            IItemRepository itemRepository = new ItemRepository(context);
            INotificationRepository notificationRepository = new NotificationRepository(context);
            IItem_NotificationRepository item_NotificationRepository = new Item_notificationRepository(context);

            BusinessLogic businessLogic = new BusinessLogic()
            {
                Context = context,
                ContainerRepository = containerRepository,
                ItemRepository = itemRepository,
                NotificationRepository = notificationRepository,
                Item_NotificationRepository = item_NotificationRepository
            };

            return businessLogic;
        }

        /// <summary>
        ///      Only empty containers can be removed. A container is empty if it has no item.
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <returns>Boolean</returns>
        public bool IsContainerRemovable(Container container)
        {
            return container.Item.Count == 0;
        }

        /// <summary>
        ///        An item is empty if it has no notification
        /// </summary>
        /// <param name="item">Container instance</param>
        /// <returns>Boolean</returns>
        public bool IsItemRemovable(Item item)
        {
            return item.Item_notification.Count == 0;
        }

        /// <summary>
        ///      A notification is empty if it has no item.
        /// </summary>
        /// <param name="notification">Notification instance</param>
        /// <returns>Boolean</returns>
        public bool IsNotificationRemovable(Notification notification)
        {
            return notification.Item_notification.Count == 0;
        }

        /// <summary>
        ///      RemoveContainer
        /// </summary>
        /// <param name="container">Container instance</param>
        public void RemoveContainer(Container container)
        {
            this.ContainerRepository.Remove(container);
            this.Context.SaveChanges();
        }

        /// <summary>
        ///      RemoveItem
        /// </summary>
        /// <param name="item">Item instance</param>
        public void RemoveItem(Item item)
        {
            this.ItemRepository.Remove(item);
            this.Context.SaveChanges();
        }

        /// <summary>
        ///      Remove Notification
        /// </summary>
        /// <param name="notification">Notification instance</param>
        public void RemoveNotification(Notification notification)
        {
            this.NotificationRepository.Remove(notification);
            this.Context.SaveChanges();
        }

        /// <summary>
        ///      RemoveContainer
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <returns>List of strings</returns>
        public List<string> SaveContainer(Container container)
        {
            List<string> response = null;

            try
            {
                if (container.container_id == 0)
                {
                    this.ContainerRepository.Add(container);
                }

                this.Context.SaveChanges();
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
        /// <returns>List of strings</returns>
        public List<string> SaveItem(Item item)
        {
            List<string> response = null;

            try
            {
                if (item.item_id == 0)
                {
                    this.ItemRepository.Add(item);
                }

                this.Context.SaveChanges();
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
        /// <returns>List of strings</returns>
        public List<string> SaveNotification(Notification notification)
        {
            List<string> response = null;

            try
            {
                if (notification.notification_id == 0)
                {
                    this.NotificationRepository.Add(notification);
                }

                this.Context.SaveChanges();
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
        /// <param name="json">JSON as string</param>
        /// <returns>List of strings</returns>
        public List<Item> GenerateItemsFromJSON(string json)
        {
            List<Item> items = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Item>>(json);
            return items;
        }

        /// <summary>
        ///      Item Has Notification
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="notification">Notification instance</param>
        /// <returns>List of strings</returns>
        public bool ItemHasNotification(Item item, Notification notification)
        {
            return this.GetItemNotificationConnection(item, notification) != null ? true : false;
        }

        /// <summary>
        ///      Remove Item Notification
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="notification">Notification instance</param>
        public void RemoveItemNotification(Item item, Notification notification)
        {
            Item_notification item_Notification = this.GetItemNotificationConnection(item, notification);
            if (item_Notification != null)
            {
                this.Item_NotificationRepository.Remove(item_Notification);
            }
        }

        /// <summary>
        ///      GetItemNotificationConnection
        /// </summary>
        /// <param name="item">Item instance</param>
        /// <param name="notification">Notification instance</param>
        /// <returns>Item_notification</returns>
        private Item_notification GetItemNotificationConnection(Item item, Notification notification)
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
