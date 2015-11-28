// <copyright file="FileSystemInfo.cs" company="Fubar Development Junker">
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
    /// The FileSystemInfo facet contains properties that are reported by the device's
    /// local file system for the local version of an item.
    /// </summary>
    /// <remarks>
    /// This facet can be used to specify the last modified date or created date of the
    /// item as it was on the local device.
    /// </remarks>
    public class FileSystemInfo
    {
        /// <summary>
        /// Gets or sets the UTC date and time the file was created on a client.
        /// </summary>
        public DateTimeOffset? CreatedDateTime
        { get; set; }

        /// <summary>
        /// Gets or sets the UTC date and time the file was last modified on a client.
        /// </summary>
        public DateTimeOffset? LastModifiedDateTime
        { get; set; }
    }
}
