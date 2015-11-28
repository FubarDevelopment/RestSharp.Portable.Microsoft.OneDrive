// <copyright file="StringExtensions.cs" company="Fubar Development Junker">
// Copyright (c) Fubar Development Junker. All rights reserved.
// </copyright>

namespace RestSharp.Portable.Microsoft.OneDrive
{
    internal static class StringExtensions
    {
        public static string Escape(this string s)
        {
            return s?.Replace("\\", "\\\\").Replace("'", "\\'");
        }
    }
}
