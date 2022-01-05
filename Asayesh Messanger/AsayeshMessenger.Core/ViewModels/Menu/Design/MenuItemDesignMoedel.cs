using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{
    public class MenuItemDesignMoedel: MenuItemViewModel
    {
        public static MenuItemDesignMoedel Instance => new MenuItemDesignMoedel();
        #region Constructor
        public MenuItemDesignMoedel()
        {
            this.Text = "Hello World";
            this.Icon = IconType.File;
        }
        #endregion
    }
}
