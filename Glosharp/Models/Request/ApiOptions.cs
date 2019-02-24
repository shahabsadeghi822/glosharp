using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Glosharp.Models.Request
{
    public class ApiOptions
    {
        public ApiOptions(int? page, int? perPage, Sort sortPage, bool archived)
        {
            Page = page;
            PerPage = perPage;
            SortPage = sortPage;
            Archived = archived;
        }

        public ApiOptions()
        {
            Page = 1;
            PerPage = 50;
            SortPage = Sort.Asc;
            Archived = false;
        }

        public static ApiOptions None => new ApiOptions();

        /// <summary>
        /// Specify the start page for pagination actions
        /// </summary>
        /// <value></value>
        public int? Page { get; set; }

        /// <summary>
        /// Specify the number of items per page
        /// </summary>
        /// <value></value>
        public int? PerPage { get; set; }

        /// <summary>
        /// Specify the sorting order for returns <see cref="Sort"/>
        /// </summary>
        /// <remarks>
        /// Ascending or Descending
        /// </remarks>
        /// <value></value>
        public Sort SortPage { get; set; }

        /// <summary>
        /// Specify if Archived items should be returned
        /// </summary>
        /// <value></value>
        public bool? Archived { get; set; }

        /// <summary>
        /// Page sorting options
        /// </summary>
        public enum Sort
        {
            Asc,
            Desc
        }   
    }
}