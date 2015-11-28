// <copyright file="Quota.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Quota facet groups storage space quota-related information on OneDrive into a single structure.
    /// </summary>
    public class Quota
    {
        /// <summary>
        /// Gets or sets the total allowed storage space, in bytes.
        /// </summary>
        public long? Total
        { get; set; }

        /// <summary>
        /// Gets or sets the total space used, in bytes.
        /// </summary>
        public long Used
        { get; set; }

        /// <summary>
        /// Gets or sets the total space remaining before reaching the quota limit, in bytes.
        /// </summary>
        public long? Remaining
        { get; set; }

        /// <summary>
        /// Gets or sets the total space consumed by files in the recycle bin, in bytes.
        /// </summary>
        public long Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the enumeration value that indicates the state of the storage space.
        /// </summary>
        public QuotaState State
        { get; set; }
    }
}
