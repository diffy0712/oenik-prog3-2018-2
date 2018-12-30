// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Repository
{
    using System.Linq;
    using GtdApp.Data;
    using GtdApp.Data.Dto;
    using GtdApp.Repository.Interfaces;

    /// <summary>
    ///      ContainerRepository
    /// </summary>
    public class ContainerRepository : Repository<Container>, IContainerRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerRepository"/> class.
        ///      Repository
        /// </summary>
        /// <param name="context">DbContext instance</param>
        public ContainerRepository(GtdEntityDataModel context)
            : base(context)
        {
        }

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<Container> SearchAll(string search, Paginator paginator)
        {
            var g = this.GtdEntityDataModel.Container
                .Include("Item")
                .OrderByDescending(x => x.Item.Count)
                .Where(p => p.name.Contains(search));

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///     SearchAll
        /// </summary>
        /// <param name="search">String</param>
        /// <param name="paginator">Paginator instance</param>
        /// <returns>IQueryable</returns>
        public IQueryable<AggregatesByContainerTypeDto> GetAggregatesByContainerType(string search, Paginator paginator)
        {
            var g = from container in this.GtdEntityDataModel.Container
                    group container by container.type into c
                    orderby c.Key
                    select new AggregatesByContainerTypeDto()
                    {
                        Container_type = c.Key,
                        Container_count = c.Count(),
                        Item_count = c.Sum(x => x.Item.Count()),
                        Notification_count = c.Sum(x => (int?)x.Item.Sum(t => (int?)t.Item_notification.Count() ?? 0) ?? 0)
                    };

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///      GetAll
        /// </summary>
        /// <returns>IQueryable</returns>
        /// <param name="paginator">Paginator instance</param>
        public IQueryable<Container> GetAll(Paginator paginator)
        {
            var g = this.GtdEntityDataModel.Container.OrderBy(x => x.container_id);

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///      GetMostRecentContainers
        /// </summary>
        /// <returns>IQueryable</returns>
        /// <param name="count">int</param>
        public IQueryable<Container> GetMostRecentContainers(int count)
        {
            return this.GtdEntityDataModel.Container.OrderByDescending(c => c.container_id).Take(count);
        }
    }
}