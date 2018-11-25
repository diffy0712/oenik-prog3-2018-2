// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="ContainerController.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>


namespace GTDApp.Repository
{
    using System;
    using System.Linq;

    /// <summary>
    ///     ContainerController
    /// </summary>
    public class Paginator
    {
        public int CurrentPage = 1;
        public int PerPage = 5;
        public int Skip { get => (CurrentPage - 1) * PerPage; }
        private int maximum;
        public int Maximum {
            get { return maximum; }
            set
            {
                this.maximum = value;

                if (CurrentPage > MaximumPage)
                {
                    CurrentPage = 1;
                }
            }
        }
        private int maximumPage;

        public int MaximumPage { get => (int)Math.Ceiling((double)Maximum / PerPage); }
       
        public void Next()
        {
            if( IsNext())
            {
                CurrentPage++;
            }
        }

        public void Prev()
        {
            if (IsPrev())
            {
                CurrentPage--;
            }
        }

        public bool IsPrev()
        {
            return (CurrentPage > 1);
        }

        public bool IsNext()
        {
            return (MaximumPage > CurrentPage);
        }
    }
}
