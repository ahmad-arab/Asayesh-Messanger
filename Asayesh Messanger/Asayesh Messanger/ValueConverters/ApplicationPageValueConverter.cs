

using Asayesh_Messanger.Core;
using System;
using System.Diagnostics;
using System.Globalization;

namespace Asayesh_Messanger
{
    public class ApplicationPageValueConverter : BaseValueConverter<ApplicationPageValueConverter>
    {
        public override object Convert(object value, Type targetType= null, object parameter=null, CultureInfo culture=null)
        {
            switch((ApplicationPage) value)
            {
                case ApplicationPage.Login:
                    return new LoginPage();

                case ApplicationPage.Chat:
                    return new ChatPage();

                case ApplicationPage.Register:
                    return new RegisterPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
