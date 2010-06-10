using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WM2010.Pages
{
    /// <summary>
    /// Interaktionslogik für GruppenPhase.xaml
    /// TODO Alle Button deaktivieren
    /// </summary>
    public partial class GruppenPhase : UserControl
    {
        private string _clickedButton = String.Empty;

        public GruppenPhase()
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

            var gp = (GruppenPhase)sender;
            var btn = gp.FindName("ButtonGruppe" + e.Parameter.ToString()) as Button;

            if (btn != null)
            {
                btn.Content = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/{0}_hover.png", btn.Name), UriKind.RelativeOrAbsolute)) };
                _clickedButton = btn.Name;

            }

            DeaktivateAllButtons();

            if (OnGruppenClick != null) 
                OnGruppenClick(this, new GruppenEventArgs(e.Parameter.ToString()));
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
        /// GruppenClickEvent
        /// </summary>
        /// <param name="e"></param>
        public delegate void GruppenClick(object sender, GruppenEventArgs e);
        public event GruppenClick OnGruppenClick;

        public class GruppenEventArgs : EventArgs
        {
            public readonly string Result;
            public GruppenEventArgs(string result)
            {
                this.Result = result;
            }
        }
    }
}
