// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Program.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace OENIK_PROG3_2018_2_EP7D0O
{
    using System;

    /// <summary>
    ///     Entry Point
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main Program entry point
        /// </summary>
        public static void Main()
        {
            Console.WriteLine("Hello! This is a GTD app.");
            Console.WriteLine("Please select a menu item:");
            Console.WriteLine("lc: List Containers");
            Console.WriteLine("ac: Add Container");
            Console.WriteLine("rc: Remove Container");
            Console.WriteLine("mc: Modify Container");
            Console.WriteLine("li: List Items");
            Console.WriteLine("ai: Add Item");
            Console.WriteLine("ri: Remove Item");
            Console.WriteLine("mi: Modify Item");
            Console.WriteLine("r: Review");
            Console.WriteLine("r: Statistics");
            Console.WriteLine("javaweb: Java/web interaction");

            string menuSelect = Console.ReadLine();

            switch (menuSelect)
            {
                default:
                    Console.WriteLine("This is not ready");
                    break;
            }

            Console.ReadKey();
        }
    }
}
