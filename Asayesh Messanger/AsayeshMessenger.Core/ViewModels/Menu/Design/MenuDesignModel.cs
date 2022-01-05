using System.Collections.Generic;

namespace AsayeshMessenger.Core
{
    public class MenuDesignModel:MenuViewModel
    {
        public static MenuDesignModel Instance => new MenuDesignModel();

        public MenuDesignModel()
        {
            Items = new List<MenuItemViewModel>
            {
                new MenuItemViewModel{ Text= "The Header", Icon = IconType.File, Type = MenuItemType.Header},
                new MenuItemViewModel{ Text= "The First Item", Icon = IconType.File},
                new MenuItemViewModel{Text = "The Item Before Devider", Icon = IconType.Picture},
                new MenuItemViewModel{Text = "The devider It Self", Type = MenuItemType.Divider},
                new MenuItemViewModel{Text = "The Next To Last Item",Icon = IconType.File},
                new MenuItemViewModel{Text = "The Last Item", Icon = IconType.File},
            };
        }
    }
}
