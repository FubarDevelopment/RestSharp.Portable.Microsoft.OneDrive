// <copyright file="IRequestFactory.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Net;
using System.Threading.Tasks;

using JetBrains.Annotations;

namespace RestSharp.Portable.Microsoft.OneDrive
{
    /// <summary>
    /// A factory interface which is used by <see cref="OneDriveService"/> to create a new <see cref="IRestClient"/> implementation
    /// and/or a new <see cref="HttpWebRequest"/>.
    /// </summary>
    public interface IRequestFactory
    {
        /// <summary>
        /// Creates a new instance of a <see cref="IRestClient"/>.
        /// </summary>
        /// <remarks>
        /// The OAuth2 authenticator has to be set!
        /// </remarks>
        /// <param name="baseUri">The base <see cref="Uri"/> to initialize the rest client with</param>
        /// <returns>The new <see cref="IRestClient"/> implementation</returns>
        [NotNull]
        IRestClient CreateRestClient([NotNull] Uri baseUri);

        /// <summary>
        /// Create a new <see cref="HttpWebRequest"/> for the given <paramref name="requestUri"/>
        /// </summary>
        /// <param name="requestUri">The <see cref="Uri"/> for the request</param>
        /// <returns>The new <see cref="HttpWebRequest"/> for the given <paramref name="requestUri"/></returns>
        [NotNull]
        Task<HttpWebRequest> CreateWebRequest([NotNull] Uri requestUri);
    }
}
