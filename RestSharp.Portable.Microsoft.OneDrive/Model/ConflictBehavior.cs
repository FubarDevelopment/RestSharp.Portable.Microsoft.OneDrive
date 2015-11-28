// <copyright file="ConflictBehavior.cs" company="Fubar Development Junker">
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
    /// Determines what to do if an item with a matching name already exists in this folder.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ConflictBehavior
    {
        /// <summary>
        /// OneDrive will append a number to the end of the item name (for files - before the extension).
        /// </summary>
        [EnumMember(Value = "rename")]
        Rename,

        /// <summary>
        /// Content will be replaced
        /// </summary>
        [EnumMember(Value = "replace")]
        Replace,

        /// <summary>
        /// Default behavior
        /// </summary>
        [EnumMember(Value = "fail")]
        Fail
    }
}
