
namespace AsayeshMessenger.Core
{
    public class SettingsDesignModel : SettingsViewModel
    {
        #region Singelton
        public static SettingsDesignModel Instance => new SettingsDesignModel();
        #endregion
        #region Constructor
        public SettingsDesignModel()
        {
            Name = new TextEntryViewModel { Label = "Name", OriginalText = "Ahmad Arab" };
            Username = new TextEntryViewModel { Label = "Username", OriginalText = "Ahmad" };
            Password = new TextEntryViewModel { Label = "Password", OriginalText = "*******" };
            Email = new TextEntryViewModel { Label = "Email", OriginalText = "ahmadarab45521@gmail.com" };
        }
        #endregion
    }
}
