﻿#pragma checksum "C:\Users\Sean\Desktop\bd900repo\Here4Beer_BeerDowser9000\BeerDowser9000\BeerDowser9000\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "27A3F2755A956216E6B90F9C8A2D7955"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BeerDowser9000
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                {
                    this.btnAbout = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 2:
                {
                    this.btnExit = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                }
                break;
            case 3:
                {
                    this.txtBoxCurrentLocation = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4:
                {
                    this.btnFindLocations = (global::Windows.UI.Xaml.Controls.Button)(target);
                    #line 158 "..\..\..\MainPage.xaml"
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnFindLocations).Click += this.btnFindLocations_Click;
                    #line default
                }
                break;
            case 5:
                {
                    this.comboBoxSearchTypes = (global::Windows.UI.Xaml.Controls.ComboBox)(target);
                }
                break;
            case 6:
                {
                    this.txtBoxSearchQuery = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 7:
                {
                    this.listViewImages = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 8:
                {
                    this.txtBlockDetails = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 9:
                {
                    this.listViewLocations = (global::Windows.UI.Xaml.Controls.ListView)(target);
                }
                break;
            case 10:
                {
                    this.txtBoxFilter = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 14.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

