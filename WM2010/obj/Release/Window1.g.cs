﻿#pragma checksum "..\..\Window1.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E3DFE71927C784C5910B108AD0390329"
//------------------------------------------------------------------------------
// <auto-generated>
//     Dieser Code wurde von einem Tool generiert.
//     Laufzeitversion:4.0.30319.1
//
//     Änderungen an dieser Datei können falsches Verhalten verursachen und gehen verloren, wenn
//     der Code erneut generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace WM2010 {
    
    
    /// <summary>
    /// Window1
    /// </summary>
    public partial class Window1 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 3 "..\..\Window1.xaml"
        internal WM2010.Window1 app;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\Window1.xaml"
        internal System.Windows.Media.Animation.Storyboard closeStoryBoard;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\Window1.xaml"
        internal System.Windows.Controls.Canvas canvas1;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\Window1.xaml"
        internal System.Windows.Controls.Label lblDatum;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\Window1.xaml"
        internal System.Windows.Controls.TabControl Frames;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button LeftButton;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\Window1.xaml"
        internal System.Windows.Controls.Button RightButton;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\Window1.xaml"
        internal System.Windows.Controls.TabControl Pages;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WM2010;component/window1.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window1.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.app = ((WM2010.Window1)(target));
            
            #line 5 "..\..\Window1.xaml"
            this.app.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Window_MouseMove);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 8 "..\..\Window1.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanPreviousPageCommandExecute);
            
            #line default
            #line hidden
            
            #line 8 "..\..\Window1.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OnPreviousPageCommandExecute);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 9 "..\..\Window1.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.CanNextPageCommandExecute);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Window1.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OnNextPageCommandExecute);
            
            #line default
            #line hidden
            return;
            case 4:
            this.closeStoryBoard = ((System.Windows.Media.Animation.Storyboard)(target));
            
            #line 25 "..\..\Window1.xaml"
            this.closeStoryBoard.Completed += new System.EventHandler(this.closeStoryBoard_Completed);
            
            #line default
            #line hidden
            return;
            case 5:
            this.canvas1 = ((System.Windows.Controls.Canvas)(target));
            return;
            case 6:
            this.lblDatum = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.Frames = ((System.Windows.Controls.TabControl)(target));
            return;
            case 8:
            
            #line 52 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            
            #line 52 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 52 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.HomeImage_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 57 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            
            #line 57 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 57 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.MinimizeImage_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 62 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            
            #line 62 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 62 "..\..\Window1.xaml"
            ((System.Windows.Controls.Image)(target)).MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler(this.CloseImage_MouseLeftButtonDown);
            
            #line default
            #line hidden
            return;
            case 11:
            this.LeftButton = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\Window1.xaml"
            this.LeftButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.LeftButton_MouseEnter);
            
            #line default
            #line hidden
            
            #line 66 "..\..\Window1.xaml"
            this.LeftButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.LeftButton_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 12:
            this.RightButton = ((System.Windows.Controls.Button)(target));
            
            #line 71 "..\..\Window1.xaml"
            this.RightButton.MouseEnter += new System.Windows.Input.MouseEventHandler(this.RightButton_MouseEnter);
            
            #line default
            #line hidden
            
            #line 71 "..\..\Window1.xaml"
            this.RightButton.MouseLeave += new System.Windows.Input.MouseEventHandler(this.RightButton_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 13:
            this.Pages = ((System.Windows.Controls.TabControl)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
