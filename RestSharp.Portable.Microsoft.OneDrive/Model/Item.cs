// <copyright file="Item.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Item resource type represents metadata for an item in OneDrive.
    /// </summary>
    /// <remarks>
    /// All top-level filesystem objects in OneDrive are Item resources.
    /// If an item is a Folder or File facet, the Item resource will contain
    /// a value for either the folder or file property, respectively.
    /// </remarks>
    public class Item
    {
        /// <summary>
        /// The unique identifier of the item within the Drive. Read-only.
        /// </summary>
        public string Id
        { get; set; }

        /// <summary>
        /// The name of the item (filename and extension). Read-write.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// eTag for the entire item (metadata + content). Read-only.
        /// </summary>
        public string ETag
        { get; set; }

        /// <summary>
        /// An eTag for the content of the item. Read-only.
        /// </summary>
        /// <remarks>
        /// This eTag is not changed if only the metadata is changed.
        /// </remarks>
        public string CTag
        { get; set; }

        /// <summary>
        /// Identity of the user, device, and application which created the item. Read-only.
        /// </summary>
        public IdentitySet CreatedBy
        { get; set; }

        /// <summary>
        /// Identity of the user, device, and application which last modified the item. Read-only.
        /// </summary>
        public IdentitySet ModifiedBy
        { get; set; }

        /// <summary>
        /// Date and time of item creation. Read-only.
        /// </summary>
        public DateTimeOffset? CreatedDateTime
        { get; set; }

        /// <summary>
        /// Date and time the item was last modified. Read-only.
        /// </summary>
        public DateTimeOffset? LastModifiedDateTime
        { get; set; }

        /// <summary>
        /// Size of the item in bytes. Read-only.
        /// </summary>
        public long? Size
        { get; set; }

        /// <summary>
        /// URL that displays the resource in the browser. Read-only.
        /// </summary>
        public Uri WebUrl
        { get; set; }

        /// <summary>
        /// Provide a user-visible description of the item. Read-write.
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// Parent information, if the item has a parent. Read-write.
        /// </summary>
        public ItemReference ParentReference
        { get; set; }

        /// <summary>
        /// Collection containing Item objects for the immediate children of Item.
        /// </summary>
        /// <remarks>
        /// Only items representing folders have children.
        /// </remarks>
        public List<Item> Children
        { get; set; }

        /// <summary>
        /// Folder metadata, if the item is a folder. Read-only.
        /// </summary>
        public Folder Folder
        { get; set; }

        /// <summary>
        /// File metadata, if the item is a file. Read-only.
        /// </summary>
        public File File
        { get; set; }

        /// <summary>
        /// File system information on client. Read-write.
        /// </summary>
        public FileSystemInfo FileSystemInfo
        { get; set; }

        /// <summary>
        /// Image metadata, if the item is an image. Read-only.
        /// </summary>
        public Image Image
        { get; set; }

        /// <summary>
        /// Photo metadata, if the item is a photo. Read-only.
        /// </summary>
        public Photo Photo
        { get; set; }

        /// <summary>
        /// Audio metadata, if the item is an audio file. Read-only.
        /// </summary>
        public Audio Audio
        { get; set; }

        /// <summary>
        /// Video metadata, if the item is a video. Read-only.
        /// </summary>
        public Video Video
        { get; set; }

        /// <summary>
        /// Location metadata, if the item has location data. Read-only.
        /// </summary>
        public Location Location
        { get; set; }

        /// <summary>
        /// Search metadata, if the item is from a search result.
        /// </summary>
        public SearchResultFacet SearchResult
        { get; set; }

        /// <summary>
        /// Information about the deleted state of the item. Read-only.
        /// </summary>
        public Deleted Deleted
        { get; set; }

        /// <summary>
        /// Gets the Thumbnails for this item.
        /// </summary>
        public ThumbnailSet Thumbnails
        { get; set; }

        /// <summary>
        /// Will return a specialFolder facet that describes the identifier
        /// used for accessing the special folder.
        /// </summary>
        public SpecialFolder SpecialFolder
        { get; set; }

        /// <summary>
        /// Determines what to do if an item with a matching name already exists in this folder.
        /// </summary>
        [JsonProperty("@name.conflictBehavior")]
        public ConflictBehavior? ConflictBehavior
        { get; set; }
    }
}
