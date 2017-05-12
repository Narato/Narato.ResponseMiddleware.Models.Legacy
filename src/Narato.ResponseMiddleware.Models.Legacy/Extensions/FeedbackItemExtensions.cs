using Narato.ResponseMiddleware.Models.Legacy.Models;
using Narato.ResponseMiddleware.Models.Models;
using System.Collections;
using System.Collections.Generic;

namespace Narato.ResponseMiddleware.Models.Legacy.Extensions
{
    public static class FeedbackItemExtensions
    {
        /// <summary>
        /// Converts a string to the legacy FeedbackItem
        /// </summary>
        /// <param name="str">The string to convert</param>
        /// <param name="type">the type of the feedbackitem</param>
        /// <returns>a feedbackItem</returns>
        public static FeedbackItem ToFeedbackItem(this string str, FeedbackType type)
        {
            return new FeedbackItem()
            {
                Description = str,
                Type = type
            };
        }

        /// <summary>
        /// Converts a ModelValidationDictionary to the legacy FeedbackItem system
        /// Note that the fields get ignored (as to be backwards compatible)
        /// Put the fieldname in the messages themselves
        /// </summary>
        /// <typeparam name="T">The type of the messages</typeparam>
        /// <param name="modelValidationDictionary">the dictionary to convert</param>
        /// <returns>the converted list of feedbackItems</returns>
        public static IEnumerable<FeedbackItem> ToFeedbackItems<T>(this ModelValidationDictionary<T> modelValidationDictionary)
        {
            var feedbackList = new List<FeedbackItem>();
            foreach (var messageList in modelValidationDictionary)
            {
                foreach (var message in messageList.Value)
                {
                    feedbackList.Add(FeedbackItem.CreateValidationErrorFeedbackItem(message.ToString()));
                }
            }
            return feedbackList;
        }
    }
}
