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
    public partial class AgilityHeroesPicker : ContentPage
    {
        DotaHeroesList AgilityHeroes;
        public AgilityHeroesPicker()
        {
            AgilityHeroes = new DotaHeroesList();
            for (int i = 1; i <= HeroesCount.GetCount(); ++i)
            {
                DotaHero CurHero = App.Database.GetItem(i);
                if (BannedHeroes.Contains(CurHero) == false && CurHero.MainAttribute == "agi") AgilityHeroes.Add(CurHero.Name, new DotaHero(CurHero));
            }

            Grid grid = new Grid();

            int columnsNum = 4;
            int curX = 0, curY = 0;

            foreach (KeyValuePair<string, DotaHero> pair in AgilityHeroes)
            {
                ImageButton curHero = new ImageButton()
                {
                    ClassId = pair.Value.Name,
                    CornerRadius = 20,
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
        void OnHeroClicked(object sender, System.EventArgs e)
        {
            ImageButton b = (ImageButton)(sender);
            BannedHeroes.Add(AgilityHeroes[b.ClassId]);
            BannedHeroes.canDraw = true;

            Navigation.PopAsync();
        }
    }
}