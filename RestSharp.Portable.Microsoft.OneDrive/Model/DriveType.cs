// <copyright file="DriveType.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System.Runtime.Serialization;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// Enumerated value that identifies the type of drive account.
    /// </summary>
    /// <remarks>
    /// OneDrive drives will show as personal.
    /// </remarks>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum DriveType
    {
        /// <summary>
        /// OneDrive drive
        /// </summary>
        [EnumMember(Value = "personal")]
        Personal,

        /// <summary>
        /// OneDrive business drive (Sharepoint)
        /// </summary>
        [EnumMember(Value = "business")]
        Business,
    }
}
