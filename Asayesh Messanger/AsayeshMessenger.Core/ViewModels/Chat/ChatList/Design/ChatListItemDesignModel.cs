

namespace AsayeshMessenger.Core
{
    public class ChatListItemDesignModel: ChatListItemViewModel
    {
        #region Singelton
        public static ChatListItemDesignModel Instance =>new ChatListItemDesignModel();
        #endregion
        #region Constructor
        public ChatListItemDesignModel()
        {
            Name = "Luke";
            Message = "This new app is awesome! I bet it will be fast too";
            Initials = "LM";
            ProfilePictureRGB = "3099c5";
            NewContentAvailable = true;
        }
        #endregion

    }
}
