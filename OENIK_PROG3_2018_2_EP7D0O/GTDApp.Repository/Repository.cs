// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    /// <summary>
    ///      Repository
    /// </summary>
    /// <typeparam name="TEntity">Some entity to make repository for</typeparam>
    public class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        /// <summary>
        ///      Gets or sets Context
        /// </summary>
        protected readonly DbContext Context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        ///      Repository
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public Repository(DbContext context)
        {
            Context = context;
        }

        /// <summary>
        ///      Get an entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>TEntity</returns>
        public TEntity Get(int id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///      GetAll
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> GetAll()
        {
            return Context.Set<TEntity>();
        }

        /// <summary>
        ///      Find
        /// </summary>
        /// <param name="predicate">Predicate callback</param>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        ///      SingleOrDefault
        /// </summary>
        /// <param name="predicate">Predicate callback</param>
        /// <returns>Some Entity</returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return Context.Set<TEntity>().SingleOrDefault(predicate);
        }

        /// <summary>
        ///      Add
        /// </summary>
        /// <param name="entity">Some Entity</param>
        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        ///      Remove
        /// </summary>
        /// <param name="entity">Some Entity</param>
        public void Remove(TEntity entity)
        {
            Context.Set<TEntity>().Remove(entity);
        }
    }
}