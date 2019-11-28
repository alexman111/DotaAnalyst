using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotaAnalyst
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        public StatsPage()
        {
            InitializeComponent();
        }
        private async void onPubClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new WinratePage(0));
        }
        private async void onProClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new WinratePage(1));
        }
    }
}