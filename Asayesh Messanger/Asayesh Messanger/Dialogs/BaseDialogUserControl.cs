using AsayeshMessenger.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace AsayeshMessenger
{
    public class BaseDialogUserControl : UserControl
    {
        #region Private Members
        private DialogWindow mDialogWindow;
        #endregion

        #region Public Commands
        public ICommand CloseCommand { get; private set; }
        #endregion

        #region Public Properties
        public int WindowMinimumWidth { get; set; } = 250;
        public int WindowMinimumHeight { get; set; } = 100;
        public int TitleHeight { get; set; } = 30;

        public string Title { get; set; }
        #endregion

        #region Constructor
        public BaseDialogUserControl()
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                // Create a new dialog window
                mDialogWindow = new DialogWindow();
                mDialogWindow.ViewModel = new DialogWindowViewModel(mDialogWindow);

                // Create close command
                CloseCommand = new RelayCommand(() => mDialogWindow.Close());
            }
        }
        #endregion

        #region fadfasf
        public Task ShowDialog<T>(T viewModel)
            where T: BaseDialogViewModel
        {
            var tsc = new TaskCompletionSource<bool>();

            Application.Current.Dispatcher.Invoke(() =>
            {
                try
                {
                    mDialogWindow.ViewModel.WindowMinWidth = this.WindowMinimumWidth;
                    mDialogWindow.ViewModel.WindowMinHeight = this.WindowMinimumHeight;
                    mDialogWindow.ViewModel.TitleHeight = this.TitleHeight;
                    mDialogWindow.ViewModel.Title = string.IsNullOrEmpty(viewModel.Title)? Title:viewModel.Title ;

                    mDialogWindow.ViewModel.Content = this;

                    DataContext = viewModel;

                    mDialogWindow.ShowDialog();
                }
                finally
                {
                    tsc.SetResult(true);
                }
            });

            return tsc.Task;
        }
        #endregion
    }
}
