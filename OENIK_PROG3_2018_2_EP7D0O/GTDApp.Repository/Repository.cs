// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Repository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Repository
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using GTDApp.Data;
    using GTDApp.Repository.Interfaces;

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
        private readonly DbContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{TEntity}"/> class.
        ///      Repository
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public Repository(GtdEntityDataModel context)
        {
            this._context = context;
        }

        /// <summary>
        ///      Gets GtdEntityDataModel
        /// </summary>
        /// <value>GtdEntityDataModel instance</value>
        public GtdEntityDataModel GtdEntityDataModel
        {
            get { return this._context as GtdEntityDataModel; }
        }

        /// <summary>
        ///      Get an entity by id
        /// </summary>
        /// <param name="id">Id</param>
        /// <returns>TEntity</returns>
        public TEntity Get(int id)
        {
            return this._context.Set<TEntity>().Find(id);
        }

        /// <summary>
        ///      GetAll
        /// </summary>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> GetAll()
        {
            return this._context.Set<TEntity>();
        }

        /// <summary>
        ///      Find
        /// </summary>
        /// <param name="predicate">Predicate callback</param>
        /// <returns>IQueryable</returns>
        public IQueryable<TEntity> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().Where(predicate);
        }

        /// <summary>
        ///      SingleOrDefault
        /// </summary>
        /// <param name="predicate">Predicate callback</param>
        /// <returns>Some Entity</returns>
        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return this._context.Set<TEntity>().SingleOrDefault(predicate);
        }

        /// <summary>
        ///      Add
        /// </summary>
        /// <param name="entity">Some Entity</param>
        public void Add(TEntity entity)
        {
            this._context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        ///      Remove
        /// </summary>
        /// <param name="entity">Some Entity</param>
        public void Remove(TEntity entity)
        {
            this._context.Set<TEntity>().Remove(entity);
        }
    }
}