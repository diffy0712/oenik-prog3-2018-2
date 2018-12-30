// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="DateInputHelper.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.ConsoleCore.Views.Helpers
{
    using System;
    using Terminal.Gui;

    /// <summary>
    ///     DateInputHelper
    /// </summary>
    public class DateInputHelper
    {
        /// <summary>
        ///     FRAMEHEIGHT
        /// </summary>
        private const int FRAMEHEIGHT = 15;

        /// <summary>
        ///     FRAMEWIDTH
        /// </summary>
        private const int FRAMEWIDTH = 30;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateInputHelper"/> class.
        ///     DateInputHelper
        /// </summary>
        /// <param name="x">X parameter</param>
        /// <param name="y">Y parameter</param>
        /// <param name="dateTime">DateTime</param>
        public DateInputHelper(int x, int y, DateTime dateTime)
        {
            this.X = x;
            this.Y = y;
            this.DateTime = dateTime;
        }

        /// <summary>
        ///     Gets or sets DateTime
        /// </summary>
        /// <value>DateTime</value>
        public DateTime DateTime { get; set; }

        /// <summary>
        ///     Gets or sets YearText
        /// </summary>
        /// <value>TextField</value>
        private TextField YearText { get; set; }

        /// <summary>
        ///     Gets or sets MonthText
        /// </summary>
        /// <value>TextField</value>
        private TextField MonthText { get; set; }

        /// <summary>
        ///     Gets or sets DayText
        /// </summary>
        /// <value>TextField</value>
        private TextField DayText { get; set; }

        /// <summary>
        ///     Gets or sets HourText
        /// </summary>
        /// <value>TextField</value>
        private TextField HourText { get; set; }

        /// <summary>
        ///     Gets or sets MinuteText
        /// </summary>
        /// <value>TextField</value>
        private TextField MinuteText { get; set; }

        /// <summary>
        ///     Gets or sets X
        /// </summary>
        /// <value>int</value>
        private int X { get; set; }

        /// <summary>
        ///     Gets or sets Y
        /// </summary>
        /// <value>int</value>
        private int Y { get; set; }

        /// <summary>
        ///     GetOutput
        /// </summary>
        /// <returns>DateTime</returns>
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
        /// <param name="win">Window</param>
        /// <param name="title">Title</param>
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
            this.YearText = new TextField(this.DateTime.Year.ToString())
            {
                X = Pos.Right(month),
                Y = Pos.Top(year),
                Width = 12
            };
            this.MonthText = new TextField(this.DateTime.Month.ToString())
            {
                X = Pos.Left(this.YearText),
                Y = Pos.Top(month),
                Width = Dim.Width(this.YearText),
            };
            this.DayText = new TextField(this.DateTime.Day.ToString())
            {
                X = Pos.Left(this.MonthText),
                Y = Pos.Top(day),
                Width = Dim.Width(this.MonthText),
            };
            this.HourText = new TextField(this.DateTime.Hour.ToString())
            {
                X = Pos.Left(this.DayText),
                Y = Pos.Top(hour),
                Width = Dim.Width(this.DayText),
            };
            this.MinuteText = new TextField(this.DateTime.Minute.ToString())
            {
                X = Pos.Left(this.HourText),
                Y = Pos.Top(minute),
                Width = Dim.Width(this.HourText),
            };

            win.Add(
                new FrameView(new Rect(this.X, this.Y, DateInputHelper.FRAMEWIDTH, DateInputHelper.FRAMEHEIGHT), title)
                {
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
                    });
        }
    }
}
