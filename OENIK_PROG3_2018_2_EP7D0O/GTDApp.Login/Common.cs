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
    using System.Net;
    using GTDApp.Logic.Exceptions;

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

        /// <summary>
        ///      JavaWebCall
        /// </summary>
        /// <param name="apiUrl">Url of api endpoint, which should return a json string</param>
        /// <returns>string</returns>
        public static string JSONApiCall(string apiUrl)
        {
            try
            {
                WebClient webClient = new WebClient();
                string content = webClient.DownloadString(apiUrl);
                return content;
            }
            catch (System.Net.WebException ex)
            {
                throw new JSONApiCallFailedException(ex.Message);
            }
        }
    }
}
