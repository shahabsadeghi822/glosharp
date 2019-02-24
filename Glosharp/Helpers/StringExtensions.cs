using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosharp.Helpers
{
    internal static class StringExtensions
    {
        public static Uri FormatUri(this string pattern, params object[] args)
        {
            Ensure.ArgumentNotNullOrEmptyString(pattern, "pattern");

            return new Uri(string.Format(CultureInfo.InvariantCulture, pattern, args), UriKind.Relative);
        }
    }
}
