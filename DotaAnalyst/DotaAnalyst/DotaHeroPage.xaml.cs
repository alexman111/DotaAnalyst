using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Microcharts;
using Microcharts.Forms;
using Entry = Microcharts.Entry;
using SkiaSharp;

namespace DotaAnalyst
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DotaHeroPage : ContentPage
    {
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();

            //BindingContext should not be null at this point
            // and you may add your code here.
        }
        DotaHero curHero;
        public DotaHeroPage(DotaHero hero)
        {
            curHero = new DotaHero(hero);

            List<Entry> entries = new List<Entry>
            {
                new Entry(curHero.ProWin)
                {
                    Color = SKColor.Parse("#17B890")
                },
                new Entry(curHero.ProPick - curHero.ProWin)
                {
                    Color = SKColor.Parse("#EE4266")
                },
            };

            List<Entry> entriesAll = new List<Entry>
            {
                new Entry(curHero.AllWin)
                {
                    Color = SKColor.Parse("#17B890")
                },
                new Entry(curHero.AllPick - curHero.AllWin)
                {
                    Color = SKColor.Parse("#EE4266")
                },
            };

            AbsoluteLayout absoluteLayout = new AbsoluteLayout();

            ChartView ProChart = new ChartView
            {
            };
            ProChart.Chart = new DonutChart() {
                Entries = entries,
                BackgroundColor = SKColors.Transparent
            };

            ChartView AllChart = new ChartView
            {
                BackgroundColor = Color.Transparent
            };
            AllChart.Chart = new DonutChart()
            {
                Entries = entriesAll,
                BackgroundColor = SKColors.Transparent
            };

            Label name = new Label { BackgroundColor = Color.Transparent, TextColor = Color.White, Text = curHero.Name,
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            if (curHero.Name.Length >= 4)
            {
                if (curHero.Name.Substring(0, 4) == "User") name.Text = curHero.Name.Substring(4);
            }

            Image icon = new Image { Source = IconNameParser.Parse(curHero.Name) };

            Image strength = new Image { Source = "strengthImage.png" };
            Label strStats = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = curHero.GetCurrentStrength().ToString() + "+" + String.Format("{0:0.00}", curHero.StrengthGain),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))

            };
           

            Image agility = new Image { Source = "agillityImage.png" };
            Label agiStats = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = curHero.GetCurrentAgility().ToString() + "+" + String.Format("{0:0.00}", curHero.AgilityGain),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))

            };

            Image intelligence = new Image { Source = "IntelligenceImage.png" };
            Label intStats = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = curHero.GetCurrentIntelligence().ToString() + "+" + String.Format("{0:0.00}", curHero.IntelligenceGain),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))

            };
          
            
            Image damagePick = new Image { Source = "damagePicture.png" };
            Label damage = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = String.Format("{0:0}", curHero.GetMinDamage()) + "-" + String.Format("{0:0}", curHero.GetMaxDamage()),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))

            };

            Image armorPic = new Image { Source = "armorIcon.png" };
            Label armor = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = String.Format("{0:0.0}", curHero.GetArmor()),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))

            };

            Image movespeedPick = new Image { Source = "movespeedIcon.png" };
            Label movespeed = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = String.Format("{0:0}", curHero.GetMoveSpeed()),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))

            };

            Label hpBarLabel = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = "HP",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            Image HpStroke = new Image { Source = "healthBar.png" };
            Image MpStroke = new Image { Source = "mana.png" };

            Label HpValueLabel = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = String.Format("{0:0}", curHero.GetHealth()) + "/" + String.Format("{0:0.00}", curHero.GetHealthRegeneration()),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };

            Label MpValueLabel = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = String.Format("{0:0}", curHero.GetMana()) + "/" + String.Format("{0:0.00}", curHero.GetManaRegeneration()),
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Label))
            };

            Label mpBarLabel = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = "MP",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            Label levelLabel = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = "LVL " + hero.Level.ToString(),
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            Slider levelSlider = new Slider
            {
                Maximum = 24
            };

            levelSlider.ValueChanged += (sender, args) =>
            {
                curHero.Level = (int)(args.NewValue) + 1;
                levelLabel.Text = "LVL " + curHero.Level.ToString();

                strStats.Text = curHero.GetCurrentStrength().ToString() + "+" + String.Format("{0:0.00}", curHero.StrengthGain);
                agiStats.Text = curHero.GetCurrentAgility().ToString() + "+" + String.Format("{0:0.00}", curHero.AgilityGain);
                intStats.Text = curHero.GetCurrentIntelligence().ToString() + "+" + String.Format("{0:0.00}", curHero.IntelligenceGain);

                damage.Text = String.Format("{0:0}", curHero.GetMinDamage()) + "-" + String.Format("{0:0}", curHero.GetMaxDamage());
                armor.Text = String.Format("{0:0.0}", curHero.GetArmor());
                movespeed.Text = String.Format("{0:0}", curHero.GetMoveSpeed());

                HpValueLabel.Text = String.Format("{0:0}", curHero.GetHealth()) + "/" + String.Format("{0:0.00}", curHero.GetHealthRegeneration());
                MpValueLabel.Text = String.Format("{0:0}", curHero.GetMana()) + "/" + String.Format("{0:0.00}", curHero.GetManaRegeneration());

            };

            Label proLabel = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = "Pro",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            Label pubLabel = new Label
            {
                BackgroundColor = Color.Transparent,
                TextColor = Color.White,
                Text = "Pub",
                FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Label))
            };

            AbsoluteLayout.SetLayoutFlags(name, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(name, new Rectangle(0.26, 0.065, 0.361, 0.077));
            AbsoluteLayout.SetLayoutFlags(icon, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(icon, new Rectangle(0.23, 0.16, 0.28, 0.1));

            AbsoluteLayout.SetLayoutFlags(strength, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(strength, new Rectangle(0.575, 0.13, 0.06, 0.03));
            AbsoluteLayout.SetLayoutFlags(strStats, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(strStats, new Rectangle(0.61, 0.161, 0.154, 0.031));

            AbsoluteLayout.SetLayoutFlags(agility, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(agility, new Rectangle(0.74, 0.13, 0.06, 0.03));
            AbsoluteLayout.SetLayoutFlags(agiStats, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(agiStats, new Rectangle(0.79, 0.161, 0.154, 0.031));

            AbsoluteLayout.SetLayoutFlags(intelligence, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(intelligence, new Rectangle(0.89, 0.13, 0.06, 0.03));
            AbsoluteLayout.SetLayoutFlags(intStats, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(intStats, new Rectangle(0.96, 0.161, 0.154, 0.031));

            AbsoluteLayout.SetLayoutFlags(damagePick, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(damagePick, new Rectangle(0.575, 0.193, 0.06, 0.03));
            AbsoluteLayout.SetLayoutFlags(damage, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(damage, new Rectangle(0.61, 0.224, 0.154, 0.031));

            AbsoluteLayout.SetLayoutFlags(armorPic, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(armorPic, new Rectangle(0.74, 0.193, 0.06, 0.03));
            AbsoluteLayout.SetLayoutFlags(armor, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(armor, new Rectangle(0.83, 0.224, 0.154, 0.031));

            AbsoluteLayout.SetLayoutFlags(movespeedPick, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(movespeedPick, new Rectangle(0.89, 0.193, 0.06, 0.03));
            AbsoluteLayout.SetLayoutFlags(movespeed, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(movespeed, new Rectangle(0.99, 0.224, 0.154, 0.031));

            AbsoluteLayout.SetLayoutFlags(hpBarLabel, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(hpBarLabel, new Rectangle(0.231,0.29,0.07,0.07));
            AbsoluteLayout.SetLayoutFlags(HpStroke, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(HpStroke, new Rectangle(0.70, 0.29, 0.55, 0.03));


            AbsoluteLayout.SetLayoutFlags(mpBarLabel, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(mpBarLabel, new Rectangle(0.231, 0.36, 0.08, 0.08));
            AbsoluteLayout.SetLayoutFlags(MpStroke, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(MpStroke, new Rectangle(0.70, 0.36, 0.55, 0.03));

            AbsoluteLayout.SetLayoutFlags(levelLabel, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(levelLabel, new Rectangle(0.3, 0.43, 0.3, 0.1));
            AbsoluteLayout.SetLayoutFlags(levelSlider, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(levelSlider, new Rectangle(0.3, 0.43, 0.7, 0.1));

            AbsoluteLayout.SetLayoutFlags(HpValueLabel, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(HpValueLabel, new Rectangle(0.57, 0.29, 0.20, 0.02));
            AbsoluteLayout.SetLayoutFlags(MpValueLabel, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(MpValueLabel, new Rectangle(0.57, 0.36, 0.20, 0.02));

            AbsoluteLayout.SetLayoutFlags(ProChart, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(ProChart, new Rectangle(0.20, 0.65, 0.40, 0.20));
            AbsoluteLayout.SetLayoutFlags(AllChart, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(AllChart, new Rectangle(0.8, 0.65, 0.40, 0.20));

            AbsoluteLayout.SetLayoutFlags(proLabel, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(proLabel, new Rectangle(0.20, 0.55, 0.1, 0.1));
            AbsoluteLayout.SetLayoutFlags(pubLabel, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(pubLabel, new Rectangle(0.8, 0.55, 0.1, 0.1));

            absoluteLayout.Children.Add(icon);
            absoluteLayout.Children.Add(name);
            absoluteLayout.Children.Add(strength);
            absoluteLayout.Children.Add(strStats);
            absoluteLayout.Children.Add(agility);
            absoluteLayout.Children.Add(agiStats);
            absoluteLayout.Children.Add(intelligence);
            absoluteLayout.Children.Add(intStats);
            absoluteLayout.Children.Add(damagePick);
            absoluteLayout.Children.Add(damage);
            absoluteLayout.Children.Add(armorPic);
            absoluteLayout.Children.Add(armor);
            absoluteLayout.Children.Add(movespeedPick);
            absoluteLayout.Children.Add(movespeed);
            absoluteLayout.Children.Add(hpBarLabel);
            absoluteLayout.Children.Add(mpBarLabel);
            absoluteLayout.Children.Add(levelLabel);
            absoluteLayout.Children.Add(levelSlider);
            absoluteLayout.Children.Add(HpStroke);
            absoluteLayout.Children.Add(MpStroke);
            absoluteLayout.Children.Add(HpValueLabel);
            absoluteLayout.Children.Add(MpValueLabel);
            absoluteLayout.Children.Add(ProChart);
            absoluteLayout.Children.Add(AllChart);
            absoluteLayout.Children.Add(pubLabel);
            absoluteLayout.Children.Add(proLabel);
            
            Content = absoluteLayout;
            InitializeComponent();

        }
    }
}