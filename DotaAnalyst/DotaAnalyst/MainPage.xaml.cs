using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xamarin.Forms;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace DotaAnalyst
{
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        private bool _isLoading;

        public bool IsLoading //Binded to ActivityIndicator
        {
            get { return _isLoading; }
            private set
            {
                _isLoading = value;
                OnPropertyChanged("IsLoading");
            }
        }
        public MainPage()
        {
            SettingsPage.CreateFile(UserSettings.DefaultPath(), "English", true, 4, "Pudge");

            if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Language == "Russian")
            {
                CultureInfo ci = new CultureInfo("ru-RU");
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }
            else if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Language == "English")
            {
                CultureInfo ci = new CultureInfo("en-US");
                Thread.CurrentThread.CurrentCulture = ci;
                Thread.CurrentThread.CurrentUICulture = ci;
            }

            UserHeroes.Clear();
   
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            PickerButton.Text = Resource.MainPagePickerButton;
            BookButton.Text = Resource.MainPageBookButton;
            StatsButton.Text = Resource.MainPageStatsButton;
            CreateButton.Text = Resource.MainPageCreateButton;
        }
        private async void onSettingsClicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new SettingsPage());
        }
        private async void onPickerClicked(object sender, System.EventArgs e)
        {
            if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationMode == true)
            {
                if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Mode == "Pudge") Indicator.Source = "pudgeLoadin.png";
                else Indicator.Source = "berezh.png";

                Indicator.IsRunning = true;
                BookButton.IsVisible = false;
                StatsButton.IsVisible = false;
                PickerButton.IsVisible = false;
                CreateButton.IsVisible = false;
                SettingsButton.IsVisible = false;
    
                await Task.Delay((int)(UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationTime * 1000));
            }

            try
            {
                 await Navigation.PushAsync(new pickChoicePage());
            }
            finally
            {
                Indicator.IsRunning = false;
                BookButton.IsVisible = true;
                StatsButton.IsVisible = true;
                PickerButton.IsVisible = true;
                CreateButton.IsVisible = true;
                SettingsButton.IsVisible = true;


            }
        }
        private async void onHelperClicked(object sender, System.EventArgs e)
        {
            if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationMode == true)
            {
                if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Mode == "Pudge") Indicator.Source = "pudgeLoadin.png";
                else Indicator.Source = "berezh.png";

                Indicator.IsRunning = true;
                BookButton.IsVisible = false;
                StatsButton.IsVisible = false;
                PickerButton.IsVisible = false;
                CreateButton.IsVisible = false;
                SettingsButton.IsVisible = false;


                await Task.Delay((int)(UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationTime * 1000));
            }

            try
            {
                await Navigation.PushAsync(new HeroesTabbedPage());
            }
            finally
            {

                Indicator.IsRunning = false;
                BookButton.IsVisible = true;
                StatsButton.IsVisible = true;
                PickerButton.IsVisible = true;
                CreateButton.IsVisible = true;
                SettingsButton.IsVisible = true;


            }

        }
        private async void onStatsClicked(object sender, System.EventArgs e)
        {
            if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationMode == true)
            {
                if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Mode == "Pudge") Indicator.Source = "pudgeLoadin.png";
                else Indicator.Source = "berezh.png";

                
                Indicator.IsRunning = true;
                BookButton.IsVisible = false;
                StatsButton.IsVisible = false;
                PickerButton.IsVisible = false;
                CreateButton.IsVisible = false;
                SettingsButton.IsVisible = false;


                await Task.Delay((int)(UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationTime * 1000));
            }

            try
            {
                 await Navigation.PushAsync(new StatsPage());
            }
            finally
            {
                

                Indicator.IsRunning = false;
                BookButton.IsVisible = true;
                StatsButton.IsVisible = true;
                PickerButton.IsVisible = true;
                CreateButton.IsVisible = true;
                SettingsButton.IsVisible = true;

            }
        }

        
        private async void onCreateClicked(object sender, System.EventArgs e)
        {
            if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationMode == true)
            {
                if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Mode == "Pudge") Indicator.Source = "pudgeLoadin.png";
                else Indicator.Source = "berezh.png";

                Indicator.IsRunning = true;
                BookButton.IsVisible = false;
                StatsButton.IsVisible = false;
                PickerButton.IsVisible = false;
                CreateButton.IsVisible = false;
                SettingsButton.IsVisible = false;

                await Task.Delay((int)(UserSettings.ReadFromFile(UserSettings.DefaultPath()).AnimationTime * 1000));
            }

            try
            {
                await Navigation.PushAsync(new AddPhotoPage());
            }
            finally
            {
                Indicator.IsRunning = false;
                BookButton.IsVisible = true;
                StatsButton.IsVisible = true;
                PickerButton.IsVisible = true;
                CreateButton.IsVisible = true;
                SettingsButton.IsVisible = true;

            }
        }
    }
}
