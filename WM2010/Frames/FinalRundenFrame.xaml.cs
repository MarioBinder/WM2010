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
using WM2010Management;
using WM2010.Controls;
using SpieleGrid = WM2010.Controls.Spiel;
using Spiel = WM2010Management.Spiel;
using WM2010.Common;
using System.ComponentModel;

namespace WM2010.Frames
{
    /// <summary>
    /// Interaktionslogik für FinalRundenFrame.xaml
    /// </summary>
    public partial class FinalRundenFrame : UserControl
    {
        WMController _wmController = new WMController();
        List<Spiel> spiele;
        BackgroundWorker worker = new BackgroundWorker();

        public FinalRundenFrame()
        {
            InitializeComponent();
            Loaded += new RoutedEventHandler(FinalRundenFrame_Loaded);
        }

        void FinalRundenFrame_Loaded(object sender, RoutedEventArgs e)
        {
            worker.DoWork += (WorkerDoWork);
            worker.RunWorkerCompleted += (WorkerRunWorkerCompleted);
        }

        public void ChangeGruppenFrame(string finalrunde)
        {
            spiele = new List<Spiel>();

            switch (finalrunde)
            {
                case "A":
                    spiele.AddRange(_wmController.GetFinalrundenSpiele(new DateTime(2010, 06, 26), new DateTime(2010, 06, 29)));
                    break;

                case "V":
                    spiele.AddRange(_wmController.GetFinalrundenSpiele(new DateTime(2010, 07, 02), new DateTime(2010, 07, 03)));
                    break;

                case "H":
                    spiele.AddRange(_wmController.GetFinalrundenSpiele(new DateTime(2010, 07, 06), new DateTime(2010, 07, 07)));
                    break;

                case "F":
                    spiele.AddRange(_wmController.GetFinalrundenSpiele(new DateTime(2010, 07, 10), new DateTime(2010, 07, 11)));
                    break;

                default:
                    return;
            }

            SetFinalrunde(finalrunde);

        }

