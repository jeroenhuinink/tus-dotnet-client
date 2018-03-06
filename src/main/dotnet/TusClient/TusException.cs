namespace Tus.Sdk
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net;

    /// <summary>
    /// Tus exception.
    /// </summary>
    public class TusException : WebException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tus.Sdk.TusException"/> class.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="msg">Message.</param>
        public TusException(TusException ex, string msg)
            : base(string.Format("{0}{1}", msg, ex.Message), ex, ex.Status, ex.Response)
        {
            this.OriginalException = ex;

            this.Statuscode = ex.Statuscode;
            this.StatusDescription = ex.StatusDescription;
            this.ResponseContent = ex.ResponseContent;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tus.Sdk.TusException"/> class.
        /// </summary>
        /// <param name="ex">Ex.</param>
        public TusException(OperationCanceledException ex)
            : base(ex.Message, ex, WebExceptionStatus.RequestCanceled, null)
        {
            this.OriginalException = null;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:Tus.Sdk.TusException"/> class.
        /// </summary>
        /// <param name="ex">Ex.</param>
        /// <param name="msg">Message.</param>
        public TusException(WebException ex, string msg = "")
            : base(string.Format("{0}{1}", msg, ex.Message), ex, ex.Status, ex.Response)
        {
            this.OriginalException = ex;

            HttpWebResponse webresp = (HttpWebResponse)ex.Response;

            if (webresp != null)
            {
                this.Statuscode = webresp.StatusCode;
                this.StatusDescription = webresp.StatusDescription;

                StreamReader readerS = new StreamReader(webresp.GetResponseStream());

                dynamic resp = readerS.ReadToEnd();

                readerS.Close();

                this.ResponseContent = resp;
            }
        }

        /// <summary>
        /// Gets or sets the content of the response.
        /// </summary>
        /// <value>The content of the response.</value>
        public string ResponseContent { get; set; }

        /// <summary>
        /// Gets or sets the statuscode.
        /// </summary>
        /// <value>The statuscode.</value>
        public HttpStatusCode Statuscode { get; set; }

        /// <summary>
        /// Gets or sets the status description.
        /// </summary>
        /// <value>The status description.</value>
        public string StatusDescription { get; set; }

        /// <summary>
        /// Gets or sets the original exception.
        /// </summary>
        /// <value>The original exception.</value>
        public WebException OriginalException { get; set; }

        /// <summary>
        /// Gets the full message.
        /// </summary>
        /// <value>The full message.</value>
        public string FullMessage
        {
            get
            {
                var bits = new List<string>();
                if (this.Response != null)
                {
                    bits.Add(string.Format("URL:{0}", this.Response.ResponseUri));
                }

                bits.Add(this.Message);
                if (this.Statuscode != HttpStatusCode.OK)
                {
                    bits.Add(string.Format("{0}:{1}", this.Statuscode, this.StatusDescription));
                }

                if (!string.IsNullOrEmpty(this.ResponseContent))
                {
                    bits.Add(this.ResponseContent);
                }

                return string.Join(Environment.NewLine, bits.ToArray());
            }
        }
    }
}
