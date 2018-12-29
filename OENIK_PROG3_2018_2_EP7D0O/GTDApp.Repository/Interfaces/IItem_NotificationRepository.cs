// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IItem_NotificationRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>


namespace GTDApp.Repository.Interfaces
{
    using System.Linq;
    using GTDApp.Data;
    using GTDApp.Data.Dto;

    /// <summary>
    ///     IContainerRepository
    /// </summary>
    public interface IItem_NotificationRepository : IRepository<Item_notification>
    {
        IQueryable<UpcomingNotificationsDto> GetUpcomingNotifications(string search, Paginator paginator);
    }
}