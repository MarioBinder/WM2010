using System;
using WM2010.Common;
using System.Windows;
using WM2010.Controls;
using System.Windows.Media;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Threading;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using SpieleGrid = WM2010.Controls.Spiel;


namespace WM2010.Frames
{
    public partial class GruppenFrame : UserControl
    {
        readonly WMController _wmController = new WMController();
        public Image TitleImage { get; set; }
        public int SelectedGruppe { get; set; }
        public List<Begegnung> Begegnungen { get; set; }
        BackgroundWorker worker = new BackgroundWorker();

        public GruppenFrame()
        {
            InitializeComponent();
            Loaded += (GruppenFrame_Loaded);
        }

        void GruppenFrame_Loaded(object sender, RoutedEventArgs e)
        {
            worker.DoWork += (WorkerDoWork);
            worker.RunWorkerCompleted += (WorkerRunWorkerCompleted);            
        }

        public void ChangeGruppenFrame(string gruppe)
        {
            Begegnungen = new List<Begegnung>();
            switch (gruppe)
            {
                case "A":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(1));
                    SelectedGruppe = 1;
                    break;

                case "B":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(2));
                    SelectedGruppe = 2;
                    break;

                case "C":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(3));
                    SelectedGruppe = 3;
                    break;

                case "D":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(4));
                    SelectedGruppe = 4;
                    break;

                case "E":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(5));
                    SelectedGruppe = 5;
                    break;

                case "F":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(6));
                    SelectedGruppe = 6;
                    break;

                case "G":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(7));
                    SelectedGruppe = 7;
                    break;

                case "H":
                    Begegnungen.AddRange(_wmController.GetBegegnungen(8));
                    SelectedGruppe = 8;
                    break;

                default:
                    return;

            }
            SetGruppe(gruppe);
        }



        private void SetGruppe(string gruppe)
        {
            gruppenPanel.Children.Clear();

            var image = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/Title_Gruppe{0}.png", gruppe), UriKind.RelativeOrAbsolute)) };
            image.Margin = new Thickness { Bottom = 20 };
            gruppenPanel.Children.Add(image);

            //sortieren
            Begegnungen.Sort((x, y) => DateTime.Compare((DateTime)x.Spiel.DatumUhrzeit, (DateTime)y.Spiel.DatumUhrzeit));

            //spielcontrols bauen
            foreach (var begegnung in Begegnungen)
            {
                var spiel = new SpieleGrid();

                var gridSpiel = spiel.FindName("gridSpiel") as Grid;
                if (gridSpiel != null)
                {
                    gridSpiel.MouseLeftButtonDown += (GridSpielMouseLeftButtonDown);
                    gridSpiel.MouseEnter += (GridSpielMouseEnter);
                    gridSpiel.MouseLeave += (GridSpielMouseLeave);
                    gridSpiel.DataContext = begegnung;
                    gruppenPanel.Children.Add(spiel);
                }
            }
        }
        void GridSpielMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        void GridSpielMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }



        private SpielErgebnis _ergebnis;
        private DialogBase win;
        void GridSpielMouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (sender == null)
                return;

            var spielegrid = (Grid)sender;

            _ergebnis = new SpielErgebnis();
            _ergebnis.OnSpielErgebnisClick += (ErgebnisOnSpielErgebnisClick);
            _ergebnis.Begegnung = (Begegnung)spielegrid.DataContext;

            win = new DialogBase(_ergebnis);
            win.Owner = Application.Current.MainWindow;
            win.Show();
        }

        void ErgebnisOnSpielErgebnisClick(object sender, SpielErgebnis.SpielErgebnisEventArgs e)
        {
            _ergebnis.Message = "Ergebnis wird gespeichert";
            worker.RunWorkerAsync();
        }
        void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _ergebnis.ProgressBarVisibility = Visibility.Visible;
            _wmController.SaveBegegnung(_ergebnis.Begegnung);
        }
        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            win.Close();
        }


        private void Ergebnisuebersicht_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {            
            var gruppenGrid = new GruppenGrid();
            gruppenGrid.Mannschaften.AddRange(_wmController.GetMannschaften(SelectedGruppe));
            win = new DialogBase(gruppenGrid);
            win.Owner = Application.Current.MainWindow;
            win.Show();
        }


        private void Ergebnisuebersicht_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Ergebnisuebersicht_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }

    }
}
