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
        private const int NUMBEROFCONTAINERS = 10;

        /// <summary>
        ///      Contant for Number of notifications to be generated
        /// </summary>
        /// <value>int 5</value>
        private const int NUMBEROFNOTIFICATIONS = 5;

        /// <summary>
        ///      Contant for Number of items to be generated
        /// </summary>
        /// <value>int 10</value>
        private const int NUMBEROFITEMS = 25;

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
            this.SetUpMockContainer();
            this.SetUpMockItem();
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
            for (int i = 0; i < BusinessLogicTests.NUMBEROFNOTIFICATIONS; i++)
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

            // itemList.AddRange(this.GenerateItems());
            this.MockItem.Setup(x => x.GetAll()).Returns(itemList.AsQueryable());
        }

        /// <summary>
        ///     Generate And return an IEnumerable list of items
        /// </summary>
        /// <returns>IEnumerable Containers</returns>
        private IEnumerable<Item> GenerateItems()
        {
            for (int i = 0; i < BusinessLogicTests.NUMBEROFITEMS; i++)
            {
                IQueryable<Container> containers = this.MockContainer.Object.GetAll();

                // TODO: Change elementAt to some "random" number
                // for some more distributed results.
                Container container = containers.ElementAt(i);

                yield return new Item()
                {
                    item_id = 0000 + i,
                    title = $"Test Item#{i}",
                    description = $"Test Description#{i}",
                    Container = container,
                    updated_at = default(DateTime),
                    created_at = default(DateTime)
                };
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
            yield return new Item_notification()
            {
                id = 00001,
                Item = new Item(),
                Notification = new Notification(),
                updated_at = default(DateTime),
                created_at = default(DateTime)
            };
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
            for (int i = 0; i < BusinessLogicTests.NUMBEROFCONTAINERS; i++)
            {
                yield return new Container()
                {
                    container_id = 0000 + i,
                    name = $"Test Controller#{i}",
                    principles = $"Test Principle#{i}",
                    type = $"TestType#{i}",
                    purpose = $"Test Purpose#{i}",
                    updated_at = default(DateTime),
                    created_at = default(DateTime)
                };
            }
        }
    }
}
