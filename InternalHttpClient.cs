using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MakeWebRequest
{
    /// <summary>
    /// Internal client for sending Http Requests
    /// </summary>
    public class InternalHttpClient
    {
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Internal client for sending Http Requests
        /// </summary>
        /// <param name="httpClient"></param>
        public InternalHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        /// <summary>
        /// Sends HttpRequestMessage and returns Content as string
        /// </summary>
        /// <param name="message">HttpRequestMessage to be sent</param>
        /// <returns></returns>
        public async Task<string> SendRequestAsync(HttpRequestMessage message)
        {
            var response = await _httpClient.SendAsync(message);

            return await response.Content.ReadAsStringAsync();
        }
    }
}