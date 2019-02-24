using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Models.Request;
using Glosharp.Models.Response;

namespace Glosharp.Clients
{
    public interface IBoardsClient
    {
        /// <summary>
        /// Gets all boards for the current user with default API options.
        /// </summary>
        /// <returns><list type="Board"></list></returns>
        Task<IReadOnlyList<Board>> GetAllForCurrent();

        /// <summary>
        /// Gets all boards for the current user with custom API options.
        /// </summary>
        /// <param name="options">
        /// A set of <see cref="T:Glosharp.Models.Request.ApiOptions" />
        /// </param>
        /// <returns><list type="Board"></list></returns>
        Task<IReadOnlyList<Board>> GetAllForCurrent(ApiOptions options);

        /// <summary>
        /// Get all data for a single board with the provided board id. 
        /// </summary>
        /// <param name="boardId"><see cref="ApiOptions"/>API Options</param>
        /// <returns></returns>
        Task<Board> GetAllForSingle(string boardId);

        /// <summary>
        /// Get all data for a single board with the provided board id.
        /// </summary>
        /// <param name="options"><see cref="ApiOptions"/>API options</param>
        /// <param name="boardId">Board Id</param>
        /// <returns></returns>
        Task<Board> GetAllForSingle(ApiOptions options, string boardId);
    }
}
