// <copyright file="Deleted.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// The Deleted facet indicates that the item on OneDrive has been deleted.
    /// </summary>
    /// <remarks>
    /// <para>
    /// In this version of the API, the presence (non-null) of the facet value indicates
    /// that the file was deleted. A null (or missing) value indicates that the file is not deleted.
    /// </para>
    /// <para>
    /// Note: While this facet is empty today, in future API revisions the facet may be populated
    /// with additional properties.
    /// </para>
    /// </remarks>
    public class Deleted
    {
    }
}
