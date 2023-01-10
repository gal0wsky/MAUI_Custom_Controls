using System;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace MAUI_Custom_Controls.ViewModels
{
    public partial class MenuViewModel : BaseViewModel
    {
        public MenuViewModel()
        {
            Title = "Menu Item Clicked";
        }

        [RelayCommand]
        async void MenuItemClicked()
        {
            var logout = await Shell.Current.DisplayAlert("Logout?", "Are you sure?", "OK", "Cancel");

            Shell.Current.FlyoutIsPresented = false;

            if (logout)
            {
                await Shell.Current.GoToAsync($"///{nameof(LoginPage)}");
            }
            else
            {
                await Shell.Current.GoToAsync($"///{nameof(MainPage)}");
            }
        }
    }
}

