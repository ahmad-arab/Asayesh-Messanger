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

            MessageText.Focus();
        }
        #endregion

        private void MessageText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textbox = sender as TextBox;

            if(e.Key == Key.Enter)
            {
                if (Keyboard.Modifiers.HasFlag(ModifierKeys.Control))
                {
                    var index = textbox.CaretIndex;

                    textbox.Text = textbox.Text.Insert(index, Environment.NewLine);

                    textbox.CaretIndex = index + Environment.NewLine.Length;
                }
                else
                    ViewModel.Send();
                
            
                e.Handled = true;
            }
        }

        private void MessageText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
