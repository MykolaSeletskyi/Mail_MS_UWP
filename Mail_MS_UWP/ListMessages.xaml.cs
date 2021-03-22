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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mail_MS_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ListMessages : Page
    {
        public ListMessages()
        {
            this.InitializeComponent();
        }
        private void ListMes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ListMes.SelectedItem != null)
                if ((ListMes.SelectedItem as MimeMessage).Body.ContentType.MimeType == "multipart/alternative")
                {
                    this.Frame.Navigate(typeof(MessageHtml), ListMes.SelectedItem);
                }
                else if((ListMes.SelectedItem as MimeMessage).Body.ContentType.MimeType == "text/plain")
                {
                    this.Frame.Navigate(typeof(MessageText), ListMes.SelectedItem);
                }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null)
            {
                ListMes.ItemsSource = (IList<MimeMessage>)e.Parameter;
            }
        }
    }
}
