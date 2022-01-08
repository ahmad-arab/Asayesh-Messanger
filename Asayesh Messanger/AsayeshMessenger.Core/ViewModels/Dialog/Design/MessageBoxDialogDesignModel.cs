using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{
    public class MessageBoxDialogDesignModel: MessageBoxDialogViewModel
    {
        public static MessageBoxDialogDesignModel Instance => new MessageBoxDialogDesignModel();

        public MessageBoxDialogDesignModel()
        {
            Message = "Hi there! I'm using whatsup";
            Title = "From Tutu";
            OkText = "Alright";
        }
    }
}
