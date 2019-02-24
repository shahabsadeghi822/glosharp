using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace Glosharp.Helpers
{
    /// <summary>
    /// Reflects a collection of data returned from an API that can be paged
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IReadOnlyPagedCollection<T> : IReadOnlyList<T>
    {
        /// <summary>
        /// Returns the next page of items
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Desing", "CA1024:UsePropertiesWhereAppropriate", Justification = "Makes a network request")]
        Task<IReadOnlyPagedCollection<T>> GetNextPage();
    }
}