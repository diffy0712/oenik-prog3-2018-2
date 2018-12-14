// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Repository
{
    using System.Linq;
    using GTDApp.Data;

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
            var g = GtdEntityDataModel.Container
                .Include("Container_item")
                .Include("Container_storage")
                .OrderByDescending(x => x.Container_item.Count)
                .Where(p => p.name.Contains(search));

            paginator.Maximum = g.Count();

            return g.Skip(paginator.Skip).Take(paginator.PerPage);
        }

        /// <summary>
        ///      GetAll
        /// </summary>
        /// <returns>IQueryable</returns>
        /// <param name="paginator">Paginator instance</param>
        public IQueryable<Container> GetAll(Paginator paginator)
        {
            var g = GtdEntityDataModel.Container.OrderBy(x => x.container_id);

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
            return GtdEntityDataModel.Container.OrderByDescending(c => c.container_id).Take(count);
        }

        /// <summary>
        ///      GtdEntityDataModel
        /// </summary>
        /// <returns>GtdEntityDataModel</returns>
        public GtdEntityDataModel GtdEntityDataModel
        {
            get { return Context as GtdEntityDataModel; }
        }
    }
}