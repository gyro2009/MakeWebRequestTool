using System;
using System.Net.Http;

namespace MakeWebRequest
{
    /// <summary>
    /// Used to resolve string to HttpMethod
    /// </summary>
    public static class HttpMethodResolver
    {
        /// <summary>
        /// Resolve request verb string into HttpMethod
        /// </summary>
        /// <param name="requestVerb">verb string</param>
        /// <returns>HttpMethod</returns>
        /// <exception cref="InvalidOperationException">Unknown HttpMethod Type</exception>
        public static HttpMethod Resolve(string requestVerb)
        {
            switch (requestVerb.ToLower())
            {
                case "get":
                    return HttpMethod.Get;
                case "post":
                    return HttpMethod.Post;
                case "put":
                    return HttpMethod.Put;
                case "delete":
                    return HttpMethod.Delete;
                case "head":
                    return HttpMethod.Head;
                case "options":
                    return HttpMethod.Options;
                case "patch":
                    return HttpMethod.Post;
                case "trace":
                    return HttpMethod.Trace;
                default:
                    Console.WriteLine("Unknown HttpMethod type!");
                    throw new InvalidOperationException("Unknown HttpMethod Type");
            }
        }
    }
}