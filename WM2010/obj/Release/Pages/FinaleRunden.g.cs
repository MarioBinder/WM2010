﻿#pragma checksum "..\..\..\Pages\FinaleRunden.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9E994EE843639043199E168C5FF2F186"
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


namespace WM2010.Pages {
    
    
    /// <summary>
    /// FinaleRunden
    /// </summary>
    public partial class FinaleRunden : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\Pages\FinaleRunden.xaml"
        internal System.Windows.Controls.StackPanel buttonPanel;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Pages\FinaleRunden.xaml"
        internal System.Windows.Controls.Button FinalRundenA;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\Pages\FinaleRunden.xaml"
        internal System.Windows.Controls.Button FinalRundenV;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Pages\FinaleRunden.xaml"
        internal System.Windows.Controls.Button FinalRundenH;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Pages\FinaleRunden.xaml"
        internal System.Windows.Controls.Button FinalRundenF;
        
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
            System.Uri resourceLocater = new System.Uri("/WM2010;component/pages/finalerunden.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\FinaleRunden.xaml"
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
            
            #line 6 "..\..\..\Pages\FinaleRunden.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.OnGotoPage);
            
            #line default
            #line hidden
            return;
            case 2:
            this.buttonPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.FinalRundenA = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenA.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenA.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 4:
            this.FinalRundenV = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenV.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenV.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FinalRundenH = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenH.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 23 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenH.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            this.FinalRundenF = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenF.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Button_MouseEnter);
            
            #line default
            #line hidden
            
            #line 28 "..\..\..\Pages\FinaleRunden.xaml"
            this.FinalRundenF.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Button_MouseLeave);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
