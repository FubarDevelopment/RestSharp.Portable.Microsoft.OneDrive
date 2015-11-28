// <copyright file="ThumbnailSet.cs" company="Fubar Development Junker">
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
    /// The ThumbnailSet type is a keyed collection of <see cref="Thumbnail"/> objects.
    /// </summary>
    /// <remarks>
    /// It is used to represent a set of thumbnails associated with a single file on OneDrive.
    /// </remarks>
    public class ThumbnailSet
    {
        /// <summary>
        /// Gets or sets the id within the item.
        /// </summary>
        public string Id
        { get; set; }

        /// <summary>
        /// Gets or sets the 48x48 cropped thumbnail.
        /// </summary>
        public Thumbnail Small
        { get; set; }

        /// <summary>
        /// Gets or sets the 176x176 scaled thumbnail.
        /// </summary>
        public Thumbnail Medium
        { get; set; }

        /// <summary>
        /// Gets or sets the 1920x1920 scaled thumbnail.
        /// </summary>
        public Thumbnail Large
        { get; set; }

        /// <summary>
        /// Gets or sets the custom thumbnail image or the original image used to generate other thumbnails.
        /// </summary>
        public Thumbnail Source
        { get; set; }
    }
}
