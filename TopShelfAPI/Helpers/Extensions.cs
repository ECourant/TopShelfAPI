using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI.Helpers
{
    internal static class Extensions
    {
        internal static string Base64Encode(this string input) => Convert.ToBase64String(Encoding.UTF8.GetBytes(input));

        internal static string Base64Decode(this string input) => Encoding.UTF8.GetString(Convert.FromBase64String(input));

        internal static void Try(Action function)
        {
            try
            {
                function.Invoke();
            }
            catch
            {
            }
        }

        internal static Task<HttpResponseMessage> DeleteAsync(this HttpClient httpClient, string requestUri, HttpContent content) => httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Delete, requestUri)
        {
            Content = content
        });
    }
}
