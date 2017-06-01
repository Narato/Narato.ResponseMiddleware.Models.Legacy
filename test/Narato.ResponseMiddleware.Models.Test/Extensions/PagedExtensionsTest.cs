using Narato.ResponseMiddleware.Models.Legacy.Extensions;
using Narato.ResponseMiddleware.Models.Legacy.Models;
using System.Collections.Generic;
using Xunit;

namespace Narato.ResponseMiddleware.Models.Test.Extensions
{
    public class PagedExtensionsTest
    {
        [Fact]
        public void ResponseToPagedTest()
        {
            var dataList = new List<string>() { "first", "second", "third" };
            var response = new Response<IEnumerable<string>>(dataList, "path", 200);
            response.Skip = 501;
            response.Take = 3;
            response.Total = 1850;

            var paged = response.ToPaged();

            Assert.Equal(1850, paged.Total);
            Assert.Equal(3, paged.Take);
            Assert.Equal(501, paged.Skip);
        }
    }
}
