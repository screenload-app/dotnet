/*
 * Greenshot - a free and open source screenshot tool
 * Copyright (C) 2007-2014 Thomas Braun, Jens Klingen, Robin Krom, Francis Noel
 * 
 * For more information see: http://getgreenshot.org/
 * The Greenshot project is hosted on Sourceforge: http://sourceforge.net/projects/greenshot/
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
using Greenshot.IniFile;
using GreenshotPlugin.Controls;
using GreenshotPlugin.Core;
using System.Runtime.Serialization.Json;
using System.IO;

namespace GreenshotDownloadRuPlugin {

	/// <summary>
	/// Description of DownloadRuUtils.
	/// </summary>
	public static class DownloadRuUtils {
        private static readonly log4net.ILog LOG = log4net.LogManager.GetLogger(typeof(DownloadRuUtils));
		private static readonly DownloadRuConfiguration Config = IniConfig.GetIniSection<DownloadRuConfiguration>();
		private const string RedirectUri = "https://download.ru/u/?";
		private const string UploadFileUri = "https://download.ru/f?locale=";
        private const string AuthorizeUri = "https://download.ru/oauth/authorize";
		private const string TokenUri = "https://download.ru/oauth/token";
		private const string UserAgent = "Greenshot";
        //private const string FilesUri = "https://www.box.com/api/2.0/files/{0}";

		private static bool Authorize() {
			string authorizeUrl = string.Format("{0}?client_id={1}&response_type=code&state=downloadru&redirect_uri={2}", AuthorizeUri, DownloadRuCredentials.ClientId, RedirectUri);

			OAuthLoginForm loginForm = new OAuthLoginForm("DownloadRu Authorize", new Size(1060, 600), authorizeUrl, RedirectUri);
			loginForm.ShowDialog();
			if (!loginForm.IsOk) {
				return false;
			}
			var callbackParameters = loginForm.CallbackParameters;
			if (callbackParameters == null || !callbackParameters.ContainsKey("code")) {
				return false;
			}

            string authorizationResponse = PostAndReturn(new Uri(TokenUri), string.Format("grant_type=authorization_code&code={0}&client_id={1}&client_secret={2}&redirect_uri={3}", callbackParameters["code"], DownloadRuCredentials.ClientId, DownloadRuCredentials.ClientSecret, RedirectUri));
			var authorization = JSONSerializer.Deserialize<Authorization>(authorizationResponse);

			Config.DownloadRuToken = authorization.AccessToken;
			IniConfig.Save();
			return true;
		}

        private static void AuthorizeAnonym()
        {

        }

		/// <summary>
		/// Download a url response as string
		/// </summary>
		/// <param name=url">An Uri to specify the download location</param>
		/// <returns>string with the file content</returns>
		public static string PostAndReturn(Uri url, string postMessage) {
			HttpWebRequest webRequest = (HttpWebRequest)NetworkHelper.CreateWebRequest(url);
			webRequest.Method = "POST";
			webRequest.KeepAlive = true;
			webRequest.Credentials = System.Net.CredentialCache.DefaultCredentials;
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.UserAgent = UserAgent;
			byte[] data = Encoding.UTF8.GetBytes(postMessage.ToString());
			using (var requestStream = webRequest.GetRequestStream()) {
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
		public static string HttpPost(string url, IDictionary<string, object> parameters) {
			var webRequest = (HttpWebRequest)NetworkHelper.CreateWebRequest(url);
			webRequest.Method = "POST";
			webRequest.KeepAlive = true;
			webRequest.Credentials = CredentialCache.DefaultCredentials;
			webRequest.UserAgent = UserAgent;
			webRequest.Headers.Add("Authorization", "Bearer " + Config.DownloadRuToken);
			NetworkHelper.WriteMultipartFormData(webRequest, parameters);

			return NetworkHelper.GetResponseAsString(webRequest);
		}

		/// <summary>
		/// Upload file by PUT
		/// </summary>
		/// <param name="url"></param>
		/// <param name="content"></param>
		/// <returns>response</returns>
		public static string HttpPut(string url, string content) {
			var webRequest = (HttpWebRequest)NetworkHelper.CreateWebRequest(url);
			webRequest.Method = "PUT";
			webRequest.KeepAlive = true;
			webRequest.Credentials = CredentialCache.DefaultCredentials;
			webRequest.Accept = "application/json";
            webRequest.UserAgent = UserAgent;
			webRequest.Headers.Add("Authorization", "Bearer " + Config.DownloadRuToken);
			byte[] data = Encoding.UTF8.GetBytes(content);
			using (var requestStream = webRequest.GetRequestStream()) {
				requestStream.Write(data, 0, data.Length);
			}
			return NetworkHelper.GetResponseAsString(webRequest);
		}


		/// <summary>
		/// Get REST request
		/// </summary>
		/// <param name="url"></param>
		/// <returns>response</returns>
		public static string HttpGet(string url) {
			var webRequest = (HttpWebRequest)NetworkHelper.CreateWebRequest(url);
			webRequest.Method = "GET";
			webRequest.KeepAlive = true;
			webRequest.Credentials = CredentialCache.DefaultCredentials;
			webRequest.UserAgent = UserAgent;
			webRequest.Headers.Add("Authorization", "Bearer " + Config.DownloadRuToken);
			return NetworkHelper.GetResponseAsString(webRequest);
		}

		/// <summary>
		/// Do the actual upload to DownloadRu
		/// </summary>
		/// <param name="image">Image for downloadru upload</param>
		/// <param name="title">Title of downloadru upload</param>
		/// <param name="filename">Filename of downloadru upload</param>
		/// <returns>url to uploaded image</returns>
		public static string UploadToDownloadRu(SurfaceContainer image, string title, string filename) {
			while (true) {
				const string folderId = "0";
				if (!Config.AnonymousAccess && string.IsNullOrEmpty(Config.DownloadRuToken)) {
					if (!Authorize()) {
						return null;
					}
				}

				IDictionary<string, object> parameters = new Dictionary<string, object>();
				parameters.Add("filename", image);
                //parameters.Add("parent_id", folderId);

				var response = "";
                string sharedLink = (Config.SharedLink) ? "&shared=true" : "";
                try
                {
					string locale = (Language.CurrentLanguage.Length > 1) ? Language.CurrentLanguage.Substring(0, 2) : "en";
                    string addAnonymKey = (Config.AnonymousAccess) ? string.Format("&anonym_key={0}", DownloadRuCredentials.AnonimKey) : "";
                    if (Config.AnonymousAccess && !Config.SharedLink) sharedLink = "&shared=true";
					response = HttpPost(UploadFileUri + locale + sharedLink + addAnonymKey, parameters);
				} catch (WebException ex) {
					if (ex.Status == WebExceptionStatus.ProtocolError) {
						Config.DownloadRuToken = null;
						continue;
					}
				}

				LOG.DebugFormat("DownloadRu response: {0}", response);

				// Check if the token is wrong
				if ("wrong auth token".Equals(response)) {
					Config.DownloadRuToken = null;
					IniConfig.Save();
					continue;
				}
				var upload = JSONSerializer.Deserialize<Upload>(response);
                if (upload == null || upload.Entries == null) return null;

				return string.Format("https://download.ru/f/{0}", upload.Entries.Id);
			}
		}
	}
	/// <summary>
	/// A simple helper class for the DataContractJsonSerializer
	/// </summary>
	public static class JSONSerializer {
		/// <summary>
		/// Helper method to serialize object to JSON
		/// </summary>
		/// <param name="jsonObject">JSON object</param>
		/// <returns>string</returns>
		public static string Serialize(object jsonObject) {
			var serializer = new DataContractJsonSerializer(jsonObject.GetType());
			using (MemoryStream stream = new MemoryStream()) {
				serializer.WriteObject(stream, jsonObject);
				return Encoding.UTF8.GetString(stream.ToArray());
			}
		}

		/// <summary>
		/// Helper method to parse JSON to object
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="jsonString"></param>
		/// <returns></returns>
		public static T Deserialize<T>(string jsonString) {
			var deserializer = new DataContractJsonSerializer(typeof(T));
			using (MemoryStream stream = new MemoryStream()) {
				byte[] content = Encoding.UTF8.GetBytes(jsonString);
				stream.Write(content, 0, content.Length);
				stream.Seek(0, SeekOrigin.Begin);
				return (T)deserializer.ReadObject(stream);
			}
		}
	}
}
