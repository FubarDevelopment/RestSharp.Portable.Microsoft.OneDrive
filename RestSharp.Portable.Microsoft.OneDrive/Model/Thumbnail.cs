// <copyright file="Thumbnail.cs" company="Fubar Development Junker">
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
    /// The Thumbnail resource type represents a thumbnail for an image,
    /// video, document, or any file or folder on OneDrive that has a
    /// graphical representation.
    /// </summary>
    public class Thumbnail
    {
        /// <summary>
        /// The width of the thumbnail, in pixels.
        /// </summary>
        public int Width
        { get; set; }

        /// <summary>
        /// The height of the thumbnail, in pixels.
        /// </summary>
        public int Height
        { get; set; }

        /// <summary>
        /// The URL used to fetch the thumbnail content.
        /// </summary>
        public Uri Url
        { get; set; }
    }
}
