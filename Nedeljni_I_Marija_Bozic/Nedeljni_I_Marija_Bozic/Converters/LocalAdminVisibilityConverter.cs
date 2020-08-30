﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Nedeljni_I_Marija_Bozic.Converters
{
	public class LocalAdminVisibilityConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if ((string)value == "Local")
			{
				return System.Windows.Visibility.Visible;
			}
			return System.Windows.Visibility.Hidden;
		}

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
    }
}
