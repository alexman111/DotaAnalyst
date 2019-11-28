using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Resources;
using System.Globalization;
using System.Reflection;

namespace DotaAnalyst
{
    [ContentProperty("Text")]
    public class TranslateExtension : IMarkupExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "DotaAnalyst.Resource";

        public TranslateExtension()
        {

            if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Language == "Russian") ci = new CultureInfo("ru-RU");
            else if (UserSettings.ReadFromFile(UserSettings.DefaultPath()).Language == "English") ci = new CultureInfo("en-US");

        }

        public string Text { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Text == null)
                return "";

            ResourceManager resmgr = new ResourceManager(ResourceId,
                        typeof(TranslateExtension).GetTypeInfo().Assembly);

            var translation = resmgr.GetString(Text, ci);

            if (translation == null)
            {
                translation = Text;
            }
            return translation;
        }
    }
}