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
    public partial class PickPage : ContentPage
    {
        bool whoPicked;
        int curPick = 1;
        ImageButton Radiant1 = new ImageButton { BorderWidth = 5, BorderColor = Color.Green , Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030")};
        ImageButton Radiant2 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Radiant3 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Radiant4 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Radiant5 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Dire1 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Dire2 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Dire3 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Dire4 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        ImageButton Dire5 = new ImageButton { Aspect = Aspect.Fill, BackgroundColor = Color.FromHex("#303030") };
        double radiantPower = 0, direPower = 0;

        public PickPage(bool isRadiant, bool isYou)
        {
            whoPicked = isYou;
            BannedHeroes.Clear();
            Radiant1.Clicked += onRadiant1Clicked;
            Radiant2.Clicked += onRadiant2Clicked;
            Radiant3.Clicked += onRadiant3Clicked;
            Radiant4.Clicked += onRadiant4Clicked;
            Radiant5.Clicked += onRadiant5Clicked;

            Dire1.Clicked += onDire1Clicked;
            Dire2.Clicked += onDire2Clicked;
            Dire3.Clicked += onDire3Clicked;
            Dire4.Clicked += onDire4Clicked;
            Dire5.Clicked += onDire5Clicked;


            Grid grid = new Grid();

            grid.Children.Add(Radiant1, 0, 0);
            grid.Children.Add(Radiant2, 0, 1);
            grid.Children.Add(Radiant3, 0, 2);
            grid.Children.Add(Radiant4, 0, 3);
            grid.Children.Add(Radiant5, 0, 4);
            grid.Children.Add(Dire1, 1, 0);
            grid.Children.Add(Dire2, 1, 1);
            grid.Children.Add(Dire3, 1, 2);
            grid.Children.Add(Dire4, 1, 3);
            grid.Children.Add(Dire5, 1, 4);

            Content = grid;
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            if (BannedHeroes.Size() > 0)
            {
                if (curPick == 1 && BannedHeroes.canDraw == true)
                {
                    curPick++;
                    Radiant1.BorderWidth = 0;
                    Radiant1.BorderColor = Color.Transparent;
                    Dire1.BorderWidth = 5;
                    Dire1.BorderColor = Color.Green;

                    try
                    {
                        radiantPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }catch(Exception)
                    {
                        radiantPower += 0;
                    }

                    Radiant1.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 3 && BannedHeroes.canDraw == true)
                {
                    curPick++;
                    try
                    {
                        radiantPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        radiantPower += 0;
                    }
                    Radiant2.BorderWidth = 0;
                    Radiant2.BorderColor = Color.Transparent;
                    Dire2.BorderWidth = 5;
                    Dire2.BorderColor = Color.Green;
                    Radiant2.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 5 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        radiantPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        radiantPower += 0;
                    }
                    curPick++;
                    Radiant3.BorderWidth = 0;
                    Radiant3.BorderColor = Color.Transparent;
                    Dire3.BorderWidth = 5;
                    Dire3.BorderColor = Color.Green;
                    Radiant3.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 7 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        radiantPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        radiantPower += 0;
                    }
                    curPick++;
                    Radiant4.BorderWidth = 0;
                    Radiant4.BorderColor = Color.Transparent;
                    Dire4.BorderWidth = 5;
                    Dire4.BorderColor = Color.Green;
                    Radiant4.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 9 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        radiantPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        radiantPower += 0;
                    }
                    curPick++;
                    Radiant5.BorderWidth = 0;
                    Radiant5.BorderColor = Color.Transparent;
                    Dire5.BorderWidth = 5;
                    Dire5.BorderColor = Color.Green;
                    Radiant5.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 2 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        direPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        direPower += 0;
                    }
                    curPick++;
                    Dire1.BorderWidth = 0;
                    Dire1.BorderColor = Color.Transparent;
                    Radiant2.BorderWidth = 5;
                    Radiant2.BorderColor = Color.Green;
                    Dire1.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 4 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        direPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        direPower += 0;
                    }
                    curPick++;
                    Dire2.BorderWidth = 0;
                    Dire2.BorderColor = Color.Transparent;
                    Radiant3.BorderWidth = 5;
                    Radiant3.BorderColor = Color.Green;
                    Dire2.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 6 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        direPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        direPower += 0;
                    }
                    curPick++;
                    Dire3.BorderWidth = 0;
                    Dire3.BorderColor = Color.Transparent;
                    Radiant4.BorderWidth = 5;
                    Radiant4.BorderColor = Color.Green;
                    Dire3.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 8 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        direPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        direPower += 0;
                    }
                    curPick++;
                    Dire4.BorderWidth = 0;
                    Dire4.BorderColor = Color.Transparent;
                    Radiant5.BorderWidth = 5;
                    Radiant5.BorderColor = Color.Green;
                    Dire4.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;
                }
                else if (curPick == 10 && BannedHeroes.canDraw == true)
                {
                    try
                    {
                        direPower += (double)(BannedHeroes.LastElement().AllWin) / (double)(BannedHeroes.LastElement().AllPick);
                    }
                    catch (Exception)
                    {
                        direPower += 0;
                    }

                    curPick++;
                    Dire5.BorderWidth = 0;
                    Dire5.BorderColor = Color.Transparent;
                    Dire5.Source = IconNameParser.Parse(BannedHeroes.LastElement().Name);
                    BannedHeroes.canDraw = false;

                    double radiantPercents = radiantPower / (radiantPower + direPower) * 100;
                    double direPercents = direPower / (radiantPower + direPower) * 100;

                    double delta = radiantPercents - direPercents;
                    if (delta < 0) delta = -delta;

                    string who = "Your";
                    if ((whoPicked == true && radiantPercents < direPercents) || (whoPicked == false && radiantPercents > direPercents)) who = "Enemy";

                    string text = who + " pick better by " + String.Format("{0:0.00}", delta) + "%";

                    await DisplayAlert("Pick marks", text, "OK");
                }
            }
        }
        private void onRadiant1Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 1)  Navigation.PushAsync(new PickerTabbedPage());
        }
        private void onRadiant2Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 3) Navigation.PushAsync(new PickerTabbedPage());
        }
        private void onRadiant3Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 5) Navigation.PushAsync(new PickerTabbedPage());

        }
        private  void onRadiant4Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 7) Navigation.PushAsync(new PickerTabbedPage());
        }
        private void onRadiant5Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 9) Navigation.PushAsync(new PickerTabbedPage());
        }

        private async void onDire1Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 2) await Navigation.PushAsync(new PickerTabbedPage());
        }
        private void onDire2Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 4) Navigation.PushAsync(new PickerTabbedPage());
        }
        private  void onDire3Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 6) Navigation.PushAsync(new PickerTabbedPage());
        }
        private  void onDire4Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 8) Navigation.PushAsync(new PickerTabbedPage());
        }
        private  void onDire5Clicked(object sender, System.EventArgs e)
        {
            if (curPick == 10) Navigation.PushAsync(new PickerTabbedPage());
        }
    }
}