using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Glosharp.Helpers;
using Glosharp.Http;
using Glosharp.Models.Response;

namespace Glosharp.Clients
{
    public interface IUserClient
    {
        /// <summary>
        /// Gets all User information that can be returned
        /// from the current logged in user.
        /// </summary>
        /// <returns></returns>
        Task<User> GetAllForCurrent();

        /// <summary>
        /// Gets partial user information, name and id from
        /// the current logged in user.
        /// </summary>
        /// <returns></returns>
        Task<PartialUser> GetPartialForCurrent();

        /// <summary>
        /// Gets the partial user information, with only id
        /// from the current logged  in user.
        /// </summary>
        /// <returns><see cref="PartialUserId"/></returns>
        Task<PartialUserId> GetPartialIdForCurrent();
    }
}