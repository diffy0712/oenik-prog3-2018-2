﻿// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ItemRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Repository
{
    using System.Linq;
    using GtdApp.Data;
    using GtdApp.Repository.Interfaces;

    /// <summary>
    ///      ContainerRepository
    /// </summary>
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ItemRepository"/> class.
        ///      ItemRepository
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public ItemRepository(GtdEntityDataModel context)
            : base(context)
        {
        }

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Item> SearchAll(string search, Paginator paginator)
        {
            var g = this.GtdEntityDataModel.Item
                .Include("Item_notifications")
                .OrderByDescending(x => x.Item_notification.Count)
                .Where(p => p.title.Contains(search));

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="container">int</param>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Item> SearchAllByContainer(Container container, string search, Paginator paginator)
        {
            var g = from item in this.GtdEntityDataModel.Item
                    where item.container_id == container.container_id
                    where item.title.Contains(search)
                    orderby item.item_id
                    select item;

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///      GetAll
        /// </summary>
        /// <returns>IQueryable</returns>
        /// <param name="paginator">Paginator instance</param>
        public IQueryable<Item> GetAll(Paginator paginator)
        {
            var g = this.GtdEntityDataModel.Item.OrderBy(x => x.item_id);

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///      GetMostRecentItems
        /// </summary>
        /// <returns>IQueryable</returns>
        /// <param name="count">int</param>
        public IQueryable<Item> GetMostRecentItems(int count)
        {
            return this.GtdEntityDataModel.Item.OrderByDescending(c => c.item_id).Take(count);
        }
    }
}