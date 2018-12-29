// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IItemRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Repository.Interfaces
{
    using System.Linq;
    using GTDApp.Data;

    /// <summary>
    ///     IItemRepository
    /// </summary>
    public interface IItemRepository : IRepository<Item>
    {

        /// <summary>
        ///     GetMostRecentItems
        /// </summary>
        /// <param name="count">Number of items</param>
        /// <returns>IQueryable</returns>
        IQueryable<Item> GetMostRecentItems(int count);

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        IQueryable<Item> SearchAll(string search, Paginator paginator);

        /// <summary>
        ///     SearchAllByContainer
        /// </summary>
        /// <param name="container">Container</param>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable Item</returns>
        IQueryable<Item> SearchAllByContainer(Container container, string search, Paginator paginator);
    }
}