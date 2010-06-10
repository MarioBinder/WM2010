using System;
using System.Linq;
using System.Windows;
using Microsoft.Windows.Controls;
using WM2010Management;
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.Generic;
using WM2010.Common;
using System.Windows.Media.Imaging;

namespace WM2010.Controls
{
    public partial class GruppenGrid : UserControl
    {
        public List<Mannschaft> Mannschaften { get; set; }

        public GruppenGrid()
        {
            InitializeComponent();
            Mannschaften = new List<Mannschaft>();

            Loaded += new RoutedEventHandler(GruppenGrid_Loaded);
        }

        void GruppenGrid_Loaded(object sender, RoutedEventArgs e)
        {
            //Reihenfolge bestimmen
            Mannschaften = WMController.SortMannschaften(Mannschaften);

            for (int i = 0; i < Mannschaften.Count; i++)
            {
                var rang = new Label();
                rang.Content = i + 1;


                var landPanel = new StackPanel();
                landPanel.Orientation = Orientation.Horizontal;


                var land = new Label();
                land.Content = Mannschaften[i].Land;
                land.Margin = new Thickness(5, 0, 0, 0);

                var image = new Image { Width = 16, Height = 16, Source = new BitmapImage(new Uri(Helper.GetImagePath(Mannschaften[i].Fahne), UriKind.RelativeOrAbsolute)) };
                
                landPanel.Children.Add(image);
                landPanel.Children.Add(land);
                

                var tore = new Label();
                tore.Content = String.Format("{0} : {1}", Mannschaften[i].Tore, Mannschaften[i].GegenTore);

                var punkte = new Label();
                punkte.Content = Mannschaften[i].Punkte;


                gruppenUebersicht.Children.Add(rang);
                gruppenUebersicht.Children.Add(landPanel);
                gruppenUebersicht.Children.Add(tore);
                gruppenUebersicht.Children.Add(punkte);


                Grid.SetRow(rang, i + 2);
                Grid.SetRow(landPanel, i + 2);
                Grid.SetRow(tore, i + 2);
                Grid.SetRow(punkte, i + 2);

                Grid.SetColumn(rang, 0);
                Grid.SetColumn(landPanel, 1);
                Grid.SetColumn(tore, 2);
                Grid.SetColumn(punkte, 3);
            }
        }        
    }
}
