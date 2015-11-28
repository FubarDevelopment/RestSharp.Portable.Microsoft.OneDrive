// <copyright file="Audio.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Audio facet groups audio-related data on OneDrive into a single structure.
    /// </summary>
    /// <remarks>
    /// It is available on the <see cref="Item.Audio"/> property of <see cref="Item"/> resources
    /// that have associated audio.
    /// </remarks>
    public class Audio
    {
        /// <summary>
        /// Gets or sets the title of the album for this audio file.
        /// </summary>
        public string Album
        { get; set; }

        /// <summary>
        /// Gets or sets the artist named on the album for the audio file.
        /// </summary>
        public string AlbumArtist
        { get; set; }

        /// <summary>
        /// Gets or sets the performing artist for the audio file.
        /// </summary>
        public string Artist
        { get; set; }

        /// <summary>
        /// Gets or sets bitrate expressed in kbps.
        /// </summary>
        public string Bitrate
        { get; set; }

        /// <summary>
        /// Gets or sets the name of the composer of the audio file.
        /// </summary>
        public string Composers
        { get; set; }

        /// <summary>
        /// Gets or sets copyright information for the audio file.
        /// </summary>
        public string Copyright
        { get; set; }

        /// <summary>
        /// Gets or sets the number of the disc this audio file came from.
        /// </summary>
        public int? Disc
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of discs in this album.
        /// </summary>
        public int? DiscCount
        { get; set; }

        /// <summary>
        /// Gets or sets duration of the audio file, expressed in milliseconds.
        /// </summary>
        public long? Duration
        { get; set; }

        /// <summary>
        /// Gets or sets the genre of this audio file.
        /// </summary>
        public string Genre
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is protected with digital rights management.
        /// </summary>
        public bool HasDrm
        { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the file is encoded with a variable bitrate.
        /// </summary>
        public bool IsVariableBitrate
        { get; set; }

        /// <summary>
        /// Gets or sets the title of the audio file.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// Gets or sets the number of the track on the original disc for this audio file.
        /// </summary>
        public int? Track
        { get; set; }

        /// <summary>
        /// Gets or sets the total number of tracks on the original disc for this audio file.
        /// </summary>
        public int? TrackCount
        { get; set; }

        /// <summary>
        /// Gets or sets the year the audio file was recorded.
        /// </summary>
        public int? Year
        { get; set; }
    }
}
