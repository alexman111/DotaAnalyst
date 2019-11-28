using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DotaAnalyst;

namespace DotaAnalyst
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgilityHeroesPage : ContentPage
    {
        DotaHeroesList AgilityHeroes;
        List<DotaHero> RandomHeroes = new List<DotaHero>();
       
        public AgilityHeroesPage()
        {
         
            AgilityHeroes = new DotaHeroesList();
            Random random = new Random();

            for (int i = 1; i <= HeroesCount.GetCount(); ++i)
            {
                DotaHero CurHero = App.Database.GetItem(i);
                if (CurHero.MainAttribute == "agi")
                {
                    AgilityHeroes.Add(CurHero.Name, new DotaHero(CurHero));
                    RandomHeroes.Add(CurHero);
                }
            }

            for (int i = 0; i < UserHeroes.Size(); ++i)
            {
                if (UserHeroes.getAttribute(i) == "agi")
                {
                    DotaHero rndHero = RandomHeroes[random.Next(0, RandomHeroes.Count - 1)];
                    rndHero.Name = UserHeroes.getName(i);
                    AgilityHeroes.Add(rndHero.Name, rndHero);
                }
            }

            Grid grid = new Grid();

            int columnsNum = 4;
            int curX = 0, curY = 0;

            foreach (KeyValuePair<string, DotaHero> pair in AgilityHeroes)
            {
                ImageButton curHero = new ImageButton()
                {
                    ClassId = pair.Value.Name,
                    BackgroundColor =  Color.Transparent,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Source = IconNameParser.Parse(pair.Value.Name)
                    
                };
                curHero.Clicked += OnHeroClicked;
                grid.Children.Add(curHero, curX, curY);

                curX++;
                if (curX == columnsNum) {
                    curX = 0;
                    curY++;
                }
            }

            Content = grid;
            InitializeComponent();
        }
        async void OnHeroClicked(object sender, System.EventArgs e)
        {
            ImageButton button = (ImageButton)(sender);
            DotaHero curHero = AgilityHeroes[button.ClassId];
            var heroPage = new DotaHeroPage(curHero);
            heroPage.BindingContext = curHero;

            await Navigation.PushAsync(heroPage);

        }
    }
}