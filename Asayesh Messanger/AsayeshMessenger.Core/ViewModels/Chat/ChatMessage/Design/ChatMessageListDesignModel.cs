

using System;
using System.Collections.Generic;

namespace Asayesh_Messanger.Core
{
    public class ChatMessageListDesignModel : ChatMessageListViewModel
    {
        #region Singelton
        public static ChatMessageListDesignModel Instance => new ChatMessageListDesignModel();
        #endregion
        #region Constructor
        public ChatMessageListDesignModel()
        {
            Items = new List<ChatMessageListItemViewModel>
            {
                new ChatMessageListItemViewModel
                {

                    SenderName = "أحمد عرب",
                    Message = "This new app is awesome! I bet it will be fast too",
                    Initials = "AA",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                    MessageReadTime = DateTimeOffset.UtcNow.AddDays(3)
                },
                new ChatMessageListItemViewModel
                {

                    SenderName = "Omar",
                    Message = "Nop... I will stick with the old app",
                    Initials = "OH",
                    ProfilePictureRGB = "b09ac5",
                    MessageSentTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3)),
                    SentByMe = true,
                    MessageReadTime = DateTimeOffset.UtcNow.AddDays(3)
                },
                new ChatMessageListItemViewModel
                {

                    SenderName = "أحمد عرب",
                    Message = "له يا زلمة على أساس وعدتني!",
                    Initials = "AA",
                    ProfilePictureRGB = "3099c5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = false,
                    MessageReadTime = DateTimeOffset.UtcNow.AddHours(3)
                },
                new ChatMessageListItemViewModel
                {

                    SenderName = "Omar",
                    Message = "رح أحاول هالمرة بس مشانك",
                    Initials = "OH",
                    ProfilePictureRGB = "b09ac5",
                    MessageSentTime = DateTimeOffset.UtcNow,
                    SentByMe = true,
                    MessageReadTime = DateTimeOffset.MinValue,
                },
            };
        }
        #endregion
    }
}
