﻿#pragma checksum "..\..\AdminOrdersAddDialog.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B0572EAFAEB8C07FF3E2F90C536F11BE845AD333D08E2EA9BA2DA67714E0C247"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CarDealership;
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
using System.Windows.Shell;


namespace CarDealership {
    
    
    /// <summary>
    /// AdminOrdersAddDialog
    /// </summary>
    public partial class AdminOrdersAddDialog : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 39 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label FILabel;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker DateDP;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox PriceTextBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox CarCB;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox StatusCB;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ClientCB;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ManagerCB;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\AdminOrdersAddDialog.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CarDealership;component/adminordersadddialog.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\AdminOrdersAddDialog.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.FILabel = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.DateDP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.PriceTextBox = ((System.Windows.Controls.TextBox)(target));
            
            #line 46 "..\..\AdminOrdersAddDialog.xaml"
            this.PriceTextBox.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.AnyTB_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 4:
            this.CarCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.StatusCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 6:
            this.ClientCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 7:
            this.ManagerCB = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 63 "..\..\AdminOrdersAddDialog.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

