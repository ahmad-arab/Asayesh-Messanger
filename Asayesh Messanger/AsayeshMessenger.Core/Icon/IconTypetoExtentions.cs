using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsayeshMessenger.Core
{
    public static class IconTypetoExtentions
    {
        public static string ToFontAwesome(this IconType type)
        {
            switch (type)
            {
                case IconType.None:
                    return null;
                case IconType.Picture:
                    return "\uf1c5;";
                case IconType.File:
                    return "\uf15c;";
                default:
                    return null;
            }
        }
    }
}
