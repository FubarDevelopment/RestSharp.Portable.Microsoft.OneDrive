// <copyright file="Drive.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Drive resource represents a drive in OneDrive.
    /// </summary>
    /// <remarks>
    /// It provides information about the owner of the drive, total and available
    /// storage space, and exposes a collection of all the <see cref="Item"/>s contained within
    /// the drive.
    /// </remarks>
    public class Drive
    {
        /// <summary>
        /// Gets or sets the unique identifier of the drive.
        /// </summary>
        public string Id
        { get; set; }

        /// <summary>
        /// Gets or sets the enumerated value that identifies the type of drive account.
        /// </summary>
        public DriveType DriveType
        { get; set; }

        /// <summary>
        /// Gets or sets the user account that owns the drive.
        /// </summary>
        public IdentitySet Owner
        { get; set; }

        /// <summary>
        /// Gets or sets the information about the drive's storage space quota.
        /// </summary>
        public Quota Quota
        { get; set; }
    }
}
