using System;
using System.Globalization;
using System.Windows.Data;

namespace WebStore.WPF.Infrastructure.Converters
{
    class EqualsMulti : IMultiValueConverter
    {
        public object Convert(object[] vv, Type t, object p, CultureInfo c)
        {
            for (var i = 0; i < vv.Length - 1; i++)
                if (!Equals(vv[i], vv[i + 1]))
                    return false;
            return true;
        }

        public object[] ConvertBack(object v, Type[] tt, object p, CultureInfo c) => throw new NotSupportedException();
    }
}
