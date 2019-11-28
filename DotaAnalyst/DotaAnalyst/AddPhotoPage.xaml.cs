using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace DotaAnalyst
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddPhotoPage : ContentPage
    {
        public AddPhotoPage()
        {
            InitializeComponent();
            Button getPhotoBtn = new Button {BackgroundColor = Color.FromHex("#303030"), Text = Resource.AddPhotoPagePhotoButton, TextColor = Color.White, CornerRadius = 15};
            Button addHeroBtn = new Button { BackgroundColor = Color.FromHex("#303030"), Text = Resource.AddPhotoPageAddButton, TextColor = Color.White, CornerRadius = 15};

            ImageButton img = new ImageButton
            {
                BackgroundColor =Color.Transparent,
                Source = "pudgeLoadin.png"
            };

            Picker picker = new Picker
            {
                TextColor = Color.White,
                Title = Resource.AddPhotoPageAttribute
            };

            Entry name = new Entry
            {
                Text = "Pudge",
                TextColor = Color.White
            };

            picker.Items.Add(Resource.AddPhotoPageAgility);
            picker.Items.Add(Resource.AddPhotoPageStrength);
            picker.Items.Add(Resource.AddPhotoPageIntelligence);

            picker.SelectedIndex = 1;

            // выбор фото
            getPhotoBtn.Clicked += async (o, e) =>
            {
                try
                {
                    if (CrossMedia.Current.IsPickPhotoSupported)
                    {
                        MediaFile photo = await CrossMedia.Current.PickPhotoAsync();
                        img.Source = ImageSource.FromFile(photo.Path);
                    }
                }
                catch(Exception)
                {
                    img.Source = "pudgeLoadin.png";
                }
            };

            addHeroBtn.Clicked += async (o, e) =>
            {
                try
                {
                    string source = img.Source.ToString().Substring(6);
                    if (UserHeroes.Contains(name.Text)) throw new Exception();

                    UserHeroes.Add(source, name.Text, picker.SelectedIndex);
                    await DisplayAlert(Resource.AddPhotoPageAddingHero, Resource.AddPhotoPageSucces, "OK");
                }
                catch (Exception)
                {
                    await DisplayAlert(Resource.AddPhotoPageAddingHero, Resource.AddPhotoPageUnSucces, "OK");
                }
            };

            AbsoluteLayout absoluteLayout = new AbsoluteLayout();

            AbsoluteLayout.SetLayoutFlags(getPhotoBtn, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(getPhotoBtn, new Rectangle(0.2, 0.13, 0.45, 0.1));
            AbsoluteLayout.SetLayoutFlags(img, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(img, new Rectangle(0.2, 0.35, 0.4, 0.2));

            AbsoluteLayout.SetLayoutFlags(picker, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(picker, new Rectangle(0.91, 0.25, 0.4, 0.08));
            AbsoluteLayout.SetLayoutFlags(name, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(name, new Rectangle(0.91, 0.40, 0.4, 0.08));

            AbsoluteLayout.SetLayoutFlags(addHeroBtn, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(addHeroBtn, new Rectangle(0.4, 0.65, 0.75, 0.1));


            absoluteLayout.Children.Add(getPhotoBtn);
            absoluteLayout.Children.Add(img);
            absoluteLayout.Children.Add(picker);
            absoluteLayout.Children.Add(name);
            absoluteLayout.Children.Add(addHeroBtn);

            Content = absoluteLayout;
        }
    }
}