

using Asayesh_Messanger.Core;

namespace Asayesh_Messanger.Core
{
    public class ApplicationViewModel: BaseViewModel
    {
        public ApplicationPage CurrentPage { get; set; } = ApplicationPage.Login;
    }
}
