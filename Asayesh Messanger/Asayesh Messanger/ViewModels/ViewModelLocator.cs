using Asayesh_Messanger.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asayesh_Messanger
{
    public class ViewModelLocator
    {
        public static ViewModelLocator Instance {  get; private set; } = new ViewModelLocator();

        public static ApplicationViewModel ApplicationViewModel => IoC.Get<ApplicationViewModel>();
    }
}
