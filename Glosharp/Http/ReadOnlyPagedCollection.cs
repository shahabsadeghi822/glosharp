using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Glosharp.Helpers;

namespace Glosharp.Http
{
    public class ReadOnlyPagedCollection<T> : ReadOnlyCollection<T>, IReadOnlyPagedCollection<T>
    {
        

        public ReadOnlyPagedCollection(IApiResponse<List<T>> response, Func<Uri, Task<IApiResponse<List<T>>>> nextPageFunc)
            : base(response != null ? response.Body ?? new List<T>() : new List<T>())
        {
            Func<Uri, Task<IApiResponse<List<T>>>> _nextPageFunc;
            Ensure.ArgumentNotNull(response, nameof(response));
            Ensure.ArgumentNotNull(nextPageFunc, nameof(nextPageFunc));

            _nextPageFunc = nextPageFunc;
            
        }

        public Task<IReadOnlyPagedCollection<T>> GetNextPage()
        {
            throw new NotImplementedException();
        }
    }
}