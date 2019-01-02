// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerBusinessLogicTests.cs" company="PlaceholderCompany">
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
    ///      ContainerBusinessLogicTests
    /// </summary>
    public class ContainerBusinessLogicTests : BusinessLogicTests
    {
        /// <summary>
        ///     Test the save method's calling for insertion (container_id is not declared)
        /// </summary>
        [Test]
        public void DoesSaveContainerAddsNewContainer()
        {
            Container testNewContainer = new Container()
            {
                name = $"Test Controller#01",
                principles = $"Test Principle#01",
                type = $"TestType#01",
                purpose = $"Test Purpose#01",
                updated_at = default(DateTime),
                created_at = default(DateTime)
            };

            this.BusinessLogic.SaveContainer(testNewContainer);
            this.MockContainer.Verify(x => x.Add(testNewContainer), Times.Once);
        }

        /// <summary>
        ///     Test the delete method's calling for deletion
        /// </summary>
        [Test]
        public void DoesRemoveContainerRemovesContainer()
        {
            Container testNewContainer = this.MockContainer.Object.GetAll().First();
            this.BusinessLogic.RemoveContainer(testNewContainer);
            this.MockContainer.Verify(x => x.Remove(testNewContainer), Times.Once);
        }

        /// <summary>
        ///     Test if the container is removable if it has no item.
        /// </summary>
        [Test]
        public void IsContainerRemovableIfHasNoItems()
        {
            Container testNewContainer = this.MockContainer.Object.GetAll().First();
            Assert.That(this.BusinessLogic.IsContainerRemovable(testNewContainer), Is.EqualTo(true));
        }

        /// <summary>
        ///     Test the save method's calling for insertion (container_id is not declared)
        /// </summary>
        [Test]
        public void IsContainerNotRemovableIfHasItems()
        {
            Container testNewContainer = this.MockContainer.Object.GetAll().ElementAt(3);
            Assert.That(this.BusinessLogic.IsContainerRemovable(testNewContainer), Is.EqualTo(false));
        }
    }
}
