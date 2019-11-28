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
    public partial class WinratePage : ContentPage
    {
        public WinratePage(int mode)
        {
            var Heroes = new DotaHeroesList();
            for (int i = 1; i <= HeroesCount.GetCount(); ++i)
            {
                DotaHero CurHero = App.Database.GetItem(i);

                Heroes.Add(CurHero.Name, new DotaHero(CurHero));
            }

            List<DotaHero> BestHeroes = new List<DotaHero>();
            foreach(var pair in Heroes.OrderBy(p => -(p.Value.GetWinrate(mode))))
            {
                BestHeroes.Add(pair.Value);
            }

            ListView HeroesWinrate = new ListView
            {
                SeparatorColor = Color.FromHex("#303030"),
                HasUnevenRows = true,
                ItemsSource = BestHeroes,
                ItemTemplate = new DataTemplate(() =>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.White, DetailColor = Color.White };
                    imageCell.SetBinding(ImageCell.TextProperty, "Name");
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "ImagePath");
                    if (mode == 0)
                    {
                        Binding  companyBinding = new Binding { Path = "PubWinrate", StringFormat = Resource.WinratePageWinratePubLabel +  ": {0:0.00}%" };
                        imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    }
                    if (mode == 1)
                    {
                        Binding companyBinding = new Binding { Path = "ProWinrate", StringFormat = Resource.WinratePageWinrateProLabel + ": {0:0.00}%" };
                        imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    }

                   
                    return imageCell;
                })   
            };

            HeroesWinrate.ItemTapped += OnItemTapped;

            InitializeComponent();
            this.Content = new StackLayout { Children = { HeroesWinrate } };
        }
        private async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {
            DotaHero selectedHero = e.Item as DotaHero;
            if (selectedHero != null) await Navigation.PushAsync(new DotaHeroPage(selectedHero));
                
        }
    }
}