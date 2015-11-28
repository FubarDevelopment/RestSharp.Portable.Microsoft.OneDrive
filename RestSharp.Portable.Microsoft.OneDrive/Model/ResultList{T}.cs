// <copyright file="ResultList{T}.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System.Collections.Generic;

namespace RestSharp.Portable.Microsoft.OneDrive.Model
{
    /// <summary>
    /// Represents a collection of objects of type <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type of the collection returned</typeparam>
    public class ResultList<T>
    {
        /// <summary>
        /// The returned collection
        /// </summary>
        public List<T> Value
        { get; set; }
    }
}
