using Microsoft.UI.Xaml.Controls;
using System;
using Windows.Storage;
using Windows.UI.Notifications;
using Windows.UI.Popups;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x419

namespace Browser
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        int fullscreen = 0;
        String URL = "http://yandex.ru";

        ListView History = new ListView();
        ListView Bookmarks = new ListView();
        TextBox HomePageEnter = new TextBox();

        public MainPage()
        {
            this.InitializeComponent();
            Bookmarks.Items.Add(URL);

            //CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            //Установить указанный элемент как заголовок окна.
            //Window.Current.SetTitleBar(CustomTitleBar);

            TabViewItem item = new TabViewItem();
            item.Header = "Новая вкладка";

            WebView web = new WebView();
            web.DOMContentLoaded += Web_DOMContentLoaded;
            web.NewWindowRequested += Web_NewWindowRequested;

            item.Content = web;

            tabView.TabItems.Add(item);
            tabView.SelectedItem = item;
            item.Name = URL;
            History.Items.Add(URL);

            web.Navigate(new Uri(URL));
        }



        private void TabView_AddTabButtonClick(Microsoft.UI.Xaml.Controls.TabView sender, object args)
        {
            TabViewItem item = new TabViewItem();
            item.Header = "Новая вкладка";

            WebView web = new WebView();
            web.DOMContentLoaded += Web_DOMContentLoaded;
            web.NewWindowRequested += Web_NewWindowRequested;
            item.Content = web;

            tabView.TabItems.Add(item);
            tabView.SelectedItem = item;
            History.Items.Add(URL);
            item.Name = Convert.ToString(URL);
            URLBox.Text = "";
            web.Navigate(new Uri(URL));
        }

        private void changeTab(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                URLBox.Text = ((tabView.SelectedItem as TabViewItem).Content as WebView).Source.AbsoluteUri;
            }
            catch { }
        }

        private void Web_DOMContentLoaded(WebView sender, WebViewDOMContentLoadedEventArgs args)
        {
            (tabView.SelectedItem as TabViewItem).Header = sender.DocumentTitle;
            History.Items.Add(args.Uri);
        }

        private void tabView_TabCloseRequested(TabView sender, TabViewTabCloseRequestedEventArgs args)
        {
            tabView.TabItems.Remove(args.Tab);
            if (tabView.TabItems.Count == 0) Application.Current.Exit();
        }

        private void Web_NewWindowRequested(WebView sender, WebViewNewWindowRequestedEventArgs args)
        {
            TabViewItem item = new TabViewItem();
            item.Header = "Новая вкладка";

            WebView web = new WebView();
            web.DOMContentLoaded += Web_DOMContentLoaded;
            web.NewWindowRequested += Web_NewWindowRequested;
            item.Content = web;
            item.Name = Convert.ToString(args.Uri);

            tabView.TabItems.Add(item);
            tabView.SelectedItem = item;
            History.Items.Add(args.Uri);
            URLBox.Text = args.Uri.ToString();

            web.Navigate(args.Uri);
            args.Handled = true;
        }

        private void GoBackButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ((tabView.SelectedItem as TabViewItem).Content as WebView).GoBack();
            }
            catch { }
        }

        private void GoForwardButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ((tabView.SelectedItem as TabViewItem).Content as WebView).GoForward();
            }
            catch
            { }
        }

        private void RefreshButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                ((tabView.SelectedItem as TabViewItem).Content as WebView).Refresh();
            }
            catch { }
        }

        private void BookmarksButtonClick(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < Bookmarks.Items.Count; i++)
            {
                //ShowToastNotification(Bookmarks.Items[i].ToString(), "", 2);
                if (Bookmarks.Items[i].ToString() != (tabView.SelectedItem as TabViewItem).Name)
                {
                    Bookmarks.Items.Add((tabView.SelectedItem as TabViewItem).Name);
                    //Bookmarks.SubItems.Add((tabView.SelectedItem as TabViewItem).Name);
                    ShowToastNotification("Закладка добавлена", "Сайт '" + (tabView.SelectedItem as TabViewItem).Name + "' успешно добавлен в закладки", 2);
                }
                else
                {
                    ShowToastNotification("Закладка не добавлена", "Сайт '" + (tabView.SelectedItem as TabViewItem).Name + "'существует в закладках", 2);
                }
            }
        }

        private void TabView_OpenSettingsButtonClick(object sender, RoutedEventArgs e) //создаем элементы на вкладке Настройки
        {
            //StackPanel sp = new StackPanel();

            ListView sp = new ListView();

            TabViewItem item = new TabViewItem();
            item.Header = "Настройки";

            Button OpenBookmarks = new Button();
            OpenBookmarks.Content = "Закладки";
            OpenBookmarks.Click += OpenBookmarksTab;
            sp.Items.Add(OpenBookmarks);

            Button OpenHistory = new Button();
            OpenHistory.Content = "История";
            OpenHistory.Click += OpenHistoryTab;
            sp.Items.Add(OpenHistory);

            ToggleSwitch NightMode = new ToggleSwitch();
            NightMode.OffContent = "Светлая тема";
            NightMode.OnContent = "Темная тема";
            NightMode.IsOn = true;
            NightMode.Name = "tglAppTheme";
            NightMode.Toggled += NightMode_Toggled;
            sp.Items.Add(NightMode);

            HomePageEnter.Height = 30;
            HomePageEnter.Width = 350;
            HomePageEnter.Text = URL;
            HomePageEnter.KeyDown += pressEnterInHomeEdt;

            try
            {
                sp.Items.Add(HomePageEnter);
            }
            catch {}

            item.Content = sp;

            tabView.TabItems.Add(item);
            tabView.SelectedItem = item;
        }

        void pressEnterInHomeEdt(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                String TempURL = HomePageEnter.Text;

                if (TempURL.IndexOf("http") == -1)
                {
                    TempURL = "http://" + TempURL;
                }
                URL = TempURL;
            }
        } // записываем новый домашний адрес в переменную

        private void CheckPushEnter(object sender, KeyRoutedEventArgs e) //Проверяем поле ввода адреса на нажатие
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                TabViewItem item = new TabViewItem();
                item.Header = "Новая вкладка";

                WebView web = new WebView();
                web.DOMContentLoaded += Web_DOMContentLoaded;
                web.NewWindowRequested += Web_NewWindowRequested;
                item.Content = web;

                tabView.TabItems.Add(item);
                tabView.SelectedItem = item;

                string TempURL = URLBox.Text;

                //Console(TempURL.IndexOf("http").ToString());
                if (TempURL.IndexOf("http") == -1 || TempURL.IndexOf("https") == -1)
                {
                    TempURL = "https://www.google.com/search?newwindow=1&q=" + TempURL;
                }

                URLBox.Text = TempURL;

                web.Navigate(new Uri(TempURL));
                item.Name = TempURL;
                History.Items.Add(TempURL);
            }
        }

        private void URL_GotFocus(object sender, RoutedEventArgs e) 
        {
            TextBox text = sender as TextBox;
            if (text != null) text.SelectAll();
        } //Выделяем весь текст при клике в адресной строке

        private void OpenBookmarksTab(object sender, RoutedEventArgs e) //отображаем вкладку Закладки
        {
            TabViewItem item = new TabViewItem();
            item.Header = "Закладки";

            //Bookmarks.Items.Add("http://yandex.ru");
            Bookmarks.IsItemClickEnabled = true;
            Bookmarks.ItemClick += OpenNewTab;


            item.Content = Bookmarks;
            tabView.TabItems.Add(item);
            tabView.SelectedItem = item;
        }

        private void OpenNewTab(object sender, ItemClickEventArgs e) //открываем новую вкладку по URL
        {
            TabViewItem item = new TabViewItem();
            item.Header = "Новая вкладка";

            WebView web = new WebView();
            web.DOMContentLoaded += Web_DOMContentLoaded;
            web.NewWindowRequested += Web_NewWindowRequested;
            item.Content = web;

            tabView.TabItems.Add(item);
            tabView.SelectedItem = item;

            item.Name = Convert.ToString(e.ClickedItem);
            History.Items.Add(e.ClickedItem.ToString());

            try
            {
                web.Navigate(new Uri(e.ClickedItem.ToString()));
            }
            catch {}
        }

        private void OpenHistoryTab(object sender, RoutedEventArgs e) //отображаем вкладку История
        {
            TabViewItem item = new TabViewItem();
            item.Header = "История";

            //History.Items.Add("http://yandex.ru");
            History.IsItemClickEnabled = true;
            History.ItemClick += OpenNewTab;


            item.Content = History;
            tabView.TabItems.Add(item);
            tabView.SelectedItem = item;
        }

        private void NightMode_Toggled(object sender, RoutedEventArgs e)
        {
            FrameworkElement window = (FrameworkElement)Window.Current.Content;

            if (((ToggleSwitch)sender).IsOn)
            {
                AppSettings.Theme = AppSettings.NONDEFLTHEME;
                window.RequestedTheme = AppSettings.NONDEFLTHEME;
            }
            else
            {
                AppSettings.Theme = AppSettings.DEFAULTTHEME;
                window.RequestedTheme = AppSettings.DEFAULTTHEME;
            }
        }

        private void FullScreen(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.F11)
            {
                if (fullscreen == 0)
                {
                    ApplicationView.GetForCurrentView().TryEnterFullScreenMode();
                    fullscreen = 1;
                }
                else
                {
                    ApplicationView.GetForCurrentView().ExitFullScreenMode();
                    fullscreen = 0;
                }
            }
        }

        private void Console(String text)
        {
            System.Diagnostics.Debug.WriteLine(text);
        }

        private void ShowToastNotification(string title, string stringContent, int time)
        {
            ToastNotifier ToastNotifier = ToastNotificationManager.CreateToastNotifier();
            Windows.Data.Xml.Dom.XmlDocument toastXml = ToastNotificationManager.GetTemplateContent(ToastTemplateType.ToastText02);
            Windows.Data.Xml.Dom.XmlNodeList toastNodeList = toastXml.GetElementsByTagName("text");
            toastNodeList.Item(0).AppendChild(toastXml.CreateTextNode(title));
            toastNodeList.Item(1).AppendChild(toastXml.CreateTextNode(stringContent));
            Windows.Data.Xml.Dom.IXmlNode toastNode = toastXml.SelectSingleNode("/toast");
            //Windows.Data.Xml.Dom.XmlElement audio = toastXml.CreateElement("audio");
            //audio.SetAttribute("src", "ms-winsoundevent:Notification.SMS");

            ToastNotification toast = new ToastNotification(toastXml);
            toast.ExpirationTime = DateTime.Now.AddSeconds(time);
            ToastNotifier.Show(toast);
        }

        private void Popup(object sender, TappedRoutedEventArgs e)
        {
            MessageDialog messageDialog = new MessageDialog("Да, это мой браузер", "Никита Сергеевич - лучший препод");
            _ = messageDialog.ShowAsync();
        }
    }

    class AppSettings
    {
        public const ElementTheme DEFAULTTHEME = ElementTheme.Light;
        public const ElementTheme NONDEFLTHEME = ElementTheme.Dark;

        const string KEY_THEME = "appColourMode";
        static ApplicationDataContainer LOCALSETTINGS = ApplicationData.Current.LocalSettings;

        /// <summary>
        /// Gets or sets the current app colour setting from memory (light or dark mode).
        /// </summary>
        public static ElementTheme Theme
        {
            get
            {
                // Never set: default theme
                if (LOCALSETTINGS.Values[KEY_THEME] == null)
                {
                    LOCALSETTINGS.Values[KEY_THEME] = (int)DEFAULTTHEME;
                    return DEFAULTTHEME;
                }
                // Previously set to default theme
                else if ((int)LOCALSETTINGS.Values[KEY_THEME] == (int)DEFAULTTHEME)
                    return DEFAULTTHEME;
                // Previously set to non-default theme
                else
                    return NONDEFLTHEME;
            }
            set
            {
                // Error check
                if (value == ElementTheme.Default)
                    throw new System.Exception("Only set the theme to light or dark mode!");
                // Never set
                else if (LOCALSETTINGS.Values[KEY_THEME] == null)
                    LOCALSETTINGS.Values[KEY_THEME] = (int)value;
                // No change
                else if ((int)value == (int)LOCALSETTINGS.Values[KEY_THEME])
                    return;
                // Change
                else
                    LOCALSETTINGS.Values[KEY_THEME] = (int)value;
            }
        }
    }
}

/*
 * Меню избранное(Вместо адреса имя)
 */
