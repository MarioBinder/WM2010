using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WM2010.Pages
{
    /// <summary>
    /// Interaktionslogik für FinaleRunden.xaml
    /// </summary>
    public partial class FinaleRunden : UserControl
    {
        private String _clickedButton = String.Empty;

        public FinaleRunden()
        {
            InitializeComponent();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            if (button == null)
                return;

            if (!_clickedButton.Equals(button.Name))
                button.Content = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/{0}.png", button.Name), UriKind.RelativeOrAbsolute)) };

        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            var button = (Button)sender;
            if (button == null)
                return;

            button.Content = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/{0}_hover.png", button.Name), UriKind.RelativeOrAbsolute)) };
        }


        private void OnGotoPage(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Parameter == null)
                return;

            var gp = (FinaleRunden)sender;
            var btn = gp.FindName("FinalRunden" + e.Parameter.ToString()) as Button;

            if (btn != null)
            {
                btn.Content = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/{0}_hover.png", btn.Name), UriKind.RelativeOrAbsolute)) };
                _clickedButton = btn.Name;

            }

            DeaktivateAllButtons();

            if (OnFinalrundenClick != null) 
                OnFinalrundenClick(this, new FinalrundenClickEventArgs(e.Parameter.ToString()));
        }


        private void DeaktivateAllButtons()
        {
            foreach (var child in buttonPanel.Children)
            {
                if (child is Button)
                {
                    var btn = (Button)child;
                    if (!_clickedButton.Equals(btn.Name))
                    {
                        btn.Content = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/{0}.png", btn.Name), UriKind.RelativeOrAbsolute)) };
                    }
                }

            }
        }

        /// <summary>
        /// FinalrundenClickEvent
        /// </summary>
        /// <param name="e"></param>
        public delegate void FinalrundenClick(object sender, FinalrundenClickEventArgs e);
        public event FinalrundenClick OnFinalrundenClick;

        public class FinalrundenClickEventArgs : EventArgs
        {
            public readonly string Result;
            public FinalrundenClickEventArgs(string result)
            {
                this.Result = result;
            }
        }
    }
}
