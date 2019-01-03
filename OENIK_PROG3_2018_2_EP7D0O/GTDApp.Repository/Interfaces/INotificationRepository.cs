// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="INotificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Repository.Interfaces
{
    using System.Linq;
    using GtdApp.Data;
    using GtdApp.Data.Dto;

    /// <summary>
    ///     IContainerRepository
    /// </summary>
    public interface INotificationRepository : IRepository<Notification>
    {
        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        IQueryable<Notification> SearchAll(string search, Paginator paginator);

        /// <summary>
        ///     GetAggregatesByNotificationType
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        IQueryable<AggregatesByNotificationTypeDto> GetAggregatesByNotificationType(string search, Paginator paginator);
    }
}