// <copyright file="IdentitySet.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The IdentitySet type is a keyed collection of Identity objects.
    /// </summary>
    /// <remarks>
    /// It is used to represent a set of identities associated with various events for an item, such as created by or last modified by.
    /// </remarks>
    public class IdentitySet
    {
        /// <summary>
        /// Gets or sets the Identity resource that represents a user.
        /// </summary>
        public Identity User
        { get; set; }

        /// <summary>
        /// Gets or sets the Identity resource that represents the application.
        /// </summary>
        public Identity Application
        { get; set; }

        /// <summary>
        /// Gets or sets the Identity resource that represents the device.
        /// </summary>
        public Identity Device
        { get; set; }
    }
}
