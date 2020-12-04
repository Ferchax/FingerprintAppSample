using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FingerprintAppSample.ViewModels
{
    public class FingerprintViewModel
    {
        public FingerprintViewModel()
        {
            TestFingerprintCommand = new Command(async () => await TestFingerprint());
        }

        public ICommand TestFingerprintCommand { get; }

        private async Task TestFingerprint()
        {
            var request = new AuthenticationRequestConfiguration("Prove you have fingers!", "Because without it you can't have access");
            var result = await CrossFingerprint.Current.AuthenticateAsync(request);
            if (result.Authenticated)
            {
                await App.Current.MainPage.DisplayAlert("Fingerprint Authentication", "Welcome back Sr. xD", "Ok");
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Fingerprint Authentication", "Sorry, I dunno who you are ¬¬", "Ok");
            }
        }

    }
}
