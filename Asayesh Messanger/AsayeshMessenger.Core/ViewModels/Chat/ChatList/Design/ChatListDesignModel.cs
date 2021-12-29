

using System.Collections.Generic;

namespace Asayesh_Messanger.Core
{
    public class ChatListDesignModel:ChatListViewModel
    {
        #region Singelton
        public static ChatListDesignModel Instance => new ChatListDesignModel();
        #endregion
        #region Constructor
        public ChatListDesignModel()
        {
            Items = new List<ChatListItemViewModel>
            {
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Message = "This new app is awesome! I bet it will be fast too",
                    Initials = "LM",
                    ProfilePictureRGB = "3099c5"
                },
                new ChatListItemViewModel
                {
                    Name = "Ahmad Arab",
                    Message = "Hey Man!",
                    Initials = "AA",
                    ProfilePictureRGB = "2d650a",
                    NewContentAvailable =true
                },
                new ChatListItemViewModel
                {
                    Name = "أحمد عرب",
                    Message = "يوااال اليوم شفتك بالسوق",
                    Initials = "BN",
                    ProfilePictureRGB = "902277",
                    IsSelected=true
                },
                new ChatListItemViewModel
                {
                    Name = "Omar",
                    Message = "LOL<.>",
                    Initials = "OA",
                    ProfilePictureRGB = "eeeeee",
                    NewContentAvailable =true
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Message = "This new app is awesome! I bet it will be fast too",
                    Initials = "LM",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable =true
                },
                new ChatListItemViewModel
                {
                    Name = "Ahmad Arab",
                    Message = "Hey Man!",
                    Initials = "AA",
                    ProfilePictureRGB = "2d650a"
                },
                new ChatListItemViewModel
                {
                    Name = "Bongin",
                    Message = "What the hell happened to abou sepan?",
                    Initials = "BN",
                    ProfilePictureRGB = "902277"
                },
                new ChatListItemViewModel
                {
                    Name = "Omar",
                    Message = "LOL<.>",
                    Initials = "OA",
                    ProfilePictureRGB = "eeeeee"
                },
                new ChatListItemViewModel
                {
                    Name = "Luke",
                    Message = "This new app is awesome! I bet it will be fast too",
                    Initials = "LM",
                    ProfilePictureRGB = "3099c5",
                    NewContentAvailable =true
                },
                new ChatListItemViewModel
                {
                    Name = "Ahmad Arab",
                    Message = "Hey Man! You are fucked up",
                    Initials = "AA",
                    ProfilePictureRGB = "2d650a"
                },
                new ChatListItemViewModel
                {
                    Name = "Bongin",
                    Message = "What the hell happened to abou sepan?",
                    Initials = "BN",
                    ProfilePictureRGB = "902277",
                    NewContentAvailable =true
                },
                new ChatListItemViewModel
                {
                    Name = "Omar",
                    Message = "LOL<.>",
                    Initials = "OA",
                    ProfilePictureRGB = "eeeeee",
                    NewContentAvailable =true
                },
            };
        }
        #endregion
    }
}
