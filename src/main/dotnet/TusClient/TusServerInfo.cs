namespace Tus.Sdk
{
    using System;

    /// <summary>
    /// Tus server info.
    /// </summary>
    public class TusServerInfo
    {
        /// <summary>
        /// Gets or sets the version.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        /// <summary>
        /// Gets or sets the supported versions.
        /// </summary>
        /// <value>The supported versions.</value>
        public string SupportedVersions { get; set; }

        /// <summary>
        /// Gets or sets the extensions.
        /// </summary>
        /// <value>The extensions.</value>
        public string Extensions { get; set; }

        /// <summary>
        /// Gets or sets the size of the max.
        /// </summary>
        /// <value>The size of the max.</value>
        public long MaxSize { get; set; }

        /// <summary>
        /// Gets a value indicating whether this <see cref="T:Tus.Sdk.TusServerInfo"/> supports delete.
        /// </summary>
        /// <value><c>true</c> if supports delete; otherwise, <c>false</c>.</value>
        public bool SupportsDelete
        {
            get { return this.Extensions.Contains("termination"); }
        }
    }
}
