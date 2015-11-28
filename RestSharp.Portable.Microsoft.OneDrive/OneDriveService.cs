// <copyright file="OneDriveService.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Newtonsoft.Json.Linq;
using RestSharp.Portable.Deserializers;
using RestSharp.Portable.Microsoft.OneDrive.Model;

namespace RestSharp.Portable.Microsoft.OneDrive
{
    /// <summary>
    /// A class to access the OneDrive API V1
    /// </summary>
    public sealed class OneDriveService : IDisposable
    {
        /// <summary>
        /// The base path for the OneDrive API
        /// </summary>
        public const string DriveApiPath = "https://api.onedrive.com/v1.0/";

        private static readonly ISerializer RestSerializer = new ConservativeJsonSerializer();

        private static readonly MethodInfo _addRangeMethod;

        private readonly IRequestFactory _restClientFactory;

        private readonly IRestClient _restClient;

        private bool _disposedValue; // Dient zur Erkennung redundanter Aufrufe.

        static OneDriveService()
        {
            _addRangeMethod = typeof(HttpWebRequest).GetRuntimeMethod("AddRange", new[] { typeof(long) });
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneDriveService"/> class.
        /// </summary>
        /// <param name="factory">The factory to create the <see cref="IRestClient"/> implementation and <see cref="HttpWebRequest"/> instance.</param>
        public OneDriveService([NotNull] IRequestFactory factory)
        {
            _restClientFactory = factory;
            _restClient = CreateClient();
        }

        /// <summary>
        /// Appends parts to a path
        /// </summary>
        /// <param name="path">The path to append to</param>
        /// <param name="parts">The parts to append</param>
        /// <returns>The </returns>
        public static string CombinePath(string path, params string[] parts)
        {
            return CombinePath(path, (IEnumerable<string>)parts);
        }

        /// <summary>
        /// Appends parts to a path
        /// </summary>
        /// <param name="path">The path to append to</param>
        /// <param name="parts">The parts to append</param>
        /// <returns>The </returns>
        public static string CombinePath(string path, IEnumerable<string> parts)
        {
            var result = new StringBuilder();
            bool addSlash;
            if (!string.IsNullOrEmpty(path))
            {
                result.Append(path);
                addSlash = !path.EndsWith("/");
            }
            else
            {
                addSlash = false;
            }
            foreach (var part in parts)
            {
                if (addSlash)
                    result.Append('/');
                else
                    addSlash = true;
                result.Append(part.Replace("\\", "\\\\").Replace("/", "\\/"));
            }
            return result.ToString();
        }

        /// <summary>
        /// Split the path into parts
        /// </summary>
        /// <param name="path">The path to split</param>
        /// <returns>The parts of the path</returns>
        public static IReadOnlyList<string> SplitPath(string path)
        {
            var parts = new List<string>();
            if (string.IsNullOrEmpty(path))
                return parts;
            var isEscaped = false;
            var partCollector = new StringBuilder();
            foreach (var ch in path.ToCharArray())
            {
                if (!isEscaped)
                {
                    if (ch == '\\')
                    {
                        isEscaped = true;
                    }
                    else if (ch == '/')
                    {
                        parts.Add(partCollector.ToString());
                        partCollector.Clear();
                    }
                    else
                    {
                        partCollector.Append(ch);
                    }
                }
                else
                {
                    if (ch == '/' || ch == '\\')
                    {
                        partCollector.Append(ch);
                    }
                    else
                    {
                        partCollector.Append('\\').Append(ch);
                    }
                    isEscaped = false;
                }
            }
            parts.Add(partCollector.ToString());
            return parts;
        }

        /// <summary>
        /// Get all drives for the user
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The list of all drives for the user</returns>
        [NotNull, ItemNotNull]
        public async Task<IReadOnlyList<Drive>> GetDrivesAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest("drives");
            var response = await _restClient.Execute<ResultList<Drive>>(request, cancellationToken);
            return response.Data.Value;
        }

