// <copyright file="SearchResultFacet.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The SearchResultFacet facet groups search result metadata into a single structure.
    /// </summary>
    public class SearchResultFacet
    {
        /// <summary>
        /// Gets or sets the callback URL that is used to record telemetry information.
        /// </summary>
        /// <remarks>
        /// The application should issue a GET on this URL if the user interacts with this item.
        /// </remarks>
        public Uri OnClickTelemetryUrl
        { get; set; }
    }
}
