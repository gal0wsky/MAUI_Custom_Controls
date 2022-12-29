using System;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace MAUI_Custom_Controls.ViewModels
{
	public partial class MainPageViewModel : BaseViewModel
	{
		public MainPageViewModel()
		{
			Title = "Main Page";
		}

		[RelayCommand]
		async Task RefreshLong(BoxView box) {
			IsBusy = true;
			await Task.Delay(5000);
			IsBusy = false;
		}
	}
}

