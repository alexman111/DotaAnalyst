using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DotaAnalyst
{
    class ToggleButton : Button
    {

        public static BindableProperty IsToggledProperty =
            BindableProperty.Create("IsToggled", typeof(bool), typeof(ToggleButton), false);

        public bool IsToggled
        {
            set { SetValue(IsToggledProperty, value); }
            get { return (bool)GetValue(IsToggledProperty); }
        }
    }
}
