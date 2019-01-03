// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ItemBusinessLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests.BusinessLogic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using GtdApp.Data;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    ///      ItemBusinessLogicTests
    /// </summary>
    public class ItemBusinessLogicTests : BusinessLogicTests
    {
        /// <summary>
        ///     Test the save method's calling for insertion (item_id is not declared)
        /// </summary>
        [Test]
        public void DoesSaveItemAddsNewItem()
        {
            Item testNewItem = new Item()
            {
                title = $"Test Item#01",
                description = "Test description",
                updated_at = default(DateTime),
                created_at = default(DateTime)
            };

            this.BusinessLogic.SaveItem(testNewItem);
            this.MockItem.Verify(x => x.Add(testNewItem), Times.Once);
        }

        /// <summary>
        ///     Test the delete method's calling for deletion
        /// </summary>
        [Test]
        public void DoesRemoveItemRemovesItem()
        {
            Item testNewItem = this.MockItem.Object.GetAll().First();
            this.BusinessLogic.RemoveItem(testNewItem);
            this.MockItem.Verify(x => x.Remove(testNewItem), Times.Once);
        }

        /// <summary>
        ///     Test the delete method's calling for deletion
        /// </summary>
        [Test]
        public void DoesRemoveItemNotificationRemovesConnection()
        {
            Item testItem = this.MockItem.Object.GetAll().ElementAt(2);
            Notification testNotification = this.MockNotification.Object.GetAll().ElementAt(1);
            Item_notification testItemNotification = this.MockItemNotificaion.Object.GetAll().ElementAt(0);

            this.BusinessLogic.RemoveItemNotification(testItem, testNotification);
            this.MockItemNotificaion.Verify(x => x.Remove(testItemNotification), Times.Once);
        }

        /// <summary>
        ///     Test the delete method's calling for deletion
        /// </summary>
        [Test]
        public void DoesRemoveItemNotificationNeverRemovesConnectionIfNoConnectionExists()
        {
            Item testItem = this.MockItem.Object.GetAll().ElementAt(2);
            Notification testNotification = this.MockNotification.Object.GetAll().ElementAt(2);
            Item_notification testItemNotification = this.MockItemNotificaion.Object.GetAll().ElementAt(0);

            this.BusinessLogic.RemoveItemNotification(testItem, testNotification);
            this.MockItemNotificaion.Verify(x => x.Remove(testItemNotification), Times.Never);
        }

        /// <summary>
        ///     Test if the container is removable if it has no item.
        /// </summary>
        [Test]
        public void IsItemRemovableIfHasNoNotificaion()
        {
            Item testNewItem = this.MockItem.Object.GetAll().First();
            Assert.That(this.BusinessLogic.IsItemRemovable(testNewItem), Is.EqualTo(true));
        }

        /// <summary>
        ///     Test the save method's calling for insertion (container_id is not declared)
        /// </summary>
        [Test]
        public void IsItemNotRemovableIfHasNotifications()
        {
            Item testNewItem = this.MockItem.Object.GetAll().ElementAt(3);
            Assert.That(this.BusinessLogic.IsItemRemovable(testNewItem), Is.EqualTo(false));
        }

        /// <summary>
        ///     Test the save method's calling for insertion (container_id is not declared)
        /// </summary>
        [Test]
        public void DoesGeneratesValidListOfItemsFromJson()
        {
            string json = "[{title: \"Text#1\",description: \"Description#1\"},{title: \"Text#2\", description: \"Description#2\"}]";
            List<Item> items = new List<Item>()
            {
                new Item()
                {
                    title = "Test#1",
                    description = "Description#1"
                },
                new Item()
                {
                    title = "Test#2",
                    description = "Description#2"
                }
            };
            Assert.That(this.BusinessLogic.GenerateItemsFromJSON(json).Count(), Is.EqualTo(2));
        }

        /// <summary>
        ///     Does the itemHasNotification method returns true only if it has a connection with the notification
        /// </summary>
        [Test]
        public void DoesItemHasNotificationReturnsTrueIffItemHasConnection()
        {
            Item testItem = this.MockItem.Object.GetAll().ElementAt(2);
            Notification testNotification = this.MockNotification.Object.GetAll().ElementAt(1);
            Notification notUsedNotification = this.MockNotification.Object.GetAll().ElementAt(4);

            Assert.That(this.BusinessLogic.ItemHasNotification(testItem, testNotification), Is.EqualTo(true));
            Assert.That(this.BusinessLogic.ItemHasNotification(testItem, notUsedNotification), Is.EqualTo(false));
        }
    }
}
