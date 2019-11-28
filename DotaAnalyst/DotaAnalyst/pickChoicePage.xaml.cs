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
    public partial class pickChoicePage : ContentPage
    {
        public pickChoicePage()
        {
            BannedHeroes.Clear();
            InitializeComponent();
        }
        void onRadiantClicked(object sender, EventArgs e)
        {
            if (RadiantButton.IsToggled == false)
            {
                RadiantButton.IsToggled = true;
                DireButton.IsToggled = false;

                RadiantButton.BackgroundColor = Color.FromHex("#303030");
                DireButton.BackgroundColor = Color.FromHex("#1C1C1C");
            }
        }

        void onDireClicked(object sender, EventArgs e)
        {
            if (DireButton.IsToggled == false)
            {
                RadiantButton.IsToggled = false;
                DireButton.IsToggled = true;

                DireButton.BackgroundColor = Color.FromHex("#303030");
                RadiantButton.BackgroundColor = Color.FromHex("#1C1C1C");
            }
        }

        void onYouClicked(object sender, EventArgs e)
        {
            if (YouPickButton.IsToggled == false)
            {
                YouPickButton.IsToggled = true;
                EnemyPickButton.IsToggled = false;

                YouPickButton.BackgroundColor = Color.FromHex("#303030");
                EnemyPickButton.BackgroundColor = Color.FromHex("#1C1C1C");
            }
        }

        void onEnemyClicked(object sender, EventArgs e)
        {
            if (EnemyPickButton.IsToggled == false)
            {
                EnemyPickButton.IsToggled = true;
                YouPickButton.IsToggled = false;

                EnemyPickButton.BackgroundColor = Color.FromHex("#303030");
                YouPickButton.BackgroundColor = Color.FromHex("#1C1C1C");
            }
        }
        private async void onPickerClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new PickPage(RadiantButton.IsToggled, YouPickButton.IsToggled));
        }
    }
}