        private void SetFinalrunde(string finalrunde)
        {
            finalRundenPanel.Children.Clear();

            var image = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/FinalRunde{0}.png", finalrunde), UriKind.RelativeOrAbsolute)) };
            image.Margin = new Thickness { Bottom = 20 };
            finalRundenPanel.Children.Add(image);

            //reihenfolge sortieren
            spiele.Sort((x, y) => DateTime.Compare((DateTime)x.DatumUhrzeit, (DateTime)y.DatumUhrzeit));

            foreach (var spiel in spiele)
            {
                Begegnung begegnung = new Begegnung();
                begegnung.Spiel = spiel;

                if (spiel.Mannschaft1Id.HasValue && spiel.Mannschaft2Id.HasValue)
                {

                    var m1 = _wmController.GetMannschaft(spiel.Mannschaft1Id.Value);
                    var m2 = _wmController.GetMannschaft(spiel.Mannschaft2Id.Value);

                    begegnung.Mannschaft1Name = m1.Land;
                    begegnung.Mannschaft1Fahne = m1.Fahne;

                    begegnung.Mannschaft2Name = m2.Land;
                    begegnung.Mannschaft2Fahne = m2.Fahne;
                }
                else
                {

                    switch (spiel.DatumUhrzeit.Value.Ticks)
                    {
                        //achtelfinale
                        case 634131648000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe A";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe B";
                            break;
                        case 634131810000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe C";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe D";
                            break;
                        case 634132512000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe D";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe C";
                            break;
                        case 634132674000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe B";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe A";
                            break;
                        case 634133376000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe E";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe F";
                            break;
                        case 634133538000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe G";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe H";
                            break;
                        case 634134240000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe F";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe E";
                            break;
                        case 634134402000000000:
                            begegnung.Mannschaft1Name = "Sieger Gruppe H";
                            begegnung.Mannschaft2Name = "Zweiter Gruppe G";
                            break;


                        //viertelfinale
                        case 634136832000000000:
                            begegnung.Mannschaft1Name = "Sieger Achtelfinale 1";
                            begegnung.Mannschaft2Name = "Sieger Achtelfinale 2";
                            break;

                        case 634136994000000000:
                            begegnung.Mannschaft1Name = "Sieger Achtelfinale 5";
                            begegnung.Mannschaft2Name = "Sieger Achtelfinale 6";
                            break;

                        case 634137696000000000:
                            begegnung.Mannschaft1Name = "Sieger Achtelfinale 3";
                            begegnung.Mannschaft2Name = "Sieger Achtelfinale 4";
                            break;

                        case 634137858000000000:
                            begegnung.Mannschaft1Name = "Sieger Achtelfinale 7";
                            begegnung.Mannschaft2Name = "Sieger Achtelfinale 8";
                            break;


                        //halbfinale
                        case 634140450000000000:
                            begegnung.Mannschaft1Name = "Sieger Viertelfinale 1";
                            begegnung.Mannschaft2Name = "Sieger Viertelfinale 2";
                            break;

                        case 634141314000000000:
                            begegnung.Mannschaft1Name = "Sieger Viertelfinale 3";
                            begegnung.Mannschaft2Name = "Sieger Viertelfinale 4";
                            break;


                        //platz3
                        case 634143906000000000:
                            begegnung.Mannschaft1Name = "Verlierer Halbfinale 1";
                            begegnung.Mannschaft2Name = "Verlierer Halbfinale 2";
                            break;


                        //finale
                        case 634144770000000000:
                            begegnung.Mannschaft1Name = "Sieger Halbfinale 1";
                            begegnung.Mannschaft2Name = "Sieger Halbfinale 2";
                            break;

                        default:
                            break;
                    }

                }

                var game = new SpieleGrid();

                var gridSpiel = game.FindName("gridSpiel") as Grid;
                if (gridSpiel != null)
                {
                    if (spiel.Mannschaft1Id.HasValue && spiel.Mannschaft2Id.HasValue)
                    {
                        gridSpiel.MouseLeftButtonDown += (GridSpielMouseLeftButtonDown);
                        gridSpiel.MouseEnter += (GridSpielMouseEnter);
                        gridSpiel.MouseLeave += (GridSpielMouseLeave);
                    }

                    gridSpiel.DataContext = begegnung;

                    //im Finale zusaetzlich bilder einbauen
                    if (begegnung.Spiel.DatumUhrzeit.Value.Ticks == 634143906000000000)
                    {
                        var dritterPlatzImage = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/Spiel.um.Platz.3.png"), UriKind.RelativeOrAbsolute)) };
                        dritterPlatzImage.Margin = new Thickness (0,15,0,15);
                        finalRundenPanel.Children.Add(dritterPlatzImage);
                    }

                    if (begegnung.Spiel.DatumUhrzeit.Value.Ticks == 634144770000000000)
                    {

                        var finalImage = new Image { Stretch = Stretch.None, Source = new BitmapImage(new Uri(String.Format("../Style/Images/Finale.png"), UriKind.RelativeOrAbsolute)) };
                        finalImage.Margin = new Thickness (0,15,0,15);
                        finalRundenPanel.Children.Add(finalImage);

                    }


                    finalRundenPanel.Children.Add(game);
                }

            }

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

        void GridSpielMouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        void GridSpielMouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        void ErgebnisOnSpielErgebnisClick(object sender, SpielErgebnis.SpielErgebnisEventArgs e)
        {
            _ergebnis.Message = "Ergebnis wird gespeichert";
            worker.RunWorkerAsync();
        }
        void WorkerDoWork(object sender, DoWorkEventArgs e)
        {
            _ergebnis.ProgressBarVisibility = Visibility.Visible;
            _wmController.SaveAndSetFinalrunden(_ergebnis.Begegnung);

        }
        void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            win.Close();
        }

    }
}

