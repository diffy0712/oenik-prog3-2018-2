// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="BusinessLogic.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

using GTDApp.Data;
using GTDApp.Repository;

namespace GTDApp.Logic
{
    /// <summary>
    ///      BusinessLogic
    /// </summary>
    public class BusinessLogic
    {
        public static GtdEntityDataModel Context;
        public static ContainerRepository ContainerRepository;

        static BusinessLogic()
        {
            Context = new GtdEntityDataModel();
            ContainerRepository = new ContainerRepository(Context);
        }

    }
}
