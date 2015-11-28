// <copyright file="Identity.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Identity type represents an identity of an actor.
    /// </summary>
    /// <remarks>
    /// For example, and actor can be a user, device, or application.
    /// </remarks>
    public class Identity
    {
        /// <summary>
        /// Gets or sets the unique identifier for the identity.
        /// </summary>
        public string Id
        { get; set; }

        /// <summary>
        /// Gets or sets the identity's display name.
        /// </summary>
        /// <remarks>
        /// Note that this may not always be available or up to date.
        /// For example, if a user changes their display name, OneDrive
        /// may show the new value in a future response, but the items
        /// associated with the user won't show up as having changed in
        /// view.delta.
        /// </remarks>
        public string DisplayName
        { get; set; }
    }
}
