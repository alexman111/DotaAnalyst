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
    public partial class StrengthHeroesPicker : ContentPage
    {
        DotaHeroesList strengthHeroes;
        public StrengthHeroesPicker()
        {
            strengthHeroes = new DotaHeroesList();
            for (int i = 1; i <= HeroesCount.GetCount(); ++i)
            {
                DotaHero CurHero = App.Database.GetItem(i);
                if (BannedHeroes.Contains(CurHero) == false && CurHero.MainAttribute == "str") strengthHeroes.Add(CurHero.Name, new DotaHero(CurHero));
            }

            Grid grid = new Grid();

            int columnsNum = 4;
            int curX = 0, curY = 0;

            foreach (KeyValuePair<string, DotaHero> pair in strengthHeroes)
            {
                ImageButton curHero = new ImageButton()
                {
                    ClassId = pair.Value.Name,
                    CornerRadius = 20,
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    Source = IconNameParser.Parse(pair.Value.Name)

                };
                grid.Children.Add(curHero, curX, curY);
                curHero.Clicked += OnHeroClicked;

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
        private void OnHeroClicked(object sender, System.EventArgs e)
        {
            ImageButton b = (ImageButton)(sender);
            BannedHeroes.Add(strengthHeroes[b.ClassId]);
            BannedHeroes.canDraw = true;
           
            Navigation.PopAsync();
        }
    }
}