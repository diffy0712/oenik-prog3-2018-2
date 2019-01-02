// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="BusinessLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GtdApp.Data;
    using GtdApp.Repository.Interfaces;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    ///      BusinessLogicTests
    /// </summary>
    public abstract class BusinessLogicTests
    {
        /// <summary>
        ///      Contant for Number of containers to be generated
        /// </summary>
        /// <value>int 10</value>
        private const int NUMBEROFCONTAINERS = 6;

        /// <summary>
        ///      Contant for Number of notifications to be generated
        /// </summary>
        /// <value>int 5</value>
        private const int NUMBEROFNOTIFICATIONS = 5;

        /// <summary>
        ///      Contant for Number of items to be generated
        /// </summary>
        /// <value>int 10</value>
        private const int NUMBEROFITEMS = 15;

        /// <summary>
        ///      Gets or sets MockContainer
        /// </summary>
        /// <value>Mock of IContainerRepository</value>
        protected Mock<IContainerRepository> MockContainer { get; set; }

        /// <summary>
        ///      Gets or sets MockItem
        /// </summary>
        /// <value>Mock of IItemRepository</value>
        protected Mock<IItemRepository> MockItem { get; set; }

        /// <summary>
        ///      Gets or sets MockNotification
        /// </summary>
        /// <value>Mock of INotificationRepository</value>
        protected Mock<INotificationRepository> MockNotification { get; set; }

        /// <summary>
        ///      Gets or sets MockItemNotificaion
        /// </summary>
        /// <value>Mock of IItem_NotificationRepository</value>
        protected Mock<IItem_NotificationRepository> MockItemNotificaion { get; set; }

        /// <summary>
        ///      Gets or sets BusinessLogic
        /// </summary>
        /// <value>Mock of BusinessLogic</value>
        protected BusinessLogic BusinessLogic { get; set; }

        /// <summary>
        ///     The Setup of the BusinessLogicTests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.SetUpNotification();
            this.SetUpMockItem();
            this.SetUpMockContainer();
            this.SetUpItemNotification();

            // We don't use the BusinessLogic.Init() static method to use mocks
            this.BusinessLogic = new BusinessLogic()
            {
                ContainerRepository = this.MockContainer.Object,
                ItemRepository = this.MockItem.Object,
                NotificationRepository = this.MockNotification.Object,
                Item_NotificationRepository = this.MockItemNotificaion.Object,
                Context = new GtdEntityDataModel()
            };
        }

        /// <summary>
        ///     Set Up the notificaions
        /// </summary>
        private void SetUpNotification()
        {
            this.MockNotification = new Mock<INotificationRepository>();

            List<Notification> notificationList = new List<Notification>();
            notificationList.AddRange(this.GenerateNotifications());

            this.MockNotification.Setup(x => x.GetAll()).Returns(notificationList.AsQueryable());
        }

        /// <summary>
        ///     Generate And return an IEnumerable list of notificaions
        /// </summary>
        /// <returns>IEnumerable Notificaions</returns>
        private IEnumerable<Notification> GenerateNotifications()
        {
            for (int i = 1; i <= BusinessLogicTests.NUMBEROFNOTIFICATIONS; i++)
            {
                yield return new Notification()
                {
                    notification_id = 0000 + i,
                    name = $"Test Notificaion#{i}",
                    amount = 10,
                    type = i % 2 == 0 ? "email" : "sms",
                    unit = i % 2 == 0 ? "day" : "hour",
                    updated_at = default(DateTime),
                    created_at = default(DateTime)
                };
            }
        }

        /// <summary>
        ///     Set Up the items
        /// </summary>
        private void SetUpMockItem()
        {
            this.MockItem = new Mock<IItemRepository>();

            List<Item> itemList = new List<Item>();
            itemList.AddRange(this.GenerateItems());

            this.MockItem.Setup(x => x.GetAll()).Returns(itemList.AsQueryable());
        }

        /// <summary>
        ///     Generate And return an IEnumerable list of items
        ///     The first one is empty
        /// </summary>
        /// <returns>IEnumerable Items</returns>
        private IEnumerable<Item> GenerateItems()
        {
            DateTime fromDate = default(DateTime);
            fromDate.AddDays(1);
            DateTime toDate = default(DateTime);
            toDate.AddDays(2);

            for (int i = 1; i <= BusinessLogicTests.NUMBEROFITEMS; i++)
            {
                Item item;
                if (i > 1)
                {
                    item = new Item()
                    {
                        item_id = 0000 + i,
                        title = $"Test Item#{i}",
                        description = $"Test Description#{i}",
                        from_date = fromDate,
                        to_date = toDate,
                        updated_at = default(DateTime),
                        created_at = default(DateTime)
                    };
                }
                else
                {
                    item = new Item()
                    {
                        item_id = 0000 + i,
                        title = $"Test Item#{i}",
                        description = $"Test Description#{i}",
                        updated_at = default(DateTime),
                        created_at = default(DateTime)
                    };
                }

                yield return item;
            }
        }

        /// <summary>
        ///     Set Up the item notification connections
        /// </summary>
        private void SetUpItemNotification()
        {
            this.MockItemNotificaion = new Mock<IItem_NotificationRepository>();
            List<Item_notification> itemNotificationList = new List<Item_notification>();
            itemNotificationList.AddRange(this.GenerateItemNotifications());

            this.MockItemNotificaion.Setup(x => x.GetAll()).Returns(itemNotificationList.AsQueryable());
        }

        /// <summary>
        ///     Generate And return an IEnumerable list of item notificaion connections
        /// </summary>
        /// <returns>IEnumerable Item notification connections</returns>
        private IEnumerable<Item_notification> GenerateItemNotifications()
        {
            int i = 1;
            yield return this.GenerateItemNotification(ref i, 2, 1);
            yield return this.GenerateItemNotification(ref i, 1, 2);
            yield return this.GenerateItemNotification(ref i, 1, 3);

            yield return this.GenerateItemNotification(ref i, 2, 1);

            yield return this.GenerateItemNotification(ref i, 3, 2);

            yield return this.GenerateItemNotification(ref i, 4, 1);
            yield return this.GenerateItemNotification(ref i, 4, 3);
        }

        /// <summary>
        ///     Returns an item notification
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="itemId">Item id</param>
        /// <param name="notificatitonId">Notification id</param>
        /// <returns>Item notification connection</returns>
        private Item_notification GenerateItemNotification(ref int id, int itemId, int notificatitonId)
        {
            IQueryable<Item> items = this.MockItem.Object.GetAll();
            IQueryable<Notification> notifications = this.MockNotification.Object.GetAll();

            Item item = items.ElementAt(itemId);
            Notification notification = notifications.ElementAt(notificatitonId);

            Item_notification itemNotification = new Item_notification()
            {
                id = 0000 + id++,
                Item = item,
                Notification = notification,
                updated_at = default(DateTime),
                created_at = default(DateTime)
            };

            item.Item_notification.Add(itemNotification);
            notification.Item_notification.Add(itemNotification);

            return itemNotification;
        }

        /// <summary>
        ///     Set Up the containers
        /// </summary>
        private void SetUpMockContainer()
        {
            this.MockContainer = new Mock<IContainerRepository>();

            List<Container> containerList = new List<Container>();
            containerList.AddRange(this.GenerateContainers());

            this.MockContainer.Setup(x => x.GetAll()).Returns(containerList.AsQueryable());
        }

        /// <summary>
        ///     Generate And return an IEnumerable list of containers
        /// </summary>
        /// <returns>IEnumerable Containers</returns>
        private IEnumerable<Container> GenerateContainers()
        {
            IQueryable<Item> items = this.MockItem.Object.GetAll();
            for (int i = 1; i <= BusinessLogicTests.NUMBEROFCONTAINERS; i++)
            {
                List<Item> containerItems = new List<Item>();

                if (i > 1)
                {
                    containerItems.Add(items.ElementAt(i));
                }

                Container container = new Container()
                {
                    container_id = 0000 + i,
                    name = $"Test Controller#{i}",
                    principles = $"Test Principle#{i}",
                    type = $"TestType#{i}",
                    Item = containerItems,
                    purpose = $"Test Purpose#{i}",
                    updated_at = default(DateTime),
                    created_at = default(DateTime)
                };

                foreach (Item item in containerItems)
                {
                    item.Container = container;
                }

                yield return container;
            }
        }
    }
}
