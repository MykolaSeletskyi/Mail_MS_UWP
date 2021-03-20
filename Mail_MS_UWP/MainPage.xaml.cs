using Mail_MS_UWP.MailServices;
using MailKit;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Mail_MS_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public class AAA:Button
    {
        public string a;
    }
    public sealed partial class MainPage : Page
    {
         MailReciever mailReciever = new MailReciever();
        public MainPage()
        {
            this.InitializeComponent();
            List.ItemsSource = mailReciever.GetFolders();

        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem != null)
                ListMes.ItemsSource = mailReciever.GetMessages((IMailFolder) List.SelectedItem);
        }
    }
    public class MyWebViewExtention
    {
        public static readonly DependencyProperty HtmlSourceProperty =
               DependencyProperty.RegisterAttached("HtmlSource", typeof(string), typeof(MyWebViewExtention), new PropertyMetadata("", OnHtmlSourceChanged));
        public static string GetHtmlSource(DependencyObject obj) { return (string)obj.GetValue(HtmlSourceProperty); }
        public static void SetHtmlSource(DependencyObject obj, string value) { obj.SetValue(HtmlSourceProperty, value); }
        private static void OnHtmlSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            WebView webView = d as WebView;
                webView?.NavigateToString((string)e.NewValue);
        }
    }
}
