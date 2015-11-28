// <copyright file="ItemReference.cs" company="Fubar Development Junker">
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
    /// The itemReference type groups data needed to reference a OneDrive
    /// item across the service into a single structure.
    /// </summary>
    public class ItemReference
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Drive that contains the item.
        /// </summary>
        public string DriveId
        { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the item.
        /// </summary>
        public string Id
        { get; set; }

        /// <summary>
        /// Gets or sets the path that used to navigate to the item.
        /// </summary>
        public string Path
        { get; set; }
    }
}
