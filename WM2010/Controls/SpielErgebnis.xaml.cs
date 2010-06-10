using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WM2010Management;
using System.ComponentModel;
using WM2010.Common;

namespace WM2010.Controls
{
    /// <summary>
    /// Interaktionslogik für SpielErgebnis.xaml
    /// </summary>
    public partial class SpielErgebnis : UserControl, INotifyPropertyChanged
    {
        #region ViewModelProperty: Begegnung
        private Begegnung _begegnung;
        public Begegnung Begegnung
        {
            get
            {
                return _begegnung;
            }

            set
            {
                _begegnung = value;
                OnPropertyChanged("Begegnung");
            }
        }
        #endregion

        #region ViewModelProperty: Message
        private String _message;
        public String Message
        {
            get
            {
                return _message;
            }

            set
            {
                _message = value;
                OnPropertyChanged("Message");
            }
        }
        #endregion

        #region ViewModelProperty: ProgressBarVisibility
        private Visibility _progressBarVisibility;
        public Visibility ProgressBarVisibility
        {
            get
            {
                return _progressBarVisibility;
            }

            set
            {
                _progressBarVisibility = value;
                OnPropertyChanged("ProgressBarVisibility");
            }
        }
        #endregion

        public SpielErgebnis()
        {
            InitializeComponent();
            Loaded += (SpielErgebnis_Loaded);

            Begegnung = new Begegnung();
            Message = String.Empty;
            ProgressBarVisibility = Visibility.Collapsed;
        }

        void SpielErgebnis_Loaded(object sender, RoutedEventArgs e)
        {
            gridErgebnis.DataContext = this;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Event ausloesen
            if (OnSpielErgebnisClick != null)
                OnSpielErgebnisClick(this, new SpielErgebnisEventArgs(""));           
        }


        public delegate void SpielErgebnisClick(object sender, SpielErgebnisEventArgs e);
        public event SpielErgebnisClick OnSpielErgebnisClick;


        public class SpielErgebnisEventArgs : EventArgs
        {
            public readonly string Result;
            public SpielErgebnisEventArgs(string result)
            {
                this.Result = result;
            }
        }

        private void Button_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Cursor = Cursors.Arrow;

        }

        private void Button_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            this.Cursor = Cursors.Hand;
        }



        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

    }
}
