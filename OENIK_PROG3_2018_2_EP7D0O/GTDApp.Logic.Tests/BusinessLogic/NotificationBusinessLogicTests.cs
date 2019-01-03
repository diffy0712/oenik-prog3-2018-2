// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="NotificationBusinessLogicTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic.Tests.BusinessLogic
{
    using System;
    using System.Linq;
    using GtdApp.Data;
    using Moq;
    using NUnit.Framework;

    /// <summary>
    ///      NotificationBusinessLogicTests
    /// </summary>
    public class NotificationBusinessLogicTests : BusinessLogicTests
    {
        /// <summary>
        ///     Test the save method's calling for insertion (notification_id is not declared)
        /// </summary>
        [Test]
        public void DoesSaveNotificationAddsNewNotification()
        {
            Notification testNewNotification = new Notification()
            {
                name = $"Test Notification#01",
                type = "TestType",
                amount = 10,
                unit = "day",
                updated_at = default(DateTime),
                created_at = default(DateTime)
            };

            this.BusinessLogic.SaveNotification(testNewNotification);
            this.MockNotificationRepository.Verify(x => x.Add(testNewNotification), Times.Once);
        }

        /// <summary>
        ///     Test the delete method's calling for deletion
        /// </summary>
        [Test]
        public void DoesRemoveNotificationRemovesNotification()
        {
            Notification testNotification = this.Notifications.First();
            this.BusinessLogic.RemoveNotification(testNotification);
            this.MockNotificationRepository.Verify(x => x.Remove(testNotification), Times.Once);
        }

        /// <summary>
        ///     IsNotificationRemovableIfHasNoItem
        /// </summary>
        [Test]
        public void IsNotificationRemovableIfHasNoItem()
        {
            Notification testNotification = this.Notifications.ElementAt(4);
            Assert.That(this.BusinessLogic.IsNotificationRemovable(testNotification), Is.EqualTo(true));
        }

        /// <summary>
        ///     IsNotificationNotRemovableIfHasItems
        /// </summary>
        [Test]
        public void IsNotificationNotRemovableIfHasItems()
        {
            Notification testNotification = this.Notifications.ElementAt(3);
            Assert.That(this.BusinessLogic.IsNotificationRemovable(testNotification), Is.EqualTo(false));
        }
    }
}
