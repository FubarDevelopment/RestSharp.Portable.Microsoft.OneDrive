// <copyright file="SharingLink.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The SharingLink type groups sharing link-related data on OneDrive into a single structure.
    /// </summary>
    public class SharingLink
    {
        /// <summary>
        /// Gets or sets the  access token that represents the current link permission.
        /// </summary>
        /// <remarks>
        /// You can use this in place of other authentication tokens to access the resource the
        /// current permission is set for.
        /// </remarks>
        public string Token
        { get; set; }

        /// <summary>
        /// Gets or sets the  type of the link created.
        /// </summary>
        public SharingLinkType Type
        { get; set; }

        /// <summary>
        /// Gets or sets an URL that opens the item in the browser on the OneDrive website.
        /// </summary>
        public Uri WebUrl
        { get; set; }

        /// <summary>
        /// Gets or sets the app the link is associated with.
        /// </summary>
        /// <remarks>
        /// The value is missing or null if the link is associated with an official Microsoft app.
        /// </remarks>
        public Identity Application
        { get; set; }
    }
}
