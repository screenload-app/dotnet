/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2014 Thomas Braun, Jens Klingen, Robin Krom, Francis Noel
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on Sourceforge: http://sourceforge.net/projects/ScreenLoad/
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 1 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Text;
using ScreenLoad.IniFile;
using ScreenLoadDownloadRuPlugin.Forms;
using ScreenLoadPlugin.Core;
using ScreenLoadDownloadRuPlugin.Utils;
using log4net;

namespace ScreenLoadDownloadRuPlugin
{

    /// <summary>
    /// Description of DownloadRuUtils.
    /// </summary>
    public static class DownloadRuUtils
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(DownloadRuUtils));
        private static readonly DownloadRuConfiguration Config = IniConfig.GetIniSection<DownloadRuConfiguration>();

        private const string RedirectUri = "https://download.ru/u/?";
        private const string UploadFileUri = "https://download.ru/f?locale=";
        private const string AuthorizeUri = "https://download.ru/oauth/authorize";
        private const string TokenUri = "https://download.ru/oauth/token";

        private const string UserAgent = "ScreenLoad";

        private static bool Authorize()
        {
            string authorizeUrl =
                $"{AuthorizeUri}?client_id={Constants.ClientId}&response_type=code&state=downloadru&redirect_uri={RedirectUri}";

            var loginForm = new LoginForm(Language.GetString(Constants.LanguagePrefix, LangKey.Authorize),
                new Size(1060, 600),
                authorizeUrl, RedirectUri);

            loginForm.ShowDialog();

            if (!loginForm.IsOk)
                return false;

            var callbackParameters = loginForm.CallbackParameters;

            if (callbackParameters == null || !callbackParameters.ContainsKey("code"))
                return false;

            string authorizationResponse = PostAndReturn(new Uri(TokenUri),
                $"grant_type=authorization_code&code={callbackParameters["code"]}&client_id={Constants.ClientId}&client_secret={Constants.ClientSecret}&redirect_uri={RedirectUri}");
            var authorization = JSONSerializer.Deserialize<Authorization>(authorizationResponse);

            Config.DownloadRuToken = authorization.AccessToken;
            IniConfig.Save();
            return true;
        }

        public static string PostAndReturn(Uri url, string postMessage)
        {
            HttpWebRequest webRequest = NetworkHelper.CreateWebRequest(url);
            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.KeepAlive = true;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.UserAgent = UserAgent;
            byte[] data = Encoding.UTF8.GetBytes(postMessage);
            using (var requestStream = webRequest.GetRequestStream())
            {
                requestStream.Write(data, 0, data.Length);
            }

            return NetworkHelper.GetResponseAsString(webRequest);
        }

        /// <summary>
        /// Upload parameters by post
        /// </summary>
        /// <param name="url"></param>
        /// <param name="parameters"></param>
        /// <returns>response</returns>
        public static string HttpPost(string url, IDictionary<string, object> parameters)
        {
            var webRequest = NetworkHelper.CreateWebRequest(url);
            webRequest.Method = "POST";
            webRequest.KeepAlive = true;
            webRequest.Credentials = CredentialCache.DefaultCredentials;
            webRequest.Accept = "application/json";
            webRequest.UserAgent = UserAgent;
            webRequest.Headers.Add("Authorization", "Bearer " + Config.DownloadRuToken);
            NetworkHelper.WriteMultipartFormData(webRequest, parameters);

            return NetworkHelper.GetResponseAsString(webRequest);
        }

        /// <summary>
        /// Do the actual upload to DownloadRu
        /// </summary>
        /// <param name="image">Image for downloadru upload</param>
        /// <param name="title">Title of downloadru upload</param>
        /// <param name="filename">Filename of downloadru upload</param>
        /// <returns>url to uploaded image</returns>
        public static FileEntry UploadToDownloadRu(SurfaceContainer image, string title, string filename)
        {
            while (true)
            {
                if (!Config.AnonymousAccess && string.IsNullOrEmpty(Config.DownloadRuToken))
                    if (!Authorize())
                        return null;

                IDictionary<string, object> parameters = new Dictionary<string, object>();
                parameters.Add("filename", image);

                string response;

                string sharedLink = (Config.SharedLink) ? "&shared=true" : "";

                try
                {
                    string locale = (Language.CurrentLanguage.Length > 1)
                        ? Language.CurrentLanguage.Substring(0, 2)
                        : "en";
                    string addAnonymKey = (Config.AnonymousAccess)
                        ? $"&anonym_key={Constants.AnonymousKey}"
                        : "";

                    if (Config.AnonymousAccess && !Config.SharedLink)
                        sharedLink = "&shared=true";

                    response = HttpPost(UploadFileUri + locale + sharedLink + addAnonymKey, parameters);
                }
                catch (UnauthorizedAccessException)
                {
                    Config.DownloadRuToken = null;
                    continue;
                }
                catch (WebException ex)
                {
                    if (ex.Status == WebExceptionStatus.ProtocolError)
                    {
                        Config.DownloadRuToken = null;
                        continue;
                    }

                    throw;
                }

                Log.DebugFormat("DownloadRu response: {0}", response);

                // Check if the token is wrong
                if ("wrong auth token".Equals(response))
                {
                    Config.DownloadRuToken = null;
                    IniConfig.Save();
                    continue;
                }

                var upload = JSONSerializer.Deserialize<Upload>(response);

                return upload.File;
            }
        }
    }
}