        /// <summary>
        /// Gets the default drive for the user
        /// </summary>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The default drive</returns>
        [NotNull, ItemNotNull]
        public async Task<Drive> GetDefaultDriveAsync(CancellationToken cancellationToken)
        {
            var request = new RestRequest("drive");
            var response = await _restClient.Execute<Drive>(request, cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Gets the root folder for a drive
        /// </summary>
        /// <param name="driveId">The drive ID to get the root folder for</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The root folder of the given <paramref name="driveId"/></returns>
        [NotNull, ItemNotNull]
        public async Task<Item> GetRootFolderAsync([NotNull] string driveId, CancellationToken cancellationToken)
        {
            var request = new RestRequest($"drives/{driveId}/root");
            var response = await _restClient.Execute<Item>(request, cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Gets a special folder for the given <paramref name="driveId"/>
        /// </summary>
        /// <param name="driveId">The drive ID to get the special folder for</param>
        /// <param name="name">The name of the special folder</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The special folder identified by the given <paramref name="name"/></returns>
        [NotNull, ItemNotNull]
        public async Task<Item> GetSpecialFolderAsync([NotNull] string driveId, [NotNull] string name, CancellationToken cancellationToken)
        {
            var request = new RestRequest($"drives/{driveId}/special/{name}");
            var response = await _restClient.Execute<Item>(request, cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Get all child items of a given item <paramref name="id"/>
        /// </summary>
        /// <param name="driveId">The drive ID the item <paramref name="id"/> belongs to.</param>
        /// <param name="id">The item ID to get the children for</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The child items</returns>
        [NotNull, ItemNotNull]
        public async Task<IReadOnlyList<Item>> GetItemChildrenAsync([NotNull] string driveId, [NotNull] string id, CancellationToken cancellationToken)
        {
            var request = new RestRequest($"drives/{driveId}/items/{id}/children");
            var response = await _restClient.Execute<ResultList<Item>>(request, cancellationToken);
            return response.Data.Value;
        }

        /// <summary>
        /// Creates a folder item
        /// </summary>
        /// <param name="driveId">The drive ID of the given <paramref name="parentId"/></param>
        /// <param name="parentId">The item ID where this folder will be created in</param>
        /// <param name="name">The new folder name</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The newly created folder item</returns>
        [NotNull, ItemNotNull]
        public async Task<Item> CreateFolderAsync(string driveId, string parentId, string name, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"drives/{driveId}/items/{parentId}/children");
            request.AddBody(new Item
            {
                Name = name,
                Folder = new Folder(),
            });
            var response = await _restClient.Execute<Item>(request, cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Moves an item with the <paramref name="itemId"/> to <paramref name="newParent"/> and changes its name to <paramref name="newName"/>
        /// </summary>
        /// <param name="driveId">The drive ID the <paramref name="itemId"/> and <paramref name="newParent"/> belong to</param>
        /// <param name="itemId">The ID of the item to move/rename</param>
        /// <param name="newName">The new item name</param>
        /// <param name="newParent">The new parent of the <paramref name="itemId"/></param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The new item</returns>
        [NotNull, ItemNotNull]
        public Task<Item> MoveAsync([NotNull] string driveId, [NotNull] string itemId, [NotNull] string newName, ItemReference newParent, CancellationToken cancellationToken)
        {
            var newItemValues = new Item
            {
                Name = newName,
                ParentReference = newParent,
            };
            return UpdateAsync(driveId, itemId, newItemValues, cancellationToken);
        }

        /// <summary>
        /// Updates an item with the <paramref name="itemId"/> with the values in <paramref name="newItemValues"/>
        /// </summary>
        /// <param name="driveId">The drive ID the <paramref name="itemId"/> belongs to</param>
        /// <param name="itemId">The ID of the item to modify</param>
        /// <param name="newItemValues">Thew new item values</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The changed item</returns>
        [NotNull, ItemNotNull]
        public async Task<Item> UpdateAsync([NotNull] string driveId, [NotNull] string itemId, [NotNull] Item newItemValues, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"drives/{driveId}/items/{itemId}", Method.PATCH);
            request.AddBody(newItemValues);
            var response = await _restClient.Execute<Item>(request, cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Deletes an item with the <paramref name="itemId"/>
        /// </summary>
        /// <param name="driveId">The drive ID the <paramref name="itemId"/> belongs to</param>
        /// <param name="itemId">The ID of the item to delete</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The task</returns>
        [NotNull]
        public async Task DeleteAsync([NotNull] string driveId, [NotNull] string itemId, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"drives/{driveId}/items/{itemId}", Method.DELETE);
            await _restClient.Execute<Item>(request, cancellationToken);
        }

        /// <summary>
        /// Gets an item with the <paramref name="itemId"/>
        /// </summary>
        /// <param name="driveId">The drive ID the <paramref name="itemId"/> belongs to</param>
        /// <param name="itemId">The ID of the item to get the meta data for</param>
        /// <param name="withChildren">Include the children in the response?</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The item identified by <paramref name="itemId"/></returns>
        [NotNull, ItemNotNull]
        public async Task<Item> GetItemAsync([NotNull] string driveId, [NotNull] string itemId, bool withChildren, CancellationToken cancellationToken)
        {
            var request = CreateRequest($"drives/{driveId}/items/{itemId}");
            if (withChildren)
                request.AddParameter("expand", "children");
            var response = await _restClient.Execute<Item>(request, cancellationToken);
            return response.Data;
        }

        /// <summary>
        /// Gets a child item of <paramref name="parentId"/> with the given <paramref name="name"/>.
        /// </summary>
        /// <param name="driveId">The drive ID the <paramref name="parentId"/> belongs to</param>
        /// <param name="parentId">The ID of the item to get the child from</param>
        /// <param name="name">The child item name</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The found child item</returns>
        [NotNull, ItemCanBeNull]
        public async Task<Item> GetChildItemAsync([NotNull] string driveId, [NotNull] string parentId, [NotNull] string name, CancellationToken cancellationToken)
        {
            return (await GetItemChildrenAsync(driveId, parentId, cancellationToken))
                .FirstOrDefault(x => string.Equals(x.Name, name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Gets the download URL for the given <paramref name="itemId"/>
        /// </summary>
        /// <param name="driveId">The drive ID the <paramref name="itemId"/> belongs to</param>
        /// <param name="itemId">The ID of the item to get the download URL for</param>
        /// <returns>The download URL</returns>
        [NotNull]
        public string GetDownloadUrl([NotNull] string driveId, [NotNull] string itemId)
        {
            var request = CreateRequest($"drives/{driveId}/items/{itemId}/content", Method.GET);
            return _restClient.BuildUri(request).ToString();
        }

        /// <summary>
        /// Get a <see cref="HttpWebResponse"/> to download a files contents
        /// </summary>
        /// <param name="driveId">The ID of the <see cref="Drive"/></param>
        /// <param name="itemId">The ID of the <see cref="Item"/> to download</param>
        /// <param name="from">The offset where the download starts from</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The <see cref="HttpWebResponse"/> used to download the file</returns>
        [NotNull, ItemNotNull]
        public async Task<HttpWebResponse> GetDownloadResponseAsync([NotNull] string driveId, [NotNull] string itemId, long? from, CancellationToken cancellationToken)
        {
            var downloadUrl = GetDownloadUrl(driveId, itemId);
            var request = await _restClientFactory.CreateWebRequest(new Uri(downloadUrl));
            if (from != null)
            {
                if (_addRangeMethod != null)
                {
                    _addRangeMethod.Invoke(request, new object[] { from.Value });
                }
                else
                {
                    var range = new HttpRange("bytes", new HttpRangeItem(from, null));
                    request.Headers[HttpRequestHeader.Range] = range.ToString();
                }
            }
            var response = (HttpWebResponse)await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null);
            return response;
        }

        /// <summary>
        /// Uploads a file
        /// </summary>
        /// <param name="driveId">The drive ID the <paramref name="parentId"/> belongs to</param>
        /// <param name="parentId">The ID where the new file will be created in</param>
        /// <param name="name">The new file name</param>
        /// <param name="input">The data to upload</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The newly created file item</returns>
        [NotNull, ItemNotNull]
        public async Task<Item> UploadFileAsync([NotNull] string driveId, [NotNull] string parentId, [NotNull] string name, [NotNull] Stream input, CancellationToken cancellationToken)
        {
            // Create upload session
            var request = CreateRequest($"drives/{driveId}/items/{parentId}:/{name}:/upload.createSession");
            request.AddBody(
                new
                {
                    Item = new Item
                    {
                        Name = name,
                        ConflictBehavior = ConflictBehavior.Replace,
                    },
                });
            var deserializer = new JsonDeserializer();
            var response = await _restClient.Execute<UploadSession>(request, cancellationToken);
            var uploadSession = response.Data;
            var inputLength = input.Length;
            var sessionUri = uploadSession.UploadUrl;

            // Upload the data
            using (var uploadClient = CreateClient())
            {
                uploadClient.IgnoreResponseStatusCode = true;
                int blockSize = 262144; // Info from Google PUT error message
                var buffer = new byte[blockSize];
                byte[] temp = null;

                // As long as we have an upload session, upload the data...
                while (uploadSession != null)
                {
                    IRestResponse fragmentUploadResponse = null;

                    // Upload all data requested by the given ranges
                    var ranges = uploadSession.ToHttpRange();
                    foreach (var range in ranges.Normalize(input.Length))
                    {
                        // Split the data to upload into blocks (to keep memory usage small)
                        int size;
                        var length = range.Length;
                        for (long i = 0; i != length; i += size)
                        {
                            size = (int)Math.Min(range.Length, blockSize);

                            var readSize = input.Read(buffer, 0, size);
                            if (readSize == 0)
                                throw new InvalidOperationException($"Failed to read {size} bytes from position {i}");

                            size = readSize;
                            var requestRange = new HttpRange("bytes", new HttpRangeItem(range.From + i, range.From + i + size - 1));

                            if (temp == null || temp.Length != size)
                                temp = new byte[size];
                            Array.Copy(buffer, temp, size);

                            var requestUploadChunk = CreateRequest(sessionUri, Method.PUT);
                            requestUploadChunk.AddHeader("Content-Range", requestRange.ToString(requestRange.RangeItems.Single(), inputLength));
                            requestUploadChunk.AddParameter(string.Empty, temp, ParameterType.RequestBody, "application/octet-stream");

                            fragmentUploadResponse = await uploadClient.Execute(requestUploadChunk, cancellationToken);
                            if (!fragmentUploadResponse.IsSuccess)
                                throw new WebException(fragmentUploadResponse.StatusDescription, WebExceptionStatus.UnknownError);
                        }
                    }

                    if (fragmentUploadResponse != null)
                    {
                        // Deserialize the data into a JObject
                        var data = deserializer.Deserialize<JObject>(fragmentUploadResponse);
                        if (data.Property("id") == null)
                        {
                            // Convert to a new UploadSession when we don't have the "id" property
                            uploadSession = data.ToObject<UploadSession>();
                        }
                        else
                        {
                            // Otherwise return the data (which means: we just uploaded the last chunk)
                            var item = data.ToObject<Item>();
                            return item;
                        }
                    }
                    else
                    {
                        // should never happen...
                        uploadSession = null;
                    }
                }
            }

            // We didn't receive an "Item" object in the last upload chunk: Just query it
            // from the server ourselves.
            var result = await GetChildItemAsync(driveId, parentId, name, cancellationToken);
            if (result == null)
                throw new InvalidOperationException();
            return result;
        }

        /// <summary>
        /// Get or create the subfolder the <paramref name="folderItem"/> and <paramref name="path"/> are pointing to
        /// </summary>
        /// <param name="driveId">The drive ID</param>
        /// <param name="folderItem">The folder item</param>
        /// <param name="path">The path to the subfolder (divided by a /)</param>
        /// <param name="cancellationToken">The cancellation token</param>
        /// <returns>The metadata of the found or created subfolder</returns>
        [NotNull]
        public async Task<Item> GetOrCreateDirectoryAsync([NotNull] string driveId, [NotNull] Item folderItem, [NotNull] string path, CancellationToken cancellationToken)
        {
            var current = folderItem;
            var folderParts = SplitPath(path).Where(x => !string.IsNullOrEmpty(x));
            foreach (var folderPart in folderParts)
            {
                var subFolder = await GetChildItemAsync(driveId, current.Id, folderPart, cancellationToken)
                    ?? await CreateFolderAsync(driveId, current.Id, folderPart, cancellationToken);
                current = subFolder;
            }
            return current;
        }

        /// <summary>
        /// Dispose all resources
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }

        [NotNull]
        private IRestClient CreateClient()
        {
            var client = _restClientFactory.CreateRestClient(new Uri(DriveApiPath));
            return client;
        }

        [NotNull]
        private IRestRequest CreateRequest([NotNull] string resource)
        {
            return new RestRequest(resource)
            {
                Serializer = RestSerializer,
            };
        }

        [NotNull]
        private IRestRequest CreateRequest([NotNull] string resource, Method method)
        {
            return new RestRequest(resource, method)
            {
                Serializer = RestSerializer,
            };
        }

        [NotNull]
        private IRestRequest CreateRequest([NotNull] Uri resource, Method method)
        {
            return new RestRequest(resource, method)
            {
                Serializer = RestSerializer,
            };
        }

        private void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _restClient.Dispose();
                }
                _disposedValue = true;
            }
        }
    }
}
