﻿#pragma checksum "..\..\..\MainWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CF90E1D0D924BBCFC9CD5CAA1FA295D6603F8D33"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ten kod został wygenerowany przez narzędzie.
//     Wersja wykonawcza:4.0.30319.42000
//
//     Zmiany w tym pliku mogą spowodować nieprawidłowe zachowanie i zostaną utracone, jeśli
//     kod zostanie ponownie wygenerowany.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
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
using System.Windows.Shell;
using mrowki;


namespace mrowki {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 11 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Canvas Mrowisko;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse StartPoint;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Ellipse EndPoint;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox popCount;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox MutationChance;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TimeOfLife;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GenCount;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/mrowki;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Mrowisko = ((System.Windows.Controls.Canvas)(target));
            
            #line 11 "..\..\..\MainWindow.xaml"
            this.Mrowisko.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Mrowisko_MouseDown);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\MainWindow.xaml"
            this.Mrowisko.MouseMove += new System.Windows.Input.MouseEventHandler(this.Mrowisko_MouseMove);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\MainWindow.xaml"
            this.Mrowisko.MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.Mrowisko_MouseUp);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\MainWindow.xaml"
            this.Mrowisko.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Rectangle_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.StartPoint = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 16 "..\..\..\MainWindow.xaml"
            this.StartPoint.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Ellipse_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EndPoint = ((System.Windows.Shapes.Ellipse)(target));
            
            #line 18 "..\..\..\MainWindow.xaml"
            this.EndPoint.PreviewMouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Ellipse_PreviewMouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 22 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.Radio_draw);
            
            #line default
            #line hidden
            return;
            case 5:
            
            #line 23 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.Radio_delete);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 24 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.RadioButton)(target)).Checked += new System.Windows.RoutedEventHandler(this.Radio_stop);
            
            #line default
            #line hidden
            return;
            case 7:
            this.popCount = ((System.Windows.Controls.TextBox)(target));
            
            #line 26 "..\..\..\MainWindow.xaml"
            this.popCount.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.popCount_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.MutationChance = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\MainWindow.xaml"
            this.MutationChance.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.MutationChance_TextChanged);
            
            #line default
            #line hidden
            return;
            case 9:
            this.TimeOfLife = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\..\MainWindow.xaml"
            this.TimeOfLife.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.TimeOfLife_TextChanged);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 33 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            
            #line 34 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Step_Button);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 35 "..\..\..\MainWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Step50_Button);
            
            #line default
            #line hidden
            return;
            case 13:
            this.GenCount = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

