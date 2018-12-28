// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerDTO.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic.DTO
{
    using GTDApp.Data;
    using GTDApp.Logic.Interfaces;

    /// <summary>
    ///     ContainerDTO
    /// </summary>
    public class ContainerDTO : IDTO
    {
        /// <summary>
        ///     Gets or sets Name
        /// </summary>
        /// <value>string</value>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets Purpose
        /// </summary>
        /// <value>string</value>
        public string Purpose { get; set; }

        /// <summary>
        ///     Gets or sets Principles
        /// </summary>
        /// <value>string</value>
        public string Principles { get; set; }

        /// <summary>
        ///     Gets or sets InvisionedOutcome
        /// </summary>
        /// <value>string</value>
        public string InvisionedOutcome { get; set; }

        /// <summary>
        ///     Gets or sets Type
        /// </summary>
        /// <value>string</value>
        public string Type { get; set; }

        public Container ConvertToEntity()
        {
            Container container = new Container();
            return UpdateEntity(container);
        }

        public Container UpdateEntity(Container container)
        {
            container.name = Name;
            container.purpose = Purpose;
            container.principles = Principles;
            container.invisioned_outcome = InvisionedOutcome;
            container.type = Type;

            return container;
        }
    }
}
