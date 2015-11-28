// <copyright file="QuotaState.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// Enumeration value that indicates the state of the storage space.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum QuotaState
    {
        /// <summary>
        /// The drive has plenty of remaining quota left.
        /// </summary>
        [EnumMember(Value = "normal")]
        Normal,

        /// <summary>
        /// Remaining quota is less than 10% of total quota space.
        /// </summary>
        [EnumMember(Value = "nearing")]
        Nearing,

        /// <summary>
        /// Remaining quota is less than 1% of total quota space.
        /// </summary>
        [EnumMember(Value = "critical")]
        Critical,

        /// <summary>
        /// The used quota has exceeded the total quota.
        /// </summary>
        /// <remarks>
        /// New files or folders cannot be added to the drive until it is under the total quota amount.
        /// </remarks>
        [EnumMember(Value = "exceeded")]
        Exceeded,
    }
}
