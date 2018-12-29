// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IItem_NotificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Repository.Interfaces
{
    using System.Linq;
    using GTDApp.Data;
    using GTDApp.Data.Dto;

    /// <summary>
    ///     IContainerRepository
    /// </summary>
    public interface IItem_NotificationRepository : IRepository<Item_notification>
    {
        /// <summary>
        ///     GetUpcomingNotifications
        /// </summary>
        /// <param name="search">Search string</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>UpcomingNotificationsDto as IQueryable</returns>
        IQueryable<UpcomingNotificationsDto> GetUpcomingNotifications(string search, Paginator paginator);
    }
}