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
                    new Button
                    {
                        Text = "Portuguese",
                        Command = new Command<string>(OnButton),
                        CommandParameter = "pt"
                    },
                    new Button
                    {
                        Text = "Spanish",
                        Command = new Command<string>(OnButton),
                        CommandParameter = "es"
                    },
                    new Button
                    {
                        Text = "English",
                        Command = new Command<string>(OnButton),
                        CommandParameter = "en"
                    }
                }
            };
        }
    }
}
