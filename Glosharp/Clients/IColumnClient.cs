using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Glosharp.Models.Response;
using RestSharp;

namespace Glosharp.Clients
{
    public interface IColumnClient
    {
        /// <summary>
        /// Gets a list of columns in a board.
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// Item 1: <see cref="HttpStatusCode"/> - Status Code
        /// Item 2: <see cref="String"/> - Status Description
        /// Item 3: <see cref="List{Column}"/>
        Task<Tuple<HttpStatusCode, string, List<Column>>> GetColumns(string boardId);

        /// <summary>
        /// Creates a new column in a board.
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <param name="column"><see cref="Column"/></param>
        /// <returns>
        /// Item 1: <see cref="HttpStatusCode"/> - Status Code
        /// Item 2: <see cref="String"/> - Status Description
        /// Item 3: <see cref="Column"/> - Column
        /// </returns>
        Task<Tuple<HttpStatusCode, string, Column>> Create(string boardId, Column column);

        /// <summary>
        /// Edits a column by ID
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <param name="columnId"><see cref="Column"/></param>
        /// <returns></returns>
        Task<Column> Update(string boardId, Column column);

        /// <summary>
        /// Deletes a column by ID
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <param name="columnId"><see cref="Column"/></param>
        /// <returns></returns>
        Task<HttpStatusCode> Delete(string boardId, string columnId);
    }
}