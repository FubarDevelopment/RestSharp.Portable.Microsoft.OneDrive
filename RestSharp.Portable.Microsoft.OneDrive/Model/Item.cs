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
        /// Gets or sets the unique identifier of the item within the Drive. Read-only.
        /// </summary>
        public string Id
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the item (filename and extension). Read-write.
        /// </summary>
        public string Name
        { get; set; }

        /// <summary>
        /// Gets or sets the eTag for the entire item (metadata + content). Read-only.
        /// </summary>
        public string ETag
        { get; set; }

        /// <summary>
        /// Gets or sets the eTag for the content of the item. Read-only.
        /// </summary>
        /// <remarks>
        /// This eTag is not changed if only the metadata is changed.
        /// </remarks>
        public string CTag
        { get; set; }

        /// <summary>
        /// Gets or sets the identity of the user, device, and application which created the item. Read-only.
        /// </summary>
        public IdentitySet CreatedBy
        { get; set; }

        /// <summary>
        /// Gets or sets the identity of the user, device, and application which last modified the item. Read-only.
        /// </summary>
        public IdentitySet ModifiedBy
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time of item creation. Read-only.
        /// </summary>
        public DateTimeOffset? CreatedDateTime
        { get; set; }

        /// <summary>
        /// Gets or sets the date and time the item was last modified. Read-only.
        /// </summary>
        public DateTimeOffset? LastModifiedDateTime
        { get; set; }

        /// <summary>
        /// Gets or sets the size of the item in bytes. Read-only.
        /// </summary>
        public long? Size
        { get; set; }

        /// <summary>
        /// Gets or sets the URL that displays the resource in the browser. Read-only.
        /// </summary>
        public Uri WebUrl
        { get; set; }

        /// <summary>
        /// Gets or sets the user-visible description of the item. Read-write.
        /// </summary>
        public string Description
        { get; set; }

        /// <summary>
        /// Gets or sets the parent information, if the item has a parent. Read-write.
        /// </summary>
        public ItemReference ParentReference
        { get; set; }

        /// <summary>
        /// Gets or sets the collection containing Item objects for the immediate children of Item.
        /// </summary>
        /// <remarks>
        /// Only items representing folders have children.
        /// </remarks>
        public List<Item> Children
        { get; set; }

        /// <summary>
        /// Gets or sets the folder metadata, if the item is a folder. Read-only.
        /// </summary>
        public Folder Folder
        { get; set; }

        /// <summary>
        /// Gets or sets the file metadata, if the item is a file. Read-only.
        /// </summary>
        public File File
        { get; set; }

        /// <summary>
        /// Gets or sets the file system information on client. Read-write.
        /// </summary>
        public FileSystemInfo FileSystemInfo
        { get; set; }

        /// <summary>
        /// Gets or sets the image metadata, if the item is an image. Read-only.
        /// </summary>
        public Image Image
        { get; set; }

        /// <summary>
        /// Gets or sets the photo metadata, if the item is a photo. Read-only.
        /// </summary>
        public Photo Photo
        { get; set; }

        /// <summary>
        /// Gets or sets the audio metadata, if the item is an audio file. Read-only.
        /// </summary>
        public Audio Audio
        { get; set; }

        /// <summary>
        /// Gets or sets the video metadata, if the item is a video. Read-only.
        /// </summary>
        public Video Video
        { get; set; }

        /// <summary>
        /// Gets or sets the location metadata, if the item has location data. Read-only.
        /// </summary>
        public Location Location
        { get; set; }

        /// <summary>
        /// Gets or sets the search metadata, if the item is from a search result.
        /// </summary>
        public SearchResultFacet SearchResult
        { get; set; }

        /// <summary>
        /// Gets or sets the information about the deleted state of the item. Read-only.
        /// </summary>
        public Deleted Deleted
        { get; set; }

        /// <summary>
        /// Gets or sets the Thumbnails for this item.
        /// </summary>
        public ThumbnailSet Thumbnails
        { get; set; }

        /// <summary>
        /// Gets or sets the specialFolder facet that describes the identifier
        /// used for accessing the special folder.
        /// </summary>
        public SpecialFolder SpecialFolder
        { get; set; }

        /// <summary>
        /// Gets or sets a value that determines what to do if an
        /// item with a matching name already exists in this folder.
        /// </summary>
        [JsonProperty("@name.conflictBehavior")]
        public ConflictBehavior? ConflictBehavior
        { get; set; }
    }
}
