using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AsayeshMessenger
{
    public class DialogWindowViewModel: WindowViewModel
    {
        #region Public Properties
        public string Title { get; set; }

        public Control Content { get; set; }
        #endregion

        #region Constructor
        public DialogWindowViewModel(Window window): base(window) { }
        #endregion
    }
}
