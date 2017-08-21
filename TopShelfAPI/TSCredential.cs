using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopShelfAPI
{
    /// <summary>
    /// A credential object used to authenticate TopShelf's REST API.
    /// </summary>
    /// <example>
    /// <para>This example shows how to create a credentials object.</para>
    /// <code>
    /// TopShelfAPI.TSCredential Credentials = new TopShelfAPI.TSCredential("tHiSiSmYaPiKeY", "aNdMyApIsEcReT");
    /// </code>
    /// </example>
    public sealed class TSCredential
    {
        /// <summary>
        /// Creates a new <see cref="TopShelfAPI.TSCredential"/> with the provided credentials from the My Account page.
        /// </summary>
        /// <param name="apiKey">The API Key from the My Account page.</param>
        /// <param name="apiSecret">The API Secret from the My Account page.</param>
        /// <exception cref="ArgumentNullException">Will be thrown if <paramref name="apiKey"/> or <paramref name="apiSecret"/> are null or white space.</exception>
        public TSCredential(string apiKey, string apiSecret)
        {
            this.APIKey = string.IsNullOrWhiteSpace(apiKey) ? throw new ArgumentNullException("apiKey", "apiKey cannot be null or white space!") : apiKey;
            this.APISecret = string.IsNullOrWhiteSpace(apiSecret) ? throw new ArgumentNullException("apiSecret", "apiSecret cannot be null or white space!") : apiSecret;
        }

        internal string APIKey { get; set; }

        internal string APISecret { get; set; }
    }
}
