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
        /// <param name="boardId">
        /// A <see cref="Board"/> Id to reference.
        /// </param>
        /// <remarks>
        /// This method returns a Tuple with a <see cref="HttpStatusCode"/> as Item1, a string
        /// with the http status text and a <see cref="Column"/> as Item3.
        /// </remarks>
        /// <example>
        /// <code>
        /// var columnList = await glo.Column.GetColumn(boardId);
        /// </code>
        /// </example>
        /// <returns>Tuple with 3 items.</returns>
        Task<Tuple<HttpStatusCode, string, List<Column>>> GetColumns(string boardId);

        /// <summary>
        /// Creates a new column in a board.
        /// </summary>
        /// <param name="boardId">
        /// A <see cref="Board"/> Id to reference
        /// </param>
        /// <param name="column"><see cref="Column"/>
        /// A new <see cref="Column"/> that will be created
        /// </param>
        /// <remarks>
        /// This method will return a <see cref="Column"/> that will be populated with auto-generated fields
        /// such as the 'id' and 'create_date'.
        /// </remarks>
        /// <example>
        /// <code>
        /// var newColumnResponse = await glo.Column.Create(boardId, column);
        /// </code>
        /// </example>
        /// <returns>Tuple with 3 items.</returns>
        Task<Tuple<HttpStatusCode, string, Column>> Create(string boardId, Column column);

        /// <summary>
        /// Edits a column by ID
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <param name="column"><see cref="Column"/></param>
        /// <returns></returns>
        Task<Tuple<HttpStatusCode, string, Column>> Update(string boardId, Column column);

        /// <summary>
        /// Deletes a column by ID
        /// </summary>
        /// <param name="boardId"><see cref="Board"/></param>
        /// <param name="columnId"><see cref="Column"/></param>
        /// <returns></returns>
        Task<Tuple<HttpStatusCode, string>> Delete(string boardId, string columnId);
    }
}