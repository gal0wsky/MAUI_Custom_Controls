using System;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace MAUI_Custom_Controls.ViewModels
{
	public partial class MainPageViewModel : BaseViewModel
	{
		readonly IFingerprint fingerprint;

		bool rotationEnabled;
		public bool RotationEnabled { get => rotationEnabled; set => SetProperty(ref rotationEnabled, value); }

		public MainPageViewModel(IFingerprint fingerprint)
		{
			this.fingerprint = fingerprint;

			RotationEnabled = false;

			Title = "Main Page";
		}

		[RelayCommand]
		async Task RefreshLong(BoxView box) {
			IsBusy = true;
			RotationEnabled = true;
			await Task.Delay(5000);
			RotationEnabled = false;
            IsBusy = false;
        }

		[RelayCommand]
		async Task GoToSwipePage()
		{
            await Shell.Current.GoToAsync($"{nameof(ScrollAnimationPage)}");
        }

		[RelayCommand]
		async void BiometricAuthentication()
		{
			IsBusy = true;

			var request = new AuthenticationRequestConfiguration("Biometric authentication",
				"I'll show you, give me a finger");

			var result = await fingerprint.AuthenticateAsync(request);

			if (!result.Authenticated)
			{
				await Shell.Current.DisplayAlert("Access Denied", "No thumb, no fun", "Meh :(");
				IsBusy = false;
			}
			else
			{
				IsBusy = false;

                await Shell.Current.GoToAsync($"{nameof(SwipePage)}");
            }
		}
	}
}

