﻿#pragma checksum "C:\Users\Andrey\Desktop\MailClient\AuthPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "963084F1B672B41FBC9ABB89C8B3B5B3"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MailClient
{
    partial class AuthPage : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private static class XamlBindingSetters
        {
            public static void Set_Windows_UI_Xaml_Controls_TextBox_Text(global::Windows.UI.Xaml.Controls.TextBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Text = value ?? global::System.String.Empty;
            }
            public static void Set_Windows_UI_Xaml_Controls_PasswordBox_Password(global::Windows.UI.Xaml.Controls.PasswordBox obj, global::System.String value, string targetNullValue)
            {
                if (value == null && targetNullValue != null)
                {
                    value = targetNullValue;
                }
                obj.Password = value ?? global::System.String.Empty;
            }
        };

        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        private class AuthPage_obj1_Bindings :
            global::Windows.UI.Xaml.Markup.IDataTemplateComponent,
            global::Windows.UI.Xaml.Markup.IXamlBindScopeDiagnostics,
            global::Windows.UI.Xaml.Markup.IComponentConnector,
            IAuthPage_Bindings
        {
            private global::MailClient.AuthPage dataRoot;
            private bool initialized = false;
            private const int NOT_PHASED = (1 << 31);
            private const int DATA_CHANGED = (1 << 30);

            // Fields for each control that has bindings.
            private global::Windows.UI.Xaml.Controls.TextBox obj2;
            private global::Windows.UI.Xaml.Controls.TextBox obj3;
            private global::Windows.UI.Xaml.Controls.PasswordBox obj4;

            // Static fields for each binding's enabled/disabled state
            private static bool isobj2TextDisabled = false;
            private static bool isobj3TextDisabled = false;
            private static bool isobj4PasswordDisabled = false;

            private AuthPage_obj1_BindingsTracking bindingsTracking;

            public AuthPage_obj1_Bindings()
            {
                this.bindingsTracking = new AuthPage_obj1_BindingsTracking(this);
            }

            public void Disable(int lineNumber, int columnNumber)
            {
                if (lineNumber == 16 && columnNumber == 21)
                {
                    isobj2TextDisabled = true;
                }
                else if (lineNumber == 27 && columnNumber == 21)
                {
                    isobj3TextDisabled = true;
                }
                else if (lineNumber == 38 && columnNumber == 21)
                {
                    isobj4PasswordDisabled = true;
                }
            }

            // IComponentConnector

            public void Connect(int connectionId, global::System.Object target)
            {
                switch(connectionId)
                {
                    case 2: // AuthPage.xaml line 12
                        this.obj2 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_2(this.obj2);
                        break;
                    case 3: // AuthPage.xaml line 23
                        this.obj3 = (global::Windows.UI.Xaml.Controls.TextBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_3(this.obj3);
                        break;
                    case 4: // AuthPage.xaml line 34
                        this.obj4 = (global::Windows.UI.Xaml.Controls.PasswordBox)target;
                        this.bindingsTracking.RegisterTwoWayListener_4(this.obj4);
                        break;
                    default:
                        break;
                }
            }

            // IDataTemplateComponent

            public void ProcessBindings(global::System.Object item, int itemIndex, int phase, out int nextPhase)
            {
                nextPhase = -1;
            }

            public void Recycle()
            {
                return;
            }

            // IAuthPage_Bindings

            public void Initialize()
            {
                if (!this.initialized)
                {
                    this.Update();
                }
            }
            
            public void Update()
            {
                this.Update_(this.dataRoot, NOT_PHASED);
                this.initialized = true;
            }

            public void StopTracking()
            {
                this.bindingsTracking.ReleaseAllListeners();
                this.initialized = false;
            }

            public void DisconnectUnloadedObject(int connectionId)
            {
                throw new global::System.ArgumentException("No unloadable elements to disconnect.");
            }

            public bool SetDataRoot(global::System.Object newDataRoot)
            {
                this.bindingsTracking.ReleaseAllListeners();
                if (newDataRoot != null)
                {
                    this.dataRoot = (global::MailClient.AuthPage)newDataRoot;
                    return true;
                }
                return false;
            }

            public void Loading(global::Windows.UI.Xaml.FrameworkElement src, object data)
            {
                this.Initialize();
            }

            // Update methods for each path node used in binding steps.
            private void Update_(global::MailClient.AuthPage obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel(obj.ViewModel, phase);
                    }
                }
                else
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_ViewModel(phase);
                    }
                }
            }
            private void Update_ViewModel(global::MailClient.ViewModels.AuthViewModel obj, int phase)
            {
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Data(obj.Data, phase);
                    }
                }
                else
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_ViewModel_Data(phase);
                    }
                }
            }
            private void Update_ViewModel_Data(global::MailClient.UserData obj, int phase)
            {
                this.bindingsTracking.UpdateChildListeners_ViewModel_Data(obj);
                if (obj != null)
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.Update_ViewModel_Data_Fullname(obj.Fullname, phase);
                        this.Update_ViewModel_Data_Login(obj.Login, phase);
                        this.Update_ViewModel_Data_Password(obj.Password, phase);
                    }
                }
                else
                {
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_ViewModel_Data_Fullname(phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_ViewModel_Data_Login(phase);
                    }
                    if ((phase & (NOT_PHASED | DATA_CHANGED | (1 << 0))) != 0)
                    {
                        this.UpdateFallback_ViewModel_Data_Password(phase);
                    }
                }
            }
            private void Update_ViewModel_Data_Fullname(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // AuthPage.xaml line 12
                    if (!isobj2TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj2, obj, "");
                    }
                }
            }
            private void Update_ViewModel_Data_Login(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // AuthPage.xaml line 23
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj3, obj, "");
                    }
                }
            }
            private void Update_ViewModel_Data_Password(global::System.String obj, int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // AuthPage.xaml line 34
                    if (!isobj4PasswordDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_PasswordBox_Password(this.obj4, obj, "");
                    }
                }
            }

            private void UpdateFallback_ViewModel(int phase)
            {
                this.UpdateFallback_ViewModel_Data(phase);
            }

            private void UpdateFallback_ViewModel_Data(int phase)
            {
                this.UpdateFallback_ViewModel_Data_Fullname(phase);
                this.UpdateFallback_ViewModel_Data_Login(phase);
                this.UpdateFallback_ViewModel_Data_Password(phase);
            }

            private void UpdateFallback_ViewModel_Data_Fullname(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // AuthPage.xaml line 12
                    if (!isobj2TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj2, "", "");
                    }
                }
            }

            private void UpdateFallback_ViewModel_Data_Login(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // AuthPage.xaml line 23
                    if (!isobj3TextDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_TextBox_Text(this.obj3, "", "");
                    }
                }
            }

            private void UpdateFallback_ViewModel_Data_Password(int phase)
            {
                if ((phase & ((1 << 0) | NOT_PHASED | DATA_CHANGED)) != 0)
                {
                    // AuthPage.xaml line 34
                    if (!isobj4PasswordDisabled)
                    {
                        XamlBindingSetters.Set_Windows_UI_Xaml_Controls_PasswordBox_Password(this.obj4, "", "");
                    }
                }
            }
            private void UpdateTwoWay_2_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.ViewModel != null)
                        {
                            if (this.dataRoot.ViewModel.Data != null)
                            {
                                this.dataRoot.ViewModel.Data.Fullname = this.obj2.Text;
                            }
                        }
                    }
                }
            }
            private void UpdateTwoWay_3_Text()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.ViewModel != null)
                        {
                            if (this.dataRoot.ViewModel.Data != null)
                            {
                                this.dataRoot.ViewModel.Data.Login = this.obj3.Text;
                            }
                        }
                    }
                }
            }
            private void UpdateTwoWay_4_Password()
            {
                if (this.initialized)
                {
                    if (this.dataRoot != null)
                    {
                        if (this.dataRoot.ViewModel != null)
                        {
                            if (this.dataRoot.ViewModel.Data != null)
                            {
                                this.dataRoot.ViewModel.Data.Password = this.obj4.Password;
                            }
                        }
                    }
                }
            }

            [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
            [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
            private class AuthPage_obj1_BindingsTracking
            {
                private global::System.WeakReference<AuthPage_obj1_Bindings> weakRefToBindingObj; 

                public AuthPage_obj1_BindingsTracking(AuthPage_obj1_Bindings obj)
                {
                    weakRefToBindingObj = new global::System.WeakReference<AuthPage_obj1_Bindings>(obj);
                }

                public AuthPage_obj1_Bindings TryGetBindingObject()
                {
                    AuthPage_obj1_Bindings bindingObject = null;
                    if (weakRefToBindingObj != null)
                    {
                        weakRefToBindingObj.TryGetTarget(out bindingObject);
                        if (bindingObject == null)
                        {
                            weakRefToBindingObj = null;
                            ReleaseAllListeners();
                        }
                    }
                    return bindingObject;
                }

                public void ReleaseAllListeners()
                {
                    UpdateChildListeners_ViewModel_Data(null);
                }

                public void PropertyChanged_ViewModel_Data(object sender, global::System.ComponentModel.PropertyChangedEventArgs e)
                {
                    AuthPage_obj1_Bindings bindings = TryGetBindingObject();
                    if (bindings != null)
                    {
                        string propName = e.PropertyName;
                        global::MailClient.UserData obj = sender as global::MailClient.UserData;
                        if (global::System.String.IsNullOrEmpty(propName))
                        {
                            if (obj != null)
                            {
                                bindings.Update_ViewModel_Data_Fullname(obj.Fullname, DATA_CHANGED);
                                bindings.Update_ViewModel_Data_Login(obj.Login, DATA_CHANGED);
                                bindings.Update_ViewModel_Data_Password(obj.Password, DATA_CHANGED);
                            }
                            else
                            {
                                bindings.UpdateFallback_ViewModel_Data_Fullname(DATA_CHANGED);
                                bindings.UpdateFallback_ViewModel_Data_Login(DATA_CHANGED);
                                bindings.UpdateFallback_ViewModel_Data_Password(DATA_CHANGED);
                            }
                        }
                        else
                        {
                            switch (propName)
                            {
                                case "Fullname":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Data_Fullname(obj.Fullname, DATA_CHANGED);
                                    }
                                    else
                                    {
                                        bindings.UpdateFallback_ViewModel_Data_Fullname(DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Login":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Data_Login(obj.Login, DATA_CHANGED);
                                    }
                                    else
                                    {
                                        bindings.UpdateFallback_ViewModel_Data_Login(DATA_CHANGED);
                                    }
                                    break;
                                }
                                case "Password":
                                {
                                    if (obj != null)
                                    {
                                        bindings.Update_ViewModel_Data_Password(obj.Password, DATA_CHANGED);
                                    }
                                    else
                                    {
                                        bindings.UpdateFallback_ViewModel_Data_Password(DATA_CHANGED);
                                    }
                                    break;
                                }
                                default:
                                    break;
                            }
                        }
                    }
                }
                private global::MailClient.UserData cache_ViewModel_Data = null;
                public void UpdateChildListeners_ViewModel_Data(global::MailClient.UserData obj)
                {
                    if (obj != cache_ViewModel_Data)
                    {
                        if (cache_ViewModel_Data != null)
                        {
                            ((global::System.ComponentModel.INotifyPropertyChanged)cache_ViewModel_Data).PropertyChanged -= PropertyChanged_ViewModel_Data;
                            cache_ViewModel_Data = null;
                        }
                        if (obj != null)
                        {
                            cache_ViewModel_Data = obj;
                            ((global::System.ComponentModel.INotifyPropertyChanged)obj).PropertyChanged += PropertyChanged_ViewModel_Data;
                        }
                    }
                }
                public void RegisterTwoWayListener_2(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_2_Text();
                        }
                    };
                }
                public void RegisterTwoWayListener_3(global::Windows.UI.Xaml.Controls.TextBox sourceObject)
                {
                    sourceObject.LostFocus += (sender, e) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_3_Text();
                        }
                    };
                }
                public void RegisterTwoWayListener_4(global::Windows.UI.Xaml.Controls.PasswordBox sourceObject)
                {
                    sourceObject.RegisterPropertyChangedCallback(global::Windows.UI.Xaml.Controls.PasswordBox.PasswordProperty, (sender, prop) =>
                    {
                        var bindingObj = this.TryGetBindingObject();
                        if (bindingObj != null)
                        {
                            bindingObj.UpdateTwoWay_4_Password();
                        }
                    });
                }
            }
        }
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 5: // AuthPage.xaml line 45
                {
                    this.AuthBtn = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.AuthBtn).Click += this.AuthBtn_Click;
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
            switch(connectionId)
            {
            case 1: // AuthPage.xaml line 1
                {                    
                    global::Windows.UI.Xaml.Controls.Page element1 = (global::Windows.UI.Xaml.Controls.Page)target;
                    AuthPage_obj1_Bindings bindings = new AuthPage_obj1_Bindings();
                    returnValue = bindings;
                    bindings.SetDataRoot(this);
                    this.Bindings = bindings;
                    element1.Loading += bindings.Loading;
                    global::Windows.UI.Xaml.Markup.XamlBindingHelper.SetDataTemplateComponent(element1, bindings);
                }
                break;
            }
            return returnValue;
        }
    }
}
