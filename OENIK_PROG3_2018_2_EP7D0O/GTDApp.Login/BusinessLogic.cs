// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="BusinessLogic.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic
{
    using GTDApp.Data;
    using GTDApp.Repository;

    /// <summary>
    ///      BusinessLogic
    /// </summary>
    public class BusinessLogic
    {
        /// <summary>
        ///      BusinessLogic
        /// </summary>
        private static GtdEntityDataModel context;

        /// <summary>
        ///      BusinessLogic
        /// </summary>
        private static ContainerRepository containerRepository;

        /// <summary>
        /// Initializes static members of the <see cref="BusinessLogic"/> class.
        ///      BusinessLogic
        /// </summary>
        static BusinessLogic()
        {
            Context = new GtdEntityDataModel();
            ContainerRepository = new ContainerRepository(Context);
        }

        /// <summary>
        ///      Gets or sets Context
        /// </summary>
        /// <value>GtdEntityDataModel</value>
        public static GtdEntityDataModel Context { get => context; set => context = value; }

        /// <summary>
        ///      Gets or sets ContainerRepository
        /// </summary>
        /// <value>ContainerRepository</value>
        public static ContainerRepository ContainerRepository { get => containerRepository; set => containerRepository = value; }

        /// <summary>
        ///      A container is empty if it has no item and no stroage.
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <returns>Boolean</returns>
        public static bool IsContainerRemovable(Container container)
        {
            return container.Container_item.Count == 0 && container.Container_storage.Count == 0;
        }

        /// <summary>
        ///      RemoveContainer
        /// </summary>
        /// <param name="container">Container instance</param>
        /// <returns>Boolean</returns>
        public static bool RemoveContainer(Container container)
        {
            ContainerRepository.Remove(container);
            Context.SaveChanges();

            return false;
        }
    }
}
