
using System.Security;
using System.Windows.Input;

namespace AsayeshMessenger.Core
{
    /// <summary>
    /// The view model for a text entry to edit a string value
    /// <summary>
    public class PasswordEntryViewModel : BaseViewModel
    {
        #region Public Properties

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string FakePassword { get; set; }

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string CurrentPasswordHintText { get; set; }

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string NewPasswordHintText { get; set; }

        /// <summary>
        /// The label to identify what this value is for
        /// </summary>
        public string ConfirmPasswordHintText { get; set; }

        /// <summary>
        /// The current saved value
        /// </summary>
        public SecureString CurrentPassword { get; set; }

        /// <summary>
        /// The current non-commit edited text
        /// </summary>
        public SecureString NewPassword { get; set; }

        /// <summary>
        /// The current non-commit edited text
        /// </summary>
        public SecureString ConfirmPassword { get; set; }

        /// <summary>
        /// Indicates if the current text is in edit mode
        /// </summary>
        public bool Editing { get; set; }

        #endregion

        #region Public Commands

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public ICommand EditCommand { get; set; }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public ICommand CancelCommand { get; set; }

        /// <summary>
        /// Commits the edits and saves the value
        /// as well as goes back to non-edit mode
        /// </summary>
        public ICommand SaveCommand { get; set; }

        #endregion

        #region Constructor 

        /// <summary>
        /// Default constructor
        /// </summary>
        public PasswordEntryViewModel()
        {
            // Create commands
            EditCommand = new RelayCommand(Edit);
            CancelCommand = new RelayCommand(Cancel);
            SaveCommand = new RelayCommand(Save);

            CurrentPasswordHintText = "Current Password";
            NewPasswordHintText = "New Password";
            ConfirmPasswordHintText = "Confirm Password";

        }

        #endregion

        #region Command Methods

        /// <summary>
        /// Puts the control into edit mode
        /// </summary>
        public void Edit()
        {
            NewPassword = new SecureString();
            ConfirmPassword = new SecureString();

            // Go into edit mode
            Editing = true;
        }

        /// <summary>
        /// Cancels out of edit mode
        /// </summary>
        public void Cancel()
        {
            Editing = false;
        }

        /// <summary>
        /// Commits the content and exits out of edit mode
        /// </summary>
        public void Save()
        {
            var storedPassword = "Testing";

            if (storedPassword != CurrentPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "Wrong password",
                    Message = "The current password is invalid"
                });
                return;
            }

            if (NewPassword.Unsecure() != ConfirmPassword.Unsecure())
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "password mismatch",
                    Message = "The current and confirmed password do not match"
                });
                return;
            }

            if (string.IsNullOrEmpty(NewPassword.Unsecure()))
            {
                IoC.UI.ShowMessage(new MessageBoxDialogViewModel
                {
                    Title = "password too short",
                    Message = "You must enter the password"
                });
                return;
            }

            // Set the edited text to the current value
            CurrentPassword = new SecureString();
            foreach (var c in NewPassword.Unsecure().ToCharArray())
                CurrentPassword.AppendChar(c);

            Editing = false;
        }

        #endregion
    }
}
