// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="IRepository.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Data.Dto
{
    using System.Linq;
    using GTDApp.Data;

    /// <summary>
    ///      ContainerRepository
    /// </summary>
    public class AggregatesByContainerTypeDto
    {
        public string container_type { get; set; }
        public int container_count { get; set; }
        public int item_count { get; set; }
        public int notification_count { get; set; }
    }
}
