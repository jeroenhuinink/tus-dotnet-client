namespace Tus.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    /// <summary>
    /// Http request.
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tus.Sdk.HttpRequest"/> class.
        /// </summary>
        /// <param name="url">URL.</param>
        public HttpRequest(string url)
        {
            this.Url = url;
            this.Method = "GET";
            this.Headers = new Dictionary<string, string>();
            this.BodyBytes = new byte[0];
        }

        /// <summary>
        /// Uploading event.
        /// </summary>
        public delegate void UploadingEvent(long bytesTransferred, long bytesTotal);

        /// <summary>
        /// Downloading event.
        /// </summary>
        public delegate void DownloadingEvent(long bytesTransferred, long bytesTotal);

        /// <summary>
        /// Occurs when uploading.
        /// </summary>
        public event UploadingEvent Uploading;

        /// <summary>
        /// Occurs when downloading.
        /// </summary>
        public event DownloadingEvent Downloading;

        /// <summary>
        /// Gets or sets the URL.
        /// </summary>
        /// <value>The URL.</value>
        public string Url { get; set; }

        /// <summary>
        /// Gets or sets the method.
        /// </summary>
        /// <value>The method.</value>
        public string Method { get; set; }

        /// <summary>
        /// Gets or sets the headers.
        /// </summary>
        /// <value>The headers.</value>
        public Dictionary<string, string> Headers { get; set; }

        /// <summary>
        /// Gets or sets the body bytes.
        /// </summary>
        /// <value>The body bytes.</value>
        public byte[] BodyBytes { get; set; }

        /// <summary>
        /// Gets or sets the cancel token.
        /// </summary>
        /// <value>The cancel token.</value>
        public CancellationToken CancelToken { get; set; }

        /// <summary>
        /// Gets or sets the body text.
        /// </summary>
        /// <value>The body text.</value>
        public string BodyText
        {
            get { return System.Text.Encoding.UTF8.GetString(this.BodyBytes); }
            set { this.BodyBytes = System.Text.Encoding.UTF8.GetBytes(value); }
        }

        /// <summary>
        /// Adds the header.
        /// </summary>
        /// <param name="k">K.</param>
        /// <param name="v">V.</param>
        public void AddHeader(string k, string v)
        {
            this.Headers[k] = v;
        }

        /// <summary>
        /// Fires the uploading.
        /// </summary>
        /// <param name="bytesTransferred">Bytes transferred.</param>
        /// <param name="bytesTotal">Bytes total.</param>
        public void FireUploading(long bytesTransferred, long bytesTotal)
        {
            this.Uploading?.Invoke(bytesTransferred, bytesTotal);
        }

        /// <summary>
        /// Fires the downloading.
        /// </summary>
        /// <param name="bytesTransferred">Bytes transferred.</param>
        /// <param name="bytesTotal">Bytes total.</param>
        public void FireDownloading(long bytesTransferred, long bytesTotal)
        {
            this.Downloading?.Invoke(bytesTransferred, bytesTotal);
        }
    }
}
