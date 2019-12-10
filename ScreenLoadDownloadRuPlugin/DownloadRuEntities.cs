/*
 * ScreenLoad - a free and open source screenshot tool
 * Copyright (C) 2007-2014 Thomas Braun, Jens Klingen, Robin Krom, Francis Noel
 * 
 * For more information see: http://getgreenshot.org/
 * The ScreenLoad project is hosted on download.ru: https://download.ru/ScreenLoad/
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
using System.Runtime.Serialization;
using System.Text;
using System.Web;

namespace ScreenLoadDownloadRuPlugin
{
    [DataContract]
    public class Authorization
    {
        [DataMember(Name = "access_token")] public string AccessToken { get; set; }
        [DataMember(Name = "expires_in")] public int ExpiresIn { get; set; }
        [DataMember(Name = "refresh_token")] public string RefreshToken { get; set; }
        [DataMember(Name = "token_type")] public string TokenType { get; set; }
    }

    [DataContract]
    public class SharedLink
    {
        [DataMember(Name = "url")] public string Url { get; set; }
        [DataMember(Name = "download_url")] public string DownloadUrl { get; set; }
    }

    [DataContract]
    public class UrlsEntry
    {
        [DataMember(Name = "large")] public string Large { get; set; }
    }

    [DataContract]
    public class PreviewEntry
    {
        [DataMember(Name = "urls")] public UrlsEntry UrlsEntry { get; set; }
    }

    [DataContract]
    public class FileEntry
    {
        private string _directLink;

        [DataMember(Name = "id")] public string Id { get; set; }
        [DataMember(Name = "name")] public string Name { get; set; }
        [DataMember(Name = "preview")] public PreviewEntry Preview { get; set; }
        [DataMember(Name = "secure_url")] public string SecureUrl { get; set; }

        [IgnoreDataMember]
        public string DirectLink
        {
            get
            {
                if (null == _directLink)
                {
                    var secureUrl = $"https://download.ru{SecureUrl}";

                    var uri = new Uri(secureUrl);

                    var queryParameters = HttpUtility.ParseQueryString(uri.Query);
                    queryParameters["inline"] = "true";

                    var queryString = new StringBuilder();

                    bool first = true;

                    foreach (string queryParameter in queryParameters)
                    {
                        var value = queryParameters[queryParameter];

                        value = HttpUtility.UrlEncode(value, Encoding.UTF8);

                        if (first)
                            first = false;
                        else
                            queryString.Append("&");

                        queryString.Append(queryParameter);
                        queryString.Append("=");
                        queryString.Append(value);
                    }

                    var uriBuilder = new UriBuilder(uri.Scheme, uri.Host, uri.Port, uri.AbsolutePath);

                    _directLink = $"{uriBuilder.Uri.AbsoluteUri}?{queryString}";
                }

                return _directLink;
            }
        }

        [IgnoreDataMember]
        public string PageLink => $"https://download.ru/f/{Id}";
    }

    [DataContract]
    public class Upload
    {
        [DataMember(Name = "object")] public FileEntry File { get; set; }
    }
}