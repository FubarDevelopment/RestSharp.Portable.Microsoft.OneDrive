// <copyright file="Folder.cs" company="Fubar Development Junker">
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
    /// The Folder facet groups folder-related data on OneDrive into a single structure.
    /// </summary>
    /// <remarks>
    /// It is available on the <see cref="Item.Folder"/> property of <see cref="Item"/> resources that represent folders.
    /// </remarks>
    public class Folder
    {
        /// <summary>
        /// Gets or sets number of children contained immediately within this container.
        /// </summary>
        public long? ChildCount
        { get; set; }
    }
}
