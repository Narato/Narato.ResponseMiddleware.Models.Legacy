using Narato.ResponseMiddleware.Models.Legacy.Extensions;
using Narato.ResponseMiddleware.Models.Legacy.Models;
using Narato.ResponseMiddleware.Models.Models;
using System.Linq;
using Xunit;

namespace Narato.ResponseMiddleware.Models.Test.Extensions
{
    public class FeedbackItemExtensionsTest
    {

        [Fact]
        public void StringToFeedbackItemTest()
        {
            var str = "meep";
            var feedbackItem = str.ToFeedbackItem(FeedbackType.Error);
            Assert.Equal(str, feedbackItem.Description);
            Assert.Equal(FeedbackType.Error, feedbackItem.Type);
        }

        [Fact]
        public void ModelValidationDictionaryToFeedbackItemsTest()
        {
            var dict = new ModelValidationDictionary<string>();
            dict.Add("meep", "moop");
            dict.Add("maap", "meup");

            var feedbackItems = dict.ToFeedbackItems();
            Assert.Equal(2, feedbackItems.Count());
            Assert.Equal(FeedbackType.ValidationError, feedbackItems.First().Type);
            Assert.Contains(feedbackItems, (item) => item.Description == "moop");
            Assert.Contains(feedbackItems, (item) => item.Description == "meup");
        }
    }
}
