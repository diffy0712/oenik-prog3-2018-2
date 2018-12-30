// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="AggregatesByContainerTypeDto.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Data.Dto
{
    /// <summary>
    ///      ContainerRepository
    /// </summary>
    public class AggregatesByContainerTypeDto
    {
        /// <summary>
        ///      Gets or sets container_type
        /// </summary>
        /// <value>string</value>
        public string Container_type { get; set; }

        /// <summary>
        ///      Gets or sets container_count
        /// </summary>
        /// <value>int</value>
        public int Container_count { get; set; }

        /// <summary>
        ///      Gets or sets item_count
        /// </summary>
        /// <value>int</value>
        public int Item_count { get; set; }


        /// <summary>
        ///      Gets or sets notification_count
        /// </summary>
        /// <value>int</value>
        public int Notification_count { get; set; }
    }
}
