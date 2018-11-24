// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IContainerRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>


namespace GTDApp.Repository
{
    using GTDApp.Data;
    using System.Collections.Generic;

    /// <summary>
    ///     IContainerRepository
    /// </summary>
    public interface IContainerRepository : IRepository<Container>
    {
        IEnumerable<Container> GetTopSellingCourses(int count);
        IEnumerable<Container> GetCoursesWithAuthors(int pageIndex, int pageSize);
    }
}