namespace Tus.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    /// <summary>
    /// Http response.
    /// </summary>
    public class HttpResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tus.Sdk.HttpResponse"/> class.
        /// </summary>
        public HttpResponse()
        {
            this.Headers = new Dictionary<string, string>();
        }

        /// <summary>
        /// Gets or sets the response bytes.
        /// </summary>
        /// <value>The response bytes.</value>
        public byte[] ResponseBytes
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the response string.
        /// </summary>
        /// <value>The response string.</value>
        public string ResponseString
        {
            get
            {
                return System.Text.Encoding.UTF8.GetString(this.ResponseBytes);
            }
        }

        /// <summary>
        /// Gets or sets the status code.
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>The headers.</value>
        public Dictionary<string, string> Headers
        {
            get;
            set;
        }
    }
}
