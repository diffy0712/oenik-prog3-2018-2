// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Repository.Interfaces
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///     IRepository
    /// </summary>
    /// <typeparam name="TEntity">l</typeparam>
    public interface IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="id">Integer ID</param>
        /// <returns>TEntity</returns>
        TEntity Get(int id);

        /// <summary>
        ///     GetAll
        /// </summary>
        /// <returns>IQueryable</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        ///     Find
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>TEntity</returns>
        IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     SingleOrDefault
        /// </summary>
        /// <param name="predicate">Predicate</param>
        /// <returns>TEntity</returns>
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        ///     Get
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Add(TEntity entity);
        
        /// <summary>
        ///     Remove
        /// </summary>
        /// <param name="entity">TEntity</param>
        void Remove(TEntity entity);
    }
}