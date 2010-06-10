using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Diagnostics;

namespace WM2010.Pages
{
    /// <summary>
    /// Interaktionslogik für About.xaml
    /// </summary>
    public partial class About : UserControl
    {
        public About()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            var hyperlink = (Hyperlink)sender;
            if (hyperlink == null)
                return;
            Process.Start(hyperlink.NavigateUri.ToString());
        }
    }
}
