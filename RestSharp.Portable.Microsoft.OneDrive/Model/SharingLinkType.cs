// <copyright file="SharingLinkType.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The type of the link created.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SharingLinkType
    {
        /// <summary>
        /// A view-only sharing link, allowing read-only access.
        /// </summary>
        [EnumMember(Value = "view")]
        View,

        /// <summary>
        /// An edit sharing link, allowing read-write access.
        /// </summary>
        [EnumMember(Value = "edit")]
        Edit
    }
}
