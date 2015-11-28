// <copyright file="UploadSession.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// Provides information about a large file upload session.
    /// </summary>
    public class UploadSession
    {
        /// <summary>
        /// Gets or sets theURL where fragment PUT requests should be directed.
        /// </summary>
        public Uri UploadUrl
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time when the upload session expires.
        /// </summary>
        public DateTimeOffset ExpirationDateTime
        { get; set; }

        /// <summary>
        /// Gets or sets the array of byte ranges the server is missing. Not always a full list of the missing ranges.
        /// </summary>
        public List<string> NextExpectedRanges
        { get; set; }

        /// <summary>
        /// Gets the <see cref="NextExpectedRanges"/> as <see cref="HttpRange"/>
        /// </summary>
        /// <returns>The new <see cref="HttpRange"/> created from the <see cref="NextExpectedRanges"/>.</returns>
        public HttpRange ToHttpRange()
        {
            var temp = new StringBuilder();
            temp.Append("bytes=");
            if (NextExpectedRanges == null || NextExpectedRanges.Count == 0)
            {
                temp.Append("*");
            }
            else
            {
                temp.Append(string.Join(",", NextExpectedRanges));
            }
            return HttpRange.Parse(temp.ToString());
        }
    }
}
