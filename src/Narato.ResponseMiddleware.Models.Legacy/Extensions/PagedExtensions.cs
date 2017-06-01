using Narato.ResponseMiddleware.Models.Legacy.Models;
using Narato.ResponseMiddleware.Models.Models;
using System.Collections.Generic;

namespace Narato.ResponseMiddleware.Models.Legacy.Extensions
{
    public static class PagedExtensions
    {
        public static Paged<T> ToPaged<T>(this Response<IEnumerable<T>> response)
        {
            // pagesize 1 is a little trick here, we just need to make sure skip will be set correctly in the end result.
            // We don't want to create setters just for this in Paged
            return new Paged<T>(response.Data, response.Skip + 1, 1, response.Total);
        }
    }
}
