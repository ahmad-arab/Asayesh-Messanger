
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    public class ChatListItemViewModel: BaseViewModel
    {
        #region public properties
        public string Name { get; set; }
        public string Message { get; set; }
        public string Initials { get; set; }
        public string ProfilePictureRGB { get; set; }
        public bool NewContentAvailable { get; set; }
        public bool IsSelected { get; set; }
        #endregion

        #region Public Commands
        public ICommand OpenMessageCommand { get; set; }
        #endregion

        #region Constructor
        public ChatListItemViewModel()
        {
            OpenMessageCommand = new RelayCommand(OpenMessage);
        }
        #endregion

        #region Command methods
        public void OpenMessage()
        {
            IoC.Application.GoToPage(ApplicationPage.Chat, new ChatMessageListViewModel 
            { 
                 Items= new List<ChatMessageListItemViewModel>
                 {
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =false
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =false
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =true
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =true
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =false
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =true
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =false
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =true
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =false
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =true
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =true
                      },
                      new ChatMessageListItemViewModel
                      {
                           Initials = Initials,
                            IsSelected = false,
                             Message = Message+ new Random().Next(0,100000000).ToString(),
                              MessageReadTime = DateTime.Now,
                               MessageSentTime = DateTime.Now.AddMinutes(-10),
                                ProfilePictureRGB = ProfilePictureRGB,
                                 SenderName = Name,
                                  SentByMe =true
                      },
                 }
            });
        }
        #endregion
    }
}
