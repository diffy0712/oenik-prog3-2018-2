// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IContainerRepository.cs" company="PlaceholderCompany">
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
    public interface IContainerRepository : IRepository<Container>
    {
        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        IQueryable<Container> SearchAll(string search, Paginator paginator);

        /// <summary>
        ///     GetAggregatesByContainerType
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        IQueryable<AggregatesByContainerTypeDto> GetAggregatesByContainerType(string search, Paginator paginator);
    }
}