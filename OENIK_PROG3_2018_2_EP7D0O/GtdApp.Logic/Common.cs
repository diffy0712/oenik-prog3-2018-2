// <summary>
// GTD(getting things done) Application
// </summary>
// <copyright file="Common.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace GtdApp.Logic
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using GtdApp.Logic.Exceptions;

    /// <summary>
    ///      Common
    /// </summary>
    public class Common
    {
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
