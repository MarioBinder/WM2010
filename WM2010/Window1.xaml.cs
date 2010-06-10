using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using WM2010.Pages;
using WM2010.Frames;
using System.Windows.Threading;

namespace WM2010
{
    public partial class Window1 : Window
    {
        private readonly GruppenPhase _gruppenPhase = new GruppenPhase();
        private readonly FinaleRunden _finaleRunden = new FinaleRunden();
        private readonly GruppenFrame _gruppenFrame = new GruppenFrame();
        private readonly FinalRundenFrame _finalrundenFrame = new FinalRundenFrame();

        public Window1()
        {
            InitializeComponent();
            Loaded += (Window1_Loaded);
            _gruppenPhase.OnGruppenClick += (GruppenPhaseOnGruppenClick);
            _finaleRunden.OnFinalrundenClick += (FinaleRundenOnFinalrundenClick);
        }
        
        void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            //adding pages
            Pages.Items.Add(_gruppenPhase);
            Pages.Items.Add(_finaleRunden);
            Pages.Items.Add(new About());

            //adding frames
            Frames.Items.Add(new Startseite());
            Frames.Items.Add(_gruppenFrame);
            Frames.Items.Add(_finalrundenFrame);


            //timer
            DispatcherTimer timer = new DispatcherTimer();
            timer.Tick += (TimerTick);
            timer.Start();
        }
        
        #region Events
        void TimerTick(object sender, EventArgs e)
        {
            lblDatum.Content = String.Format("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());
        }

        void GruppenPhaseOnGruppenClick(object o, GruppenPhase.GruppenEventArgs e)
        {
            Frames.SelectedIndex = Frames.SelectedIndex < Frames.Items.Count ? 1 : 0;
            _gruppenFrame.ChangeGruppenFrame(e.Result);
        }

        void FinaleRundenOnFinalrundenClick(object sender, FinaleRunden.FinalrundenClickEventArgs e)
        {
            Frames.SelectedIndex = Frames.SelectedIndex < Frames.Items.Count ? 2 : 0;
            _finalrundenFrame.ChangeGruppenFrame(e.Result);
        }
        #endregion

        #region WindowCloseEffect
        private void CloseImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Closing += Window_Closing;
            this.Close();
        }
        private bool _closeStoryBoardCompleted = false;

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!_closeStoryBoardCompleted)
            {
                closeStoryBoard.Begin();
                e.Cancel = true;
            }
        }
        private void closeStoryBoard_Completed(object sender, EventArgs e)
        {
            _closeStoryBoardCompleted = true;
            this.Close();
        }

        //minimize
        private void MinimizeImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        //homesite
        private void HomeImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Frames.HasItems)
                Frames.SelectedIndex = 0;
        }
        #endregion

        #region Draggable Window
        /// <summary>
        /// Erlaubt das Verschieben der Applikation per DragMove
        /// </summary>
        public void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        /// <summary>
        /// MouseEnter und MouseLeave für den Close- und den ConfigButton
        /// </summary>
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }
        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region Navigation

        #region LeftNav
        private void LeftButton_MouseEnter(object sender, MouseEventArgs e)
        {
            LeftButton.Content = new Image { Source = new BitmapImage(new Uri("../Style/Images/LeftButton_Hover.png", UriKind.RelativeOrAbsolute)) };
        }
        private void LeftButton_MouseLeave(object sender, MouseEventArgs e)
        {
            LeftButton.Content = new Image { Source = new BitmapImage(new Uri("../Style/Images/LeftButton.png", UriKind.RelativeOrAbsolute)) };
        }
        #endregion

        #region RightNav
        private void RightButton_MouseEnter(object sender, MouseEventArgs e)
        {
            RightButton.Content = new Image { Source = new BitmapImage(new Uri("../Style/Images/RightButton_Hover.png", UriKind.RelativeOrAbsolute)) };
        }
        private void RightButton_MouseLeave(object sender, MouseEventArgs e)
        {
            RightButton.Content = new Image { Source = new BitmapImage(new Uri("../Style/Images/RightButton.png", UriKind.RelativeOrAbsolute)) };
        }
        #endregion

        private bool CanNavigateToNextTab
        {
            get
            {
                if (Pages != null)
                {
                    return Pages.SelectedIndex < Pages.Items.Count - 1;
                }
                return false;
            }
        }

        private bool CanNavigateToPreviousTab
        {
            get
            {
                if (Pages != null)
                {
                    return Pages.SelectedIndex != 0;
                }
                return false;
            }
        }

        private void OnNextPageCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            if (CanNavigateToNextTab)
            {
                Pages.SelectedIndex += 1;
                e.Handled = true;
            }
        }

        private void OnPreviousPageCommandExecute(object sender, ExecutedRoutedEventArgs e)
        {
            if (CanNavigateToPreviousTab)
            {
                Pages.SelectedIndex -= 1;
                e.Handled = true;
            }
        }

        private void CanNextPageCommandExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanNavigateToNextTab;
            e.Handled = true;
        }

        private void CanPreviousPageCommandExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = CanNavigateToPreviousTab;
            e.Handled = true;
        }
        #endregion


    }
}
