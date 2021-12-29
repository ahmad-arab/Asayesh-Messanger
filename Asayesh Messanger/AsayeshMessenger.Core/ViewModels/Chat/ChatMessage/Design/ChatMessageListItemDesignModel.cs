using System;

namespace Asayesh_Messanger.Core
{
    public class ChatMessageListItemDesignModel : ChatMessageListItemViewModel
    {
        #region Singelton
        public static ChatMessageListItemDesignModel Instance => new ChatMessageListItemDesignModel();
        #endregion
        #region Constructor
        public ChatMessageListItemDesignModel()
        {
            SenderName = "Luke";
            Message = "No Man, This new app is awesome! I bet it will be fast too";
            Initials = "LS";
            ProfilePictureRGB = "30f9c5";
            SentByMe = true;
            MessageSentTime = DateTimeOffset.UtcNow;
            MessageReadTime = DateTimeOffset.UtcNow.Subtract(TimeSpan.FromDays(1.3));
        }
        #endregion

    }
}
