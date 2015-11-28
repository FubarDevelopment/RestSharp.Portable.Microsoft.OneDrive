// <copyright file="HttpRangeItem.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Text.RegularExpressions;

using JetBrains.Annotations;

namespace RestSharp.Portable.Microsoft.OneDrive
{
    /// <summary>
    /// Range for a HTTP request or response
    /// </summary>
    public class HttpRangeItem
    {
        private static readonly Regex ParsePattern = new Regex(@"^((\d+)-(\d+))|((\d+)-)|(-(\d+))|(\d+)$", RegexOptions.CultureInvariant);

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRangeItem"/> class.
        /// </summary>
        public HttpRangeItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRangeItem"/> class.
        /// </summary>
        /// <param name="from">From byte</param>
        /// <param name="to">To byte</param>
        public HttpRangeItem(long? from, long? to)
        {
            From = from;
            To = to;
        }

        /// <summary>
        /// Gets the start position
        /// </summary>
        public long? From { get; }

        /// <summary>
        /// Gets the end position
        /// </summary>
        public long? To { get; }

        /// <summary>
        /// Parses a <see cref="HttpRangeItem"/> from a string
        /// </summary>
        /// <remarks>
        /// Allowed are: "*", "from-", "-to", "from-to"
        /// </remarks>
        /// <param name="rangeItem">The string to parse</param>
        /// <returns>The new <see cref="HttpRangeItem"/></returns>
        [NotNull]
        public static HttpRangeItem Parse(string rangeItem)
        {
            if (rangeItem == "*")
                return new HttpRangeItem();
            var match = ParsePattern.Match(rangeItem);
            if (!match.Success)
                throw new ArgumentOutOfRangeException(nameof(rangeItem));
            var s = match.Groups[8].Value;
            if (!string.IsNullOrEmpty(s))
            {
                var v = Convert.ToInt64(s, 10);
                return new HttpRangeItem(v, v);
            }
            s = match.Groups[7].Value;
            if (!string.IsNullOrEmpty(s))
            {
                var v = Convert.ToInt64(s, 10);
                return new HttpRangeItem(null, v);
            }
            s = match.Groups[5].Value;
            if (!string.IsNullOrEmpty(s))
            {
                var v = Convert.ToInt64(s, 10);
                return new HttpRangeItem(v, null);
            }
            var from = Convert.ToInt64(match.Groups[2].Value, 10);
            var to = Convert.ToInt64(match.Groups[3].Value, 10);
            return new HttpRangeItem(from, to);
        }

        /// <summary>
        /// Returns the textual representation of the HTTP range item
        /// </summary>
        /// <returns>the textual representation of the HTTP range item</returns>
        public override string ToString()
        {
            if (From.HasValue || To.HasValue)
                return $"{From}-{To}";
            return "*";
        }

        internal NormalizedHttpRangeItem Normalize(long totalLength)
        {
            if (!From.HasValue && !To.HasValue)
                return new NormalizedHttpRangeItem(0, totalLength - 1);
            if (From.HasValue && To.HasValue)
                return new NormalizedHttpRangeItem(From.Value, To.Value);
            if (From.HasValue)
                return new NormalizedHttpRangeItem(From.Value, totalLength - 1);
            return new NormalizedHttpRangeItem(totalLength - To.Value, totalLength - 1);
        }
    }
}
