// <copyright file="Location.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Location facet groups geographic location-related data on OneDrive into a single structure.
    /// </summary>
    /// <remarks>
    /// It is available on the <see cref="Item.Location"/> property of <see cref="Item"/> resources
    /// that have an associated geographic location.
    /// </remarks>
    public class Location
    {
        /// <summary>
        /// The altitude (height), in feet, above sea level for the item.
        /// </summary>
        public decimal? Altitude
        { get; set; }

        /// <summary>
        /// The latitude, in decimal, for the item.
        /// </summary>
        public decimal? Latitude
        { get; set; }

        /// <summary>
        /// The longitude, in decimal, for the item.
        /// </summary>
        public decimal? Longitude
        { get; set; }
    }
}
