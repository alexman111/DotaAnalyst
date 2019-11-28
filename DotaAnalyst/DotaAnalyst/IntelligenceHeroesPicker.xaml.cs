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
    public partial class IntelligenceHeroesPicker : ContentPage
    {
        DotaHeroesList intHeroes;

        List<DotaHero> WhoWillBanned;
        public IntelligenceHeroesPicker()
        {
            intHeroes = new DotaHeroesList();
            for (int i = 1; i <= HeroesCount.GetCount(); ++i)
            {
                DotaHero CurHero = App.Database.GetItem(i);
                if (BannedHeroes.Contains(CurHero) == false && CurHero.MainAttribute == "int") intHeroes.Add(CurHero.Name, new DotaHero(CurHero));
            }

            Grid grid = new Grid();

            int columnsNum = 4;
            int curX = 0, curY = 0;

            foreach (KeyValuePair<string, DotaHero> pair in intHeroes)
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
            BannedHeroes.Add(intHeroes[b.ClassId]);
            BannedHeroes.canDraw = true;

            Navigation.PopAsync();
        }
    }
}