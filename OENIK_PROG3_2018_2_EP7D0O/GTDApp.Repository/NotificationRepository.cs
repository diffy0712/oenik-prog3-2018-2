// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="NotificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Repository
{
    using System.Linq;
    using GTDApp.Data;
    using GTDApp.Repository.Interfaces;

    /// <summary>
    ///      ContainerRepository
    /// </summary>
    public class NotificationRepository : Repository<Notification>, INotificationRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
        ///      Repository
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public NotificationRepository(GtdEntityDataModel context)
            : base(context)
        {
        }

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Notification> SearchAll(string search, Paginator paginator)
        {
            var g = from notification in this.GtdEntityDataModel.Notification
                    where notification.name.Contains(search)
                    orderby notification.name
                    select notification;

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///     GetUpcomingNotifications
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Notification> GetUpcomingNotifications(string search, Paginator paginator)
        {
            var g = from notification in this.SearchAll(search, paginator)
                    select notification;

            return g;
        }

        /// <summary>
        ///      GetAll
        /// </summary>
        /// <returns>IQueryable</returns>
        /// <param name="paginator">Paginator instance</param>
        public IQueryable<Notification> GetAll(Paginator paginator)
        {
            var g = this.GtdEntityDataModel.Notification.OrderBy(x => x.notification_id);

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }
    }
}