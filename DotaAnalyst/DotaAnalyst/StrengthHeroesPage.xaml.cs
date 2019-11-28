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
    public partial class StrengthHeroesPage : ContentPage
    {
        DotaHeroesList strengthHeroes;
        List<DotaHero> RandomHeroes = new List<DotaHero>();

        public StrengthHeroesPage()
        {
            Random random = new Random();
            strengthHeroes = new DotaHeroesList();
            for (int i = 1; i <= HeroesCount.GetCount(); ++i)
            {
                DotaHero CurHero = App.Database.GetItem(i);
                if (CurHero.MainAttribute == "str")
                {
                    strengthHeroes.Add(CurHero.Name, new DotaHero(CurHero));
                    RandomHeroes.Add(CurHero);
                }
            }

            for (int i = 0; i < UserHeroes.Size(); ++i)
            {
                if (UserHeroes.getAttribute(i) == "str")
                {
                    DotaHero rndHero = RandomHeroes[random.Next(0, RandomHeroes.Count - 1)];
                    rndHero.Name = UserHeroes.getName(i);
                    strengthHeroes.Add(rndHero.Name, rndHero);
                }
            }

            Grid grid = new Grid();

            int columnsNum = 4;
            int curX = 0, curY = 0;

            foreach (KeyValuePair<string, DotaHero> pair in strengthHeroes)
            {
                ImageButton curHero = new ImageButton()
                {
                    ClassId = pair.Value.Name,
                    BackgroundColor = Color.Transparent,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Source = IconNameParser.Parse(pair.Value.Name)

                };
                curHero.Clicked += OnHeroClicked;
                grid.Children.Add(curHero, curX, curY);

                curX++;
                if (curX == columnsNum)
                {
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
            DotaHero curHero = strengthHeroes[button.ClassId];
            var heroPage = new DotaHeroPage(curHero);
            heroPage.BindingContext = curHero;

            await Navigation.PushAsync(heroPage);

        }
    }
}