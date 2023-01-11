namespace MAUI_Custom_Controls;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
        Routing.RegisterRoute(nameof(SwipePage), typeof(SwipePage));
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(ScrollAnimationPage), typeof(ScrollAnimationPage));
    }

    async void MenuItem_Clicked(System.Object sender, System.EventArgs e)
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
