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
    using GTDApp.Data.Dto;
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

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Notification> SearchAll(string search, Paginator paginator)
        {
            var g = from notification in GtdEntityDataModel.Notification
                    where notification.name.Contains(search)
                    orderby notification.name
                    select notification;

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///     Returns the upcoming notifications. Grouped by the following 7 days!
        /// </summary>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<UpcomingNotificationsDto> GetUpcomingNotifications(string search, Paginator paginator)
        {
            var g = (
                from item in GtdEntityDataModel.Item
                where item.from_date != null
                group item by item.from_date into d
                select new UpcomingNotificationsDto()
                {
                    day = d.Key,
                    item_count = d.Count(),
                    notification_count = d.Sum(x => x.Item_notification.Count()),
                }
                ).OrderBy(d => d.day);

            return g;
        }
    }
}