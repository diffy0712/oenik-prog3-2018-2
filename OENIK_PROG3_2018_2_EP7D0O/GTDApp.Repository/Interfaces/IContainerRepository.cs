// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IContainerRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>


namespace GTDApp.Repository
{
    using System.Linq;
    using GTDApp.Data;

    /// <summary>
    ///     IContainerRepository
    /// </summary>
    public interface IContainerRepository : IRepository<Container>
    {

        /// <summary>
        ///     GetMostRecentContainers
        /// </summary>
        /// <param name="count">Number of items</param>
        /// <returns>IQueryable</returns>
        IQueryable<Container> GetMostRecentContainers(int count);

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        IQueryable<Container> SearchAll(string search, Paginator paginator);
    }
}