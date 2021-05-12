using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using Xamarin.Forms;

namespace SampleZM
{
    public class TestPage : ContentPage
    {
        private void OnButton(string culture)
        {
            CultureInfo cultureInfo = CultureInfo.GetCultureInfo(culture);

            Properties.AppResources.Culture = cultureInfo;

            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;

            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Thread.CurrentThread.CurrentUICulture = cultureInfo;

            Application.Current.MainPage = new Page()
            {
                BackgroundColor = Color.Red
            };
            Application.Current.MainPage = new TestPage();
        }

        Button AddButton(string text, string value)
        {
            return new Button
            {
                Text = text,
                Command = new Command<string>(OnButton),
                CommandParameter = value,
                Triggers =
                {
                    new DataTrigger(typeof(Button))
                    {
                        Binding = new Binding(".", source: CultureInfo.CurrentUICulture.TwoLetterISOLanguageName),
                        Value = value,
                        Setters =
                        {
                            new Setter
                            {
                                Property = BackgroundColorProperty,
                                Value = Color.Red
                            },
                        }
                    }
                }
            };
        }

        public TestPage()
        {
            Content = new StackLayout
            {
                Children =
                {
                    new Label
                    {
                        TextColor = Color.Red,
                        Text = Properties.AppResources.Red
                    },
                    AddButton("Portuguese", "pt"),
                    AddButton("Spanish", "es"),
                    AddButton("English", "en")
                }
            };
        }
    }
}
