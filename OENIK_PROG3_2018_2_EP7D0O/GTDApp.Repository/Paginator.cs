// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Paginator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Repository
{
    using System;

    /// <summary>
    ///     ContainerController
    /// </summary>
    public class Paginator
    {
        /// <summary>
        ///     Gets or sets CurrentPage
        /// </summary>
        /// <value>int</value>
        private int currentPage = 1;

        /// <summary>
        ///     Gets or sets _perPage
        /// </summary>
        /// <value>int</value>
        private int perPage = 5;

        /// <summary>
        ///     Gets or sets _maximum
        /// </summary>
        /// <value>int</value>
        private int maximum;

        /// <summary>
        ///     Gets Skip
        /// </summary>
        /// <value>int</value>
        public int Skip
        {
            get => (this.currentPage - 1) * this.perPage;
        }

        /// <summary>
        ///     Gets or sets Maximum
        /// </summary>
        /// <value>int</value>
        public int Maximum
        {
            get
            {
                return this.maximum;
            }

            set
            {
                this.maximum = value;

                if (this.currentPage > this.MaximumPage)
                {
                    this.currentPage = 1;
                }
            }
        }

        /// <summary>
        ///     Gets or sets PerPage
        /// </summary>
        /// <value>int</value>
        public int PerPage
        {
            get
            {
                return this.perPage;
            }

            set
            {
                this.perPage = value;
            }
        }

        /// <summary>
        ///     Gets or sets CurrentPage
        /// </summary>
        /// <value>int</value>
        public int CurrentPage
        {
            get
            {
                return this.currentPage;
            }

            set
            {
                this.currentPage = value;
            }
        }

        /// <summary>
        ///     Gets MaximumPage
        /// </summary>
        /// <value>int</value>
        public int MaximumPage
        {
            get => (int)Math.Ceiling((double)this.Maximum / this.perPage);
        }

        /// <summary>
        ///     Increments current page by one
        /// </summary>
        public void Next()
        {
            if (this.IsNext())
            {
                this.currentPage++;
            }
        }

        /// <summary>
        ///     Decremenets current page by one
        /// </summary>
        public void Prev()
        {
            if (this.IsPrev())
            {
                this.currentPage--;
            }
        }

        /// <summary>
        ///     Checks whather there is a previous page or not.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsPrev()
        {
            return this.currentPage > 1;
        }

        /// <summary>
        ///     Checks whather there is a next page or not.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsNext()
        {
            return this.MaximumPage > this.currentPage;
        }
    }
}
