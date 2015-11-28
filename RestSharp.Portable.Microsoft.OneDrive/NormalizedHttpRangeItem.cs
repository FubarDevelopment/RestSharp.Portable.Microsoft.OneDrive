// <copyright file="NormalizedHttpRangeItem.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive
{
    internal class NormalizedHttpRangeItem
    {
        public NormalizedHttpRangeItem(long from, long to)
        {
            From = from;
            To = to;
        }

        public long From { get; }

        public long To { get; }

        public long Length => To - From + 1;
    }
}
