// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="INotificationRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Repository.Interfaces
{
    using System.Linq;
    using GTDApp.Data;

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
    }
}