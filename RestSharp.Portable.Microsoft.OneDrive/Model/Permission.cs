// <copyright file="Permission.cs" company="Fubar Development Junker">
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
    /// Represents a permission on a OneDrive item.
    /// </summary>
    /// <remarks>
    /// Permissions in OneDrive have a number of different forms. The <see cref="Permission"/> object
    /// represents these different forms through facets on the <see cref="Permission"/> object.
    /// </remarks>
    public class Permission
    {
        /// <summary>
        /// The unique identifier of the permission among all permissions on the item. Read Only.
        /// </summary>
        public string Id
        { get; set; }

        /// <summary>
        /// The type of permission, e.g. <code>read</code>. See below for the full list of roles.
        /// </summary>
        public List<string> Roles
        { get; set; }

        /// <summary>
        /// Provides the link details of the current permission, if it is a link type permissions. Read Only.
        /// </summary>
        public SharingLink Link
        { get; set; }

        /// <summary>
        /// Provides a reference to the ancestor of the current permission, if it is inherited from an ancestor. Read Only.
        /// </summary>
        public ItemReference InheritedFrom
        { get; set; }
    }
}
