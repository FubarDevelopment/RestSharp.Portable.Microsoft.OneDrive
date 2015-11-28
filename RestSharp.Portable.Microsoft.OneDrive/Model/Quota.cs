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
        /// Total allowed storage space, in bytes.
        /// </summary>
        public long? Total
        { get; set; }

        /// <summary>
        /// Total space used, in bytes.
        /// </summary>
        public long Used
        { get; set; }

        /// <summary>
        /// Total space remaining before reaching the quota limit, in bytes.
        /// </summary>
        public long? Remaining
        { get; set; }

        /// <summary>
        /// Total space consumed by files in the recycle bin, in bytes.
        /// </summary>
        public long Deleted
        { get; set; }

        /// <summary>
        /// Enumeration value that indicates the state of the storage space.
        /// </summary>
        public QuotaState State
        { get; set; }
    }
}
