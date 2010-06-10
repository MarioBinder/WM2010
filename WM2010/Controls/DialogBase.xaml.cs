using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WM2010.Controls
{
    /// <summary>
    /// Interaktionslogik für ErgebnisDialog.xaml
    /// </summary>
    public partial class DialogBase : Window
    {
        public UserControl DialogControl { get; set; }

        public DialogBase(UserControl dialog)
        {
            InitializeComponent();
            this.MouseDown += (Window_MouseMove);
            DataContext = this;
            DialogControl = dialog;
            Loaded += (DialogBaseWindow_Loaded);
        }
        void DialogBaseWindow_Loaded(object sender, RoutedEventArgs e)
        {
            dialogContent.Content = DialogControl;
        }


        #region Draggable Window

        public void Window_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();
        }
        private void Image_MouseEnter(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }

        private void Image_MouseLeave(object sender, MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;
        }
        #endregion

        #region WindowCloseEffect
        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Closing += (Window_Closing);
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
        #endregion
    }
}