// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Paginator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GTDApp.Repository
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
        private int _currentPage = 1;

        /// <summary>
        ///     Gets or sets _perPage
        /// </summary>
        /// <value>int</value>
        private int _perPage = 5;

        /// <summary>
        ///     Gets or sets _maximum
        /// </summary>
        /// <value>int</value>
        private int _maximum;

        /// <summary>
        ///     Gets Skip
        /// </summary>
        /// <value>int</value>
        public int Skip
        {
            get => (this._currentPage - 1) * this._perPage;
        }

        /// <summary>
        ///     Gets or sets Maximum
        /// </summary>
        /// <value>int</value>
        public int Maximum {
            get
            {
                return this._maximum;
            }

            set
            {
                this._maximum = value;

                if (this._currentPage > this.MaximumPage)
                {
                    this._currentPage = 1;
                }
            }
        }

        /// <summary>
        ///     Gets or sets PerPage
        /// </summary>
        /// <value>int</value>
        public int PerPage { get { return this._perPage; } set { this._perPage = value; } }

        /// <summary>
        ///     Gets or sets CurrentPage
        /// </summary>
        /// <value>int</value>
        public int CurrentPage { get { return this._currentPage; } set { this._currentPage = value; } }

        /// <summary>
        ///     Gets MaximumPage
        /// </summary>
        /// <value>int</value>
        public int MaximumPage
        {
            get => (int)Math.Ceiling((double)this.Maximum / this._perPage);
        }

        /// <summary>
        ///     Increments current page by one
        /// </summary>
        public void Next()
        {
            if (this.IsNext())
            {
                this._currentPage++;
            }
        }

        /// <summary>
        ///     Decremenets current page by one
        /// </summary>
        public void Prev()
        {
            if (this.IsPrev())
            {
                this._currentPage--;
            }
        }

        /// <summary>
        ///     Checks whather there is a previous page or not.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsPrev()
        {
            return this._currentPage > 1;
        }

        /// <summary>
        ///     Checks whather there is a next page or not.
        /// </summary>
        /// <returns>bool</returns>
        public bool IsNext()
        {
            return this.MaximumPage > this._currentPage;
        }
    }
}
