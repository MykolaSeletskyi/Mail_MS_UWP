using Mail_MS_UWP.Model;
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
            List.SelectedIndex = 0;
        }

        private void List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (List.SelectedItem != null)
                MyFrame.Navigate(typeof(ListMessages), mailReciever.GetMessages((IMailFolder)List.SelectedItem));
        }

    }
  
}
