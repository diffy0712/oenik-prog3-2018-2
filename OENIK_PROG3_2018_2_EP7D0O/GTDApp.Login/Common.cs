// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Common.cs" company="OENIK_PROG3_2018_2_EP7D0O">
// Copyright © OENIK_PROG3_2018_2_EP7D0O All rights reserved.
// </copyright>

namespace GTDApp.Logic
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///      Common
    /// </summary>
    public class Common
    {
        /// <summary>
        ///      DisplayCamelCaseString
        /// </summary>
        /// <param name="camelCase">Camel case string</param>
        /// <returns>String</returns>
        public static string DisplayCamelCaseString(string camelCase)
        {
            List<char> chars = new List<char>();
            chars.Add(camelCase[0]);
            foreach (char c in camelCase.Skip(1))
            {
                if (char.IsUpper(c))
                {
                    chars.Add(' ');
                    chars.Add(char.ToLower(c));
                }
                else
                {
                    chars.Add(c);
                }
            }

            return new string(chars.ToArray());
        }
    }
}
