using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace DotaAnalyst
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
            
            UserSettings curSettings = UserSettings.ReadFromFile(UserSettings.DefaultPath());

            this.Title = Resource.SettingsSettings;
            var table = new TableView
            {
            };
            table.Intent = TableIntent.Settings;

            var root = new TableRoot
            {
            };

            var picker = new Picker
            {
                TextColor = Color.White,
                BackgroundColor = Color.Transparent
            };

            picker.Items.Add("English");
            picker.Items.Add("Russian");
              
            if (curSettings.Language == "Russian") picker.SelectedIndex = 1;
            else picker.SelectedIndex = 0;

            var LanguageSettings = new TableSection
            {
                Title = Resource.SettingsLanguage,
                TextColor = Color.White
            };

            var languageCell = new ViewCell
            {
                View = picker
            };

            var AnimationSettings = new TableSection
            {
                Title = Resource.SettingsAnimation,
                TextColor = Color.White
            };

            var switcher = new Switch
            {
                IsToggled = curSettings.AnimationMode  
            };

            switcher.Toggled += (o, e) =>
            {
                curSettings.AnimationMode = switcher.IsToggled;
                curSettings.SaveToFile(UserSettings.DefaultPath());
            };

            var label = new Label
            {
                Text = Resource.SettingsAnimationOnGoing,
                TextColor = Color.White
            };

            var layout = new StackLayout
            {
            
                Orientation = StackOrientation.Horizontal,
                Spacing = 150,
                Children = { label, switcher }
            };

            var animationOn = new ViewCell
            {
                View = layout
            };

            var stepper = new Slider
            {
                Maximum = 10,
                Minimum = 1,
                Value = curSettings.AnimationTime

            };

            var stepperValue = new Label
            {
                Text = Resource.SettingsAnimationTime + ": " +  curSettings.AnimationTime.ToString() + " " + Resource.SettingsSeconds,
                TextColor = Color.White
            };

            stepper.ValueChanged += (o, e) =>
            {
                stepperValue.Text = Resource.SettingsAnimationTime +  ": " + stepper.Value.ToString() + " " + Resource.SettingsSeconds;
                curSettings.AnimationTime = stepper.Value;
                curSettings.SaveToFile(UserSettings.DefaultPath());
            };

            var timeLayout = new StackLayout
            {
                Children = { stepperValue, stepper }
            };

            var timeCell = new ViewCell
            {
                View = timeLayout
            };

            var switcherBerezhnov = new Switch{ };

            if (curSettings.Mode == "Pudge") switcherBerezhnov.IsToggled = false;
            else switcherBerezhnov.IsToggled = true;

            switcherBerezhnov.Toggled += (o, e) =>
            {
                if (switcherBerezhnov.IsToggled == true) curSettings.Mode = "Berezh";
                else curSettings.Mode = "Pudge";
                curSettings.SaveToFile(UserSettings.DefaultPath());
            };

            var labelBerezh =  new Label
            {
                Text = Resource.SettingsChangeAnimation,
                TextColor = Color.White
            };

            var layoutBerezh = new StackLayout
            {

                Orientation = StackOrientation.Horizontal,
                Spacing = 150,
                Children = {labelBerezh, switcherBerezhnov}
            };

            var BerezhOn = new ViewCell
            {
                View = layoutBerezh
            };

            picker.SelectedIndexChanged += (o, e) =>
            {
                curSettings.Language = picker.Items[picker.SelectedIndex];
                curSettings.SaveToFile(UserSettings.DefaultPath());

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
                LanguageSettings.Title = Resource.SettingsLanguage;
                AnimationSettings.Title = Resource.SettingsAnimation;
                label.Text = Resource.SettingsAnimationOnGoing;
                stepperValue.Text = Resource.SettingsAnimationTime + ": " + curSettings.AnimationTime.ToString() + " " + Resource.SettingsSeconds;
                labelBerezh.Text = Resource.SettingsChangeAnimation;
                
            };

            table.Root = root;
            LanguageSettings.Add(languageCell);
            AnimationSettings.Add(animationOn);
            AnimationSettings.Add(timeCell);
            AnimationSettings.Add(BerezhOn);

            root.Add(LanguageSettings);
            root.Add(AnimationSettings);
           
            Content = table;
        }
        public static void CreateFile(string FileName, string Language, bool animatedMode, int AnimationTime, string Mode)
        {
            try
            {
                if (File.Exists(FileName) == false)
                {
                    UserSettings defaultSettings = new UserSettings();

                    defaultSettings.Language = Language;
                    defaultSettings.AnimationMode = animatedMode;
                    defaultSettings.AnimationTime = AnimationTime;
                    defaultSettings.Mode = Mode;

                    defaultSettings.SaveToFile(FileName);
                }
            }catch (Exception)
            {

            }

        }
        
    }
}