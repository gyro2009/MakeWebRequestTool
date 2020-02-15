using System;
using System.Net.Http;
using System.Net.Mime;
using System.Text;

namespace MakeWebRequest
{
    /// <summary>
    /// Build HttpRequestMessages for use by the Internal Http Client
    /// </summary>
    public static class RequestBuilder
    {
        /// <summary>
        /// Builds HttpRequestMessage for use by the InternalHttpClient
        /// </summary>
        /// <param name="uri">Uri of the service</param>
        /// <param name="method">Method to send</param>
        /// <param name="body">Body to send</param>
        /// <returns>HttpRequestMessage built from supplied data</returns>
        public static HttpRequestMessage BuildRequestMessage(Uri uri, HttpMethod method, string body = null)
        {
           return new HttpRequestMessage
            {
                RequestUri = uri,
                Method = method,
                Content = !string.IsNullOrWhiteSpace(body) ? new StringContent(body, Encoding.UTF8, MediaTypeNames.Application.Json) : null
            };
        }
    }
}