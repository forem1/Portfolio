﻿#pragma checksum "C:\Users\Andrey\Google Диск\Портфолио\C#\Playeer\Playeer\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A06D48E476CC225AC7C19DE47400C309"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Playeer
{
    partial class MainPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // MainPage.xaml line 18
                {
                    this.MusicName = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 3: // MainPage.xaml line 39
                {
                    this.MusicList = (global::Windows.UI.Xaml.Controls.ListBox)(target);
                    ((global::Windows.UI.Xaml.Controls.ListBox)this.MusicList).SelectionChanged += this.SelectSong;
                }
                break;
            case 4: // MainPage.xaml line 31
                {
                    this.PlayPauseButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.PlayPauseButton).Click += this.PlayPauseChange;
                }
                break;
            case 5: // MainPage.xaml line 32
                {
                    this.BackSongButton = (global::Windows.UI.Xaml.Controls.Button)(target);
                }
                break;
            case 6: // MainPage.xaml line 34
                {
                    this.TimeChanger = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)this.TimeChanger).ValueChanged += this.ChangeTime;
                }
                break;
            case 7: // MainPage.xaml line 35
                {
                    this.MediaPlayer = (global::Windows.UI.Xaml.Controls.MediaElement)(target);
                    ((global::Windows.UI.Xaml.Controls.MediaElement)this.MediaPlayer).MediaOpened += this.MediaOpened;
                }
                break;
            case 8: // MainPage.xaml line 36
                {
                    global::Windows.UI.Xaml.Controls.Slider element8 = (global::Windows.UI.Xaml.Controls.Slider)(target);
                    ((global::Windows.UI.Xaml.Controls.Slider)element8).ValueChanged += this.ChangeVolume;
                }
                break;
            case 9: // MainPage.xaml line 37
                {
                    global::Windows.UI.Xaml.Controls.Button element9 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element9).Click += this.AddNewSong;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}
