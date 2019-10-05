using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Messenger.Themes.Components
{
    public partial class Scale : UserControl
    {
        public double Value
        {
            get => (double)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }

        public static readonly DependencyProperty ValueProperty =
        DependencyProperty.RegisterAttached(
            "Value", typeof(double), typeof(Scale), new PropertyMetadata(default(double))
        );
    }
}
