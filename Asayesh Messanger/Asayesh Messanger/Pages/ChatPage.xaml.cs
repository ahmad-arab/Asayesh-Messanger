using AsayeshMessenger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AsayeshMessenger
{
    /// <summary>
    /// Interaction logic for ChatPage.xaml
    /// </summary>
    public partial class ChatPage : BasePage<ChatMessageListViewModel>
    {
        #region Constructor
        public ChatPage() : base()
        {
            InitializeComponent();
        }

        public ChatPage(ChatMessageListViewModel specificViewModel):base(specificViewModel)
        {
            InitializeComponent();
        }
        #endregion

        #region Override methods
        protected override void OnViewModelChanged()
        {
            if (ChatMessageList == null)
                return;

            var storyBoard = new Storyboard();
            storyBoard.AddFadeIn(1);
            storyBoard.Begin(ChatMessageList);
        }
        #endregion
    }
}
