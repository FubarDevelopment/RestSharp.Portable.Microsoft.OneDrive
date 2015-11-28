// <copyright file="Video.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Video facet groups video-related data on OneDrive into a single complex type.
    /// </summary>
    /// <remarks>
    /// It is available on the <see cref="Item.Video"/> property of <see cref="Item"/> resources
    /// that represent videos.
    /// </remarks>
    public class Video
    {
        /// <summary>
        /// Bit rate of the video in bits per second.
        /// </summary>
        public decimal? Bitrate
        { get; set; }

        /// <summary>
        /// Duration of the file in milliseconds.
        /// </summary>
        public decimal? Duration
        { get; set; }

        /// <summary>
        /// Height of the video, in pixels.
        /// </summary>
        public decimal Height
        { get; set; }

        /// <summary>
        /// Width of the video, in pixels.
        /// </summary>
        public decimal Width
        { get; set; }
    }
}
