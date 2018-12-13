// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="BusinessLogic.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic
{
    using System.Data.Entity;
    using System.Net;
    using GTDApp.Data;
    using GTDApp.Logic.Exceptions;
    using GTDApp.Logic.Interfaces;
    using GTDApp.Repository;

    /// <summary>
    ///      BusinessLogic
    /// </summary>
    public class BusinessLogic
    {
        /// <summary>
        ///      BusinessLogic
        /// </summary>
        private GtdEntityDataModel context;

        /// <summary>
        ///      BusinessLogic
        /// </summary>
        private IContainerRepository containerRepository;

        /// <summary>
        ///      exceptionHandler
        /// </summary>
        private IExceptionHandler exceptionHandler;

        /// <summary>
        ///      BusinessLogic
        /// </summary>
        public static BusinessLogic Init()
        {
            GtdEntityDataModel Context = new GtdEntityDataModel();
            IContainerRepository ContainerRepository = new ContainerRepository(Context);
            IExceptionHandler ExceptionHandler = new DetailedExceptionHandler();

            BusinessLogic businessLogic = new BusinessLogic()
            {
                context = Context,
                containerRepository = ContainerRepository,
                exceptionHandler = ExceptionHandler
            };

            return businessLogic;
        }

        /// <summary>
        ///      Gets or sets Context
        /// </summary>
        /// <value>GtdEntityDataModel</value>
        public GtdEntityDataModel Context { get => context; set => context = value; }

        /// <summary>
        ///      Gets or sets ContainerRepository
        /// </summary>
        /// <value>ContainerRepository</value>
        public IContainerRepository ContainerRepository { get => containerRepository; set => containerRepository = value; }

        /// <summary>
        ///      Gets or sets ExceptionHandler
        /// </summary>
        /// <value>ExceptionHandler</value>
        public IExceptionHandler ExceptionHandler { get => exceptionHandler; set => exceptionHandler = value; }

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
        public bool RemoveContainer(Container container)
        {
            ContainerRepository.Remove(container);
            Context.SaveChanges();

            return false;
        }
    }
}
