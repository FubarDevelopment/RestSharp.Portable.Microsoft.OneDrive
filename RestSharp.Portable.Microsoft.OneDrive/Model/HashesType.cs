// <copyright file="HashesType.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Hashes facet groups different types of hashes into a single
    /// structure, for an item on OneDrive.
    /// </summary>
    public class HashesType
    {
        /// <summary>
        /// The CRC32 value of the file (if available)
        /// </summary>
        public byte[] Crc32Hash
        { get; set; }

        /// <summary>
        /// SHA1 hash for the contents of the file (if available)
        /// </summary>
        public byte[] Sha1Hash
        { get; set; }
    }
}
