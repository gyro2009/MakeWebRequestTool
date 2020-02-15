using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace MakeWebRequest
{
    class Program
    {
        /// <summary>
        /// Sends a request to the specified URL and gives back the response content
        /// </summary>
        /// <param name="url">Endpoint to call (Required)</param>
        /// <param name="requestVerb">Http Request Method (Required)</param>
        /// <param name="requestBody">Body to send with Request</param>
        /// <param name="outFile">Location to save request body</param>
        public static async Task<int> Main(string url = "http://www.google.com", string requestVerb = "get", string requestBody = "", string outFile = "")
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddHttpClient<InternalHttpClient>();
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Uri requestUri;
            HttpMethod requestMethod;

            try
            {
                requestUri = new Uri(url);
            }
            catch
            {
                Console.WriteLine("Unable to parse URL! Please check and try again");
                return 1;
            }

            try
            {
                requestMethod = HttpMethodResolver.Resolve(requestVerb);
            }
            catch
            {
                return 2;
            }

            var request = RequestBuilder.BuildRequestMessage(requestUri, requestMethod, requestBody);

            var response = await serviceProvider.GetRequiredService<InternalHttpClient>().SendRequestAsync(request);

            if (!string.IsNullOrWhiteSpace(outFile))
            {
                Console.WriteLine($"Attempting to save to: {outFile}");
                try
                {
                    File.WriteAllText(outFile, response);
                }
                catch
                {
                    Console.WriteLine("Error writing response to file");
                    Console.WriteLine("Response:");
                    Console.WriteLine(response);
                    return 3;
                }
            }
            
            Console.WriteLine("Response:");
            Console.WriteLine(response);

            return 0;
        }
    }
}
