// <copyright file="ConservativeJsonSerializer.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

using JsonSerializer = RestSharp.Portable.Serializers.JsonSerializer;

namespace RestSharp.Portable.Microsoft.OneDrive
{
    internal class ConservativeJsonSerializer : JsonSerializer
    {
        /// <summary>
        /// Configure the <see cref="T:RestSharp.Portable.Serializers.JsonSerializer"/>
        /// </summary>
        /// <param name="serializer">The serializer to configure</param>
        protected override void ConfigureSerializer(Newtonsoft.Json.JsonSerializer serializer)
        {
            base.ConfigureSerializer(serializer);
            serializer.NullValueHandling = NullValueHandling.Ignore;
            serializer.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
