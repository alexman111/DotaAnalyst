using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotaAnalyst
{
    public partial class App : Application
    {
       
        public const string DATABASE_NAME = "testBase.db";
        public static FriendRepository database;
        public static FriendRepository Database
        {
            get
            {
                if (database == null)
                {
                    database = new FriendRepository(DATABASE_NAME);
                }
                return database;
            }
        }
        public App()
        {
            InitializeComponent();
        
            MainPage = new NavigationPage(new MainPage());
            var converter = new ColorTypeConverter();
         
            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, converter.ConvertFromInvariantString("#1C1C1C"));
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
