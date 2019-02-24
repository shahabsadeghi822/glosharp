using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Models.Request;
using Glosharp.Models.Response;

namespace Glosharp.Helpers
{
    public static class ApiUrls
    {
        #region Authorization and Tokens
        
        public static Uri Authorization()
        {
            return "https://app.gitkraken.com/oauth/authorize".FormatUri();
        }

        public static Uri TokenUri()
        {
            return "https://api.gitkraken.com/oauth/access_token".FormatUri();
        }
        
        #endregion

        #region Boards

        public static string Boards(ApiOptions options)
        {
            var sort = options.SortPage == ApiOptions.Sort.Asc ? "asc" : "desc";
            
            return $"boards?page={options.Page}&per_page={options.PerPage}&sort={sort}&archived={options.Archived}" +
                   $"&fields=name&fields=members&fields=labels&fields=invited_members&fields=created_date" +
                   $"&fields=created_by&fields=columns&fields=archived_date&fields=archived_columns";
        }

        public static string Board(ApiOptions options, string boardId)
        {
            var sort = options.SortPage == ApiOptions.Sort.Asc ? "asc" : "desc";
            return $"boards/{boardId}?page={options.Page}&per_page={options.PerPage}&sort={sort}&archived={options.Archived}" +
                   $"&fields=name&fields=members&fields=labels&fields=invited_members&fields=created_date" +
                   $"&fields=created_by&fields=columns&fields=archived_date&fields=archived_columns";
        }

        #endregion

        #region Users

        public static string User()
        {
            return "user?fields=created_date&fields=email&fields=name&fields=username";
        }

        public static string PartialUser()
        {
            return "user";
        }

        #endregion
        
        #region Cards

        /// <summary>
        /// Creates a formatted request string returning all fields
        /// that are available.
        /// </summary>
        /// <param name="options"><see cref="ApiOptions"/>
        /// Can be null, will use default options.
        /// </param>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <returns></returns>
        public static string GetCards(ApiOptions options, string boardId)
        {
            var sort = options.SortPage == ApiOptions.Sort.Asc ? "asc" : "desc";
            return $"boards/{boardId}/cards?fields=archived_date&fields=assignees&fields=attachment_count&" +
                   $"fields=board_id&fields=column_id&fields=comment_count&fields=completed_task_count&" +
                   $"fields=created_by&fields=created_date&fields=due_date&fields=description&fields=labels&" +
                   $"fields=name&fields=total_task_count&fields=updated_date&archived={options.Archived}&page={options.Page}&" +
                   $"per_page={options.PerPage}&sort={sort}";
        }

        /// <summary>
        /// Creates a formatted request string to create a card
        /// using POST.
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <returns></returns>
        public static string CreateCard(string boardId)
        {
            return $"boards/{boardId}/cards";
        }
        
        #endregion
        
        #region Columns

        /// <summary>
        /// Creates a formatted request string returning all
        /// columns for a given board
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <returns></returns>
        public static string GetColumns(string boardId)
        {
            return $"boards/{boardId}?fields=columns";
        }

        /// <summary>
        /// Creates a new column in a board
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <returns></returns>
        public static string CreateColumns(string boardId)
        {
            return $"boards/{boardId}/columns";
        }

        /// <summary>
        /// Updates a column by ID
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <param name="columnId"><see cref="Column"/></param>
        /// <returns></returns>
        public static string UpdateColumn(string boardId, string columnId)
        {
            return $"boards/{boardId}/columns/{columnId}";
        }
        
        /// <summary>
        /// Deletes a column by ID
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <param name="columnId"><see cref="Column"/></param>
        /// <returns></returns>
        public static string DeleteColumn(string boardId, string columnId)
        {
            return $"boards/{boardId}/columns/{columnId}";
        }

        #endregion
    }
}
