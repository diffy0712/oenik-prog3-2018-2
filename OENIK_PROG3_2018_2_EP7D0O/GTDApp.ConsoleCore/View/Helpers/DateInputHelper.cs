// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DateInputHelper.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.ConsoleCore.Views.Helpers
{
    using System;
    using System.Collections.Generic;
    using GTDApp.Repository;
    using Terminal.Gui;

    /// <summary>
    ///     DateInputHelper
    /// </summary>
    public class DateInputHelper
    {
        private const int FRAME_HEIGHT = 15;
        private const int FRAME_WIDTH = 30;

        /// <summary>
        ///     DateTime
        /// </summary>
        DateTime DateTime;

        /// <summary>
        ///     x
        /// </summary>
        private readonly int x;

        /// <summary>
        ///     y
        /// </summary>
        private readonly int y;

        private TextField YearText;
        private TextField MonthText;
        private TextField DayText;
        private TextField HourText;
        private TextField MinuteText;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateInputHelper"/> class.
        ///     DateInputHelper
        /// </summary>
        /// <param name="x">X parameter</param>
        /// <param name="y">Y parameter</param>
        /// <param name="paginator">Paginator instance</param>
        public DateInputHelper(int x, int y, DateTime DateTime)
        {
            this.x = x;
            this.y = y;
            
            this.DateTime = DateTime;
        }

        public DateTime? GetOutput()
        {
            try
            {
                int year = int.Parse(this.YearText.Text.ToString());
                int month = int.Parse(this.MonthText.Text.ToString());
                int day = int.Parse(this.DayText.Text.ToString());
                int hour = int.Parse(this.HourText.Text.ToString());
                int minute = int.Parse(this.MinuteText.Text.ToString());

                DateTime dateTime = new DateTime(year, month, day, hour, minute, 0);
                return dateTime;
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        ///     Render
        /// </summary>
        /// <returns>List</returns>
        /// <param name="paginatorAction">Paginator action to call on events</param>
        public void Render(Window win, string title)
        {
            var year = new Label("Year: ")
            {
                X = 1,
                Y = 1,
            };
            var month = new Label("Month: ")
            {
                X = Pos.Left(year),
                Y = Pos.Bottom(year) + 1,
                Width = 12
            };
            var day = new Label("Day: ")
            {
                X = Pos.Left(month),
                Y = Pos.Bottom(month) + 1,
                Width = 12
            };
            var hour = new Label("Hour: ")
            {
                X = Pos.Left(day),
                Y = Pos.Bottom(day) + 3,
                Width = 12
            };
            var minute = new Label("Minute: ")
            {
                X = Pos.Left(hour),
                Y = Pos.Bottom(hour) + 1,
                Width = 12
            };
            this.YearText = new TextField(DateTime.Year.ToString())
            {
                X = Pos.Right(month),
                Y = Pos.Top(year),
                Width = 12
            };
            this.MonthText = new TextField(DateTime.Month.ToString())
            {
                X = Pos.Left(this.YearText),
                Y = Pos.Top(month),
                Width = Dim.Width(this.YearText),
            };
            this.DayText = new TextField(DateTime.Day.ToString())
            {
                X = Pos.Left(this.MonthText),
                Y = Pos.Top(day),
                Width = Dim.Width(this.MonthText),
            };
            this.HourText = new TextField(DateTime.Hour.ToString())
            {
                X = Pos.Left(this.DayText),
                Y = Pos.Top(hour),
                Width = Dim.Width(this.DayText),
            };
            this.MinuteText = new TextField(DateTime.Minute.ToString())
            {
                X = Pos.Left(this.HourText),
                Y = Pos.Top(minute),
                Width = Dim.Width(this.HourText),
            };

            win.Add(
                new FrameView(new Rect(x, y, DateInputHelper.FRAME_WIDTH, DateInputHelper.FRAME_HEIGHT), title){
                    year,
                    this.YearText,
                    month,
                    this.MonthText,
                    day,
                    this.DayText,
                    hour,
                    this.HourText,
                    minute,
                    this.MinuteText,
                    }
            );
        }
    }
}
