using System.Collections.Generic;
using System.Threading.Tasks;
using Glosharp.Models.Response;
namespace Glosharp.Clients
{
    public interface ICardsClient
    {
        /// <summary>
        /// Gets all cards across all boards that are visible to the
        /// current signed in user.
        /// </summary>
        /// <param name="boards">
        /// List of <see cref="Board"/>s.
        /// </param>
        /// <returns></returns>
        Task<IReadOnlyList<Card>> GetAll();
        
        /// <summary>
        /// Get all cards for the current board.
        /// </summary>
        /// <param name="boardId">
        /// Board Id for a given <see cref="Board"/>
        /// </param>
        /// <returns></returns>
        Task<IReadOnlyList<Card>> GetAll(string boardId);

        /// <summary>
        /// Gets all assigned cards for a given user.
        /// </summary>
        /// <param name="boards">
        /// List of <see cref="Board"/>s.
        /// </param>
        /// <param name="user">
        /// <see cref="User"/>
        /// </param>
        /// <returns></returns>
        Task<IReadOnlyList<Card>> GetAllAssigned(IReadOnlyList<Board> boards, User user);

        /// <summary>
        /// Creates a new card in a column.
        /// </summary>
        /// <param name="card">
        /// A <see cref="Card"/> to upload.
        /// </param>
        /// <param name="columnId">
        /// Column to place the new card into.
        /// </param>
        /// <param name="boardId">
        /// Board to place the new card on.
        /// </param>
        /// <returns></returns>
        Task<Card> Create(Card card, string columnId, string boardId);

    }
}