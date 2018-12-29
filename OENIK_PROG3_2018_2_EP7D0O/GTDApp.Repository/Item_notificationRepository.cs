// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Repository
{
    using System.Linq;
    using GTDApp.Data;
    using GTDApp.Repository.Interfaces;

    /// <summary>
    ///      ContainerRepository
    /// </summary>
    public class Item_notificationRepository : Repository<Item_notification>, IItem_NotificationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Item_notificationRepository"/> class.
        ///      ItemRepository
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public Item_notificationRepository(GtdEntityDataModel context)
            : base(context)
        {
        }

        /// <summary>
        ///      GtdEntityDataModel
        /// </summary>
        /// <returns>GtdEntityDataModel</returns>
        public GtdEntityDataModel GtdEntityDataModel
        {
            get { return Context as GtdEntityDataModel; }
        }
    }
}