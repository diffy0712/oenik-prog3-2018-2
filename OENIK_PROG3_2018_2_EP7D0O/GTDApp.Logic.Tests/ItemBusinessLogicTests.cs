// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ItemBusinessLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests
{
    using System;
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
    }
}
