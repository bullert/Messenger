using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Messenger.Themes.Components
{
    public partial class TextBox : UserControl
    {
        public TextBox()
        {
            InitializeComponent();
            Background = new SolidColorBrush(Colors.White);
            Foreground = new SolidColorBrush(Colors.Black);
            CaretBrush = new SolidColorBrush(Colors.LightSkyBlue);
            SelectionBrush = new SolidColorBrush(Colors.DodgerBlue);
            SelectionOpacity = .4;
        }

        #region TextBox Properties

        public double Offset
        {
            get => (double)GetValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public SolidColorBrush CaretBrush
        {
            get => (SolidColorBrush)GetValue(CaretBrushProperty);
            set => SetValue(CaretBrushProperty, value);
        }

        public SolidColorBrush SelectionBrush
        {
            get => (SolidColorBrush)GetValue(SelectionBrushProperty);
            set => SetValue(SelectionBrushProperty, value);
        }

        public double SelectionOpacity
        {
            get => (double)GetValue(SelectionOpacityProperty);
            set => SetValue(SelectionOpacityProperty, value);
        }

        #endregion

        #region TextBox Dependency Properties

        //public static readonly DependencyProperty OffsetProperty =
        //    DependencyProperty.RegisterAttached(
        //        "Offset", typeof(double), typeof(TextBox), new PropertyMetadata(default(double), new PropertyChangedCallback(OffsetPropertyChanged))
        //    );

        public static readonly DependencyProperty OffsetProperty =
        DependencyProperty.RegisterAttached(
            "Offset", typeof(double), typeof(TextBox), new PropertyMetadata(default(double))
        );

        private static void OffsetPropertyChanged(DependencyObject s, DependencyPropertyChangedEventArgs e)
        {

        }

        public static readonly DependencyProperty TextProperty =
            DependencyProperty.RegisterAttached(
                "Text", typeof(string), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty CaretBrushProperty =
            DependencyProperty.RegisterAttached(
                "CaretBrush", typeof(SolidColorBrush), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty SelectionBrushProperty =
            DependencyProperty.RegisterAttached(
                "SelectionBrush", typeof(SolidColorBrush), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty SelectionOpacityProperty =
            DependencyProperty.RegisterAttached(
                "SelectionOpacity", typeof(double), typeof(TextBox), new PropertyMetadata()
            );

        #endregion

        #region Underline Properties

        public SolidColorBrush UnderlineBrush
        {
            get => (SolidColorBrush)GetValue(UnderlineBrushProperty);
            set => SetValue(UnderlineBrushProperty, value);
        }

        public SolidColorBrush UnderlineHighlightBrush
        {
            get => (SolidColorBrush)GetValue(UnderlineHighlightBrushProperty);
            set => SetValue(UnderlineHighlightBrushProperty, value);
        }

        public SolidColorBrush UnderlineFocusBrush
        {
            get => (SolidColorBrush)GetValue(UnderlineFocusBrushProperty);
            set => SetValue(UnderlineFocusBrushProperty, value);
        }

        public Duration UnderlineResizeDuration
        {
            get => (Duration)GetValue(UnderlineResizeDurationProperty);
            set => SetValue(UnderlineResizeDurationProperty, value);
        }

        public Duration UnderlineHighlightDuration
        {
            get => (Duration)GetValue(UnderlineHighlightDurationProperty);
            set => SetValue(UnderlineHighlightDurationProperty, value);
        }

        #endregion

        #region Underline Dependency Properties
        
        public static readonly DependencyProperty UnderlineBrushProperty =
            DependencyProperty.RegisterAttached(
                "UnderlineBrush", typeof(SolidColorBrush), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty UnderlineHighlightBrushProperty =
            DependencyProperty.RegisterAttached(
                "UnderlineHighlightBrush", typeof(SolidColorBrush), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty UnderlineFocusBrushProperty =
            DependencyProperty.RegisterAttached(
                "UnderlineFocusBrush", typeof(SolidColorBrush), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty UnderlineResizeDurationProperty =
            DependencyProperty.RegisterAttached(
                "UnderlineResizeDuration", typeof(Duration), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty UnderlineHighlightDurationProperty =
            DependencyProperty.RegisterAttached(
                "UnderlineHighlightDuration", typeof(Duration), typeof(TextBox), new PropertyMetadata()
            );

        #endregion

        #region Hint Properties 

        public string Hint
        {
            get => (string)GetValue(HintProperty);
            set => SetValue(HintProperty, value);
        }

        public bool ShowHint
        {
            get => (bool)GetValue(ShowHintProperty);
            set => SetValue(ShowHintProperty, value);
        }

        #endregion

        #region Hint Dependency Properties

        public static readonly DependencyProperty HintProperty =
            DependencyProperty.RegisterAttached(
                "Hint", typeof(string), typeof(TextBox), new PropertyMetadata()
            );

        public static readonly DependencyProperty ShowHintProperty =
            DependencyProperty.RegisterAttached(
                "ShowHint", typeof(bool), typeof(TextBox), new PropertyMetadata()
            );
        
        #endregion

        #region Events

        //public bool ShowHint = false;

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            ShowHint = true;
            //Text = ShowHint.ToString();
        }

        private void TextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            //ShowHint = false;
            if (Text.Length == 0) ShowHint = false;
            //Text = ShowHint.ToString();
            //if (Text.Length == 0) Hint = "afasfs";
            //MessageBox.Show(ShowHint.ToString());
        }

        #endregion
    }
}
