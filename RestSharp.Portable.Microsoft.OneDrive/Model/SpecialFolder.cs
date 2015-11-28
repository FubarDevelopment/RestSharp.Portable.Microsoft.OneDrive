// <copyright file="SpecialFolder.cs" company="Fubar Development Junker">
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
    /// The SpecialFolder facet provides information about how a folder on OneDrive can be accessed
    /// via the special folders collection.
    /// </summary>
    public class SpecialFolder
    {
        /// <summary>
        /// Gets or sets the unique identifier for this item in the <code>/drive/special</code> collection
        /// </summary>
        public string Name
        { get; set; }
    }
}
