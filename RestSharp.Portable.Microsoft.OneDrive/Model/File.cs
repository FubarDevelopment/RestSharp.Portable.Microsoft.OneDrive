// <copyright file="File.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The File facet groups file-related data on OneDrive into a single structure.
    /// </summary>
    /// <remarks>
    /// It is available on the <see cref="Item.File"/> property of <see cref="Item"/> resources that represent files.
    /// </remarks>
    public class File
    {
        /// <summary>
        /// The MIME type for the file.
        /// </summary>
        /// <remarks>
        /// This is determined by logic on the server and might not be the value
        /// provided when the file was uploaded.
        /// </remarks>
        public string MimeType
        { get; set; }

        /// <summary>
        /// Hashes of the file's binary content, if available.
        /// </summary>
        public HashesType Hashes
        { get; set; }
    }
}
