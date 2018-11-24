﻿// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Repository
{
    using GTDApp.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class ContainerRepository : Repository<Container>, IContainerRepository
    {
        public ContainerRepository(GtdEntityDataModel context)
            : base(context)
        {
        }

        public IEnumerable<Container> GetTopSellingCourses(int count)
        {
            return GtdEntityDataModel.Container.OrderByDescending(c => c.container_id).Take(count).ToList();
        }

        public IEnumerable<Container> GetCoursesWithAuthors(int pageIndex, int pageSize = 10)
        {
            return GtdEntityDataModel.Container
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();
        }

        public GtdEntityDataModel GtdEntityDataModel
        {
            get { return Context as GtdEntityDataModel; }
        }
    }
}