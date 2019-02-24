using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Glosharp.Models.Request
{
    public class ScopeOptions
    {
        public static ScopeOptions None
        {
            get { return new ScopeOptions(); }
        }

        /// <summary>
        /// Specifies what Scope that is being requested
        /// from the API.
        /// </summary>
        /// <remarks>
        /// Used only for OAuth.
        /// </remarks>
        public enum Scopes
        {
            BoardRead,
            BoardWrite,
            UserRead,
            UserWrite
        }
    }
}