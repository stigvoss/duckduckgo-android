using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DuckDuckGo
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override bool OnBackButtonPressed()
        {
            if (Browser.CanGoBack)
            {
                Browser.GoBack();

                return true;
            }
            else
            {
                return base.OnBackButtonPressed();
            }
        }

        private void OpenPage(object sender, WebNavigatingEventArgs e)
        {
            var url = new Uri(e.Url);

            if (!url.Host.In("start.duckduckgo.com", "duckduckgo.com") && url.Scheme.In("http", "https"))
            {
                Device.OpenUri(url);
                e.Cancel = true;
            }
        }
    }

    public static class Extensions
    {
        public static bool In<T>(this T target, params T[] list)
        {
            return list.Contains(target);
        }
    }
}
