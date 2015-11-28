// <copyright file="Photo.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Photo facet groups photo-related data on OneDrive, for example, EXIF
    /// metadata, into a single structure.
    /// </summary>
    /// <remarks>
    /// It is available on the <see cref="Item.Photo"/> property of <see cref="Item"/> resources
    /// that represent photos.
    /// </remarks>
    public class Photo
    {
        /// <summary>
        /// Represents the date and time the photo was taken.
        /// </summary>
        public DateTimeOffset? TakenDateTime
        { get; set; }

        /// <summary>
        /// Camera manufacturer.
        /// </summary>
        public string CameraMake
        { get; set; }

        /// <summary>
        /// Camera model.
        /// </summary>
        public string CameraModel
        { get; set; }

        /// <summary>
        /// The F-stop value from the camera.
        /// </summary>
        public decimal? FNumber
        { get; set; }

        /// <summary>
        /// The denominator for the exposure time fraction from the camera.
        /// </summary>
        public decimal? ExposureDenominator
        { get; set; }

        /// <summary>
        /// The numerator for the exposure time fraction from the camera.
        /// </summary>
        public decimal? ExposureNumerator
        { get; set; }

        /// <summary>
        /// The focal length from the camera.
        /// </summary>
        public decimal? FocalLength
        { get; set; }

        /// <summary>
        /// The ISO value from the camera.
        /// </summary>
        public decimal Iso
        { get; set; }
    }
}
