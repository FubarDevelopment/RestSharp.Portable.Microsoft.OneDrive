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
        /// The title of the album for this audio file.
        /// </summary>
        public string Album
        { get; set; }

        /// <summary>
        /// The artist named on the album for the audio file.
        /// </summary>
        public string AlbumArtist
        { get; set; }

        /// <summary>
        /// The performing artist for the audio file.
        /// </summary>
        public string Artist
        { get; set; }

        /// <summary>
        /// Bitrate expressed in kbps.
        /// </summary>
        public string Bitrate
        { get; set; }

        /// <summary>
        /// The name of the composer of the audio file.
        /// </summary>
        public string Composers
        { get; set; }

        /// <summary>
        /// Copyright information for the audio file.
        /// </summary>
        public string Copyright
        { get; set; }

        /// <summary>
        /// The number of the disc this audio file came from.
        /// </summary>
        public int? Disc
        { get; set; }

        /// <summary>
        /// The total number of discs in this album.
        /// </summary>
        public int? DiscCount
        { get; set; }

        /// <summary>
        /// Duration of the audio file, expressed in milliseconds.
        /// </summary>
        public long? Duration
        { get; set; }

        /// <summary>
        /// The genre of this audio file.
        /// </summary>
        public string Genre
        { get; set; }

        /// <summary>
        /// Indicates if the file is protected with digital rights management.
        /// </summary>
        public bool HasDrm
        { get; set; }

        /// <summary>
        /// Indicates if the file is encoded with a variable bitrate.
        /// </summary>
        public bool IsVariableBitrate
        { get; set; }

        /// <summary>
        /// The title of the audio file.
        /// </summary>
        public string Title
        { get; set; }

        /// <summary>
        /// The number of the track on the original disc for this audio file.
        /// </summary>
        public int? Track
        { get; set; }

        /// <summary>
        /// The total number of tracks on the original disc for this audio file.
        /// </summary>
        public int? TrackCount
        { get; set; }

        /// <summary>
        /// The year the audio file was recorded.
        /// </summary>
        public int? Year
        { get; set; }
    }
}
