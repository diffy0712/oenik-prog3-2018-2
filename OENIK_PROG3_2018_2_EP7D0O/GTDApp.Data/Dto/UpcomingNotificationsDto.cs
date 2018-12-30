// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="UpcomingNotificationsDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Data.Dto
{
    using System;

    /// <summary>
    ///      ContainerRepository
    /// </summary>
    public class UpcomingNotificationsDto
    {
        /// <summary>
        ///      Gets or sets Container_type
        /// </summary>
        /// <value>string</value>
        public DateTime? Day { get; set; }

        /// <summary>
        ///      Gets or sets Item_count
        /// </summary>
        /// <value>int</value>
        public int Item_count { get; set; }

        /// <summary>
        ///      Gets or sets Notification_count
        /// </summary>
        /// <value>int</value>
        public int Notification_count { get; set; }
    }
}
