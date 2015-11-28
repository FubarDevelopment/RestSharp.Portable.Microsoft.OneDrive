// <copyright file="Image.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Image groups image-related data on OneDrive into a single structure.
    /// </summary>
    /// <remarks>
    /// It is available on the <see cref="Item.Image"/> property of <see cref="Item"/>
    /// resources that represent images.
    /// </remarks>
    public class Image
    {
        /// <summary>
        /// Width of the image, in pixels.
        /// </summary>
        public long Width
        { get; set; }

        /// <summary>
        /// Height of the image, in pixels.
        /// </summary>
        public long Height
        { get; set; }
    }
}
