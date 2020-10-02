using System;
using System.Net;
using System.Net.Http;
using Newtonsoft.Json;

namespace PetApiLib.Api
{
    public class RestClientLibrary
    {
        private readonly HttpClient _client = new HttpClient();
        private readonly string _baseUrl;

        /// <summary>
        /// Set the constructor Rest Client Library
        /// </summary>
        /// <param name="baseUrl">Base URL</param>
        public RestClientLibrary(string baseUrl)
        {
            if (string.Equals(baseUrl, null, StringComparison.Ordinal)) throw new ArgumentNullException(nameof(baseUrl));
            this._baseUrl = baseUrl;
        }

        /// <summary>
        /// Post Client
        /// </summary>
        /// <typeparam name="T">Type of data to send</typeparam>
        /// <param name="body">Object to send</param>
        /// <param name="path">Current Path to send</param>
        public void Post<T>(T body, string path)
        {
            Uri url = new Uri(_baseUrl + path, UriKind.Absolute);
            using var content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage result = _client.PostAsync(url, content).Result;
            if (result.StatusCode != HttpStatusCode.OK)
                throw new PetApiException((int)result.StatusCode, "Unable to create element");
            string returnValue = result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Perform a GET query to the server
        /// </summary>
        /// <typeparam name="T">Type parameter</typeparam>
        /// <param name="queryPath">Query</param>
        /// <returns>Object in the given type</returns>
        public T Get<T>(string queryPath)
        {
            Uri url = new Uri(_baseUrl + queryPath, UriKind.Absolute);
            HttpResponseMessage result = _client.GetAsync(url).Result;
            if (result.StatusCode != HttpStatusCode.OK)
                throw new PetApiException((int)result.StatusCode, "Unable to query data");
            string returnValue = result.Content.ReadAsStringAsync().Result;

            return JsonConvert.DeserializeObject<T>(returnValue);

        }

        /// <summary>
        /// Delete Verb
        /// </summary>
        /// <param name="queryPath">Query Path</param>
        /// <param name="key">Key to delete</param>
        public void Delete(string queryPath, string key)
        {
            Uri url = new Uri(_baseUrl + queryPath, UriKind.Absolute);
            _client.DefaultRequestHeaders.Add("api_key", key);
            HttpResponseMessage result = _client.DeleteAsync(url).Result;
            if (result.StatusCode != HttpStatusCode.OK)
                throw new PetApiException((int)result.StatusCode, "Unable to delete data");
            string returnValue = result.Content.ReadAsStringAsync().Result;
        }

        /// <summary>
        /// Update verb
        /// </summary>
        /// <typeparam name="T">Type</typeparam>
        /// <param name="body">Body / Object </param>
        /// <param name="queryPath">Query Path</param>
        public void Update<T>(T body, string queryPath)
        {
            Uri url = new Uri(_baseUrl + queryPath, UriKind.Absolute);
            using var content = new StringContent(JsonConvert.SerializeObject(body), System.Text.Encoding.UTF8, "application/json");
            HttpResponseMessage result = _client.PutAsync(url, content).Result;
            if (result.StatusCode != HttpStatusCode.OK)
                throw new PetApiException((int)result.StatusCode, "Unable to create element");
            string returnValue = result.Content.ReadAsStringAsync().Result;

        }
    }
}