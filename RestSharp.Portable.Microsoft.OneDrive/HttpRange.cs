// <copyright file="HttpRange.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

using JetBrains.Annotations;

namespace RestSharp.Portable.Microsoft.OneDrive
{
    /// <summary>
    /// This class encapsualtes a HTTP range
    /// </summary>
    public class HttpRange
    {
        private static readonly char[] _splitEqualChar = new[] { '=' };

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpRange"/> class.
        /// </summary>
        /// <param name="unit">The unit of the range (currently only <code>bytes</code> is allowed)</param>
        /// <param name="rangeItems">The HTTP range items for this range</param>
        public HttpRange([NotNull] string unit, params HttpRangeItem[] rangeItems)
            : this(unit, false, rangeItems)
        {
        }

        private HttpRange([NotNull] string unit, bool ignoreInvalidUnit, params HttpRangeItem[] rangeItems)
        {
            if (!ignoreInvalidUnit && !string.IsNullOrEmpty(unit) && unit != "bytes")
                throw new NotSupportedException();
            Unit = string.IsNullOrEmpty(unit) ? "bytes" : unit;
            RangeItems = rangeItems.ToList();
        }

        /// <summary>
        /// Gets the unit for this HTTP range
        /// </summary>
        [NotNull]
        public string Unit { get; }

        /// <summary>
        /// Gets the HTTP range items
        /// </summary>
        [NotNull, ItemNotNull]
        public IReadOnlyList<HttpRangeItem> RangeItems { get; }

        /// <summary>
        /// Parses a <paramref name="range"/> into a new <see cref="HttpRange"/> instance
        /// </summary>
        /// <remarks>
        /// The range must be in the form <code>unit=(range)+</code>
        /// </remarks>
        /// <param name="range">The range to parse</param>
        /// <returns>The new <see cref="HttpRange"/></returns>
        public static HttpRange Parse(string range)
        {
            var parts = range.Split(_splitEqualChar, 2);
            var unit = parts[0];
            var rangeItems = parts[1].Split(',').Select(x => HttpRangeItem.Parse(x.Trim())).ToArray();
            return new HttpRange(unit, true, rangeItems);
        }

        /// <summary>
        /// Returns the textual representation of this range.
        /// </summary>
        /// <remarks>
        /// The return value of this function can be parsed using <see cref="Parse"/>.
        /// </remarks>
        /// <returns>The textual representation of this range</returns>
        public override string ToString()
        {
            return $"{Unit}={string.Join(",", RangeItems.Select(x => x.ToString()))}";
        }

        /// <summary>
        /// Returns the textual representation of a single <see cref="HttpRangeItem"/>
        /// </summary>
        /// <remarks>
        /// The return value of this function looks like <code>unit range/length</code>
        /// </remarks>
        /// <param name="rangeItem">The <see cref="HttpRangeItem"/> to get the textual representation for</param>
        /// <returns>The textual representation of <paramref name="rangeItem"/></returns>
        public virtual string ToString([NotNull] HttpRangeItem rangeItem)
        {
            return ToString(rangeItem, null);
        }

        /// <summary>
        /// Returns the textual representation of a single <see cref="HttpRangeItem"/>
        /// </summary>
        /// <remarks>
        /// The return value of this function looks like <code>unit range/length</code>
        /// </remarks>
        /// <param name="rangeItem">The <see cref="HttpRangeItem"/> to get the textual representation for</param>
        /// <param name="length">The length value to be used in the textual representation</param>
        /// <returns>The textual representation of <paramref name="rangeItem"/></returns>
        public virtual string ToString([NotNull] HttpRangeItem rangeItem, long? length)
        {
            return $"{Unit} {rangeItem}/{(length.HasValue ? length.Value.ToString(CultureInfo.InvariantCulture) : "*")}";
        }

        internal IReadOnlyList<NormalizedHttpRangeItem> Normalize(long totalLength)
        {
            var rangeItems = RangeItems.Select(x => x.Normalize(totalLength))
                .OrderBy(x => x.From).ThenBy(x => x.To);
            var result = new List<NormalizedHttpRangeItem>();
            NormalizedHttpRangeItem currentRangeItem = null;
            long currentTo = 0;
            foreach (var rangeItem in rangeItems)
            {
                if (currentRangeItem == null)
                {
                    currentRangeItem = rangeItem;
                    currentTo = rangeItem.To;
                }
                else
                {
                    var currentFrom = rangeItem.From;
                    if (currentFrom <= (currentTo + 1))
                    {
                        currentRangeItem = new NormalizedHttpRangeItem(currentRangeItem.From, rangeItem.To);
                    }
                    else
                    {
                        result.Add(currentRangeItem);
                        currentRangeItem = rangeItem;
                        currentTo = rangeItem.To;
                    }
                }
            }
            if (currentRangeItem != null)
                result.Add(currentRangeItem);
            return result;
        }
    }
}
