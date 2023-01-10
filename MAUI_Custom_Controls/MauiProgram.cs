﻿using CommunityToolkit.Maui;
using MAUI_Custom_Controls.ViewModels;

namespace MAUI_Custom_Controls;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>().ConfigureFonts(fonts =>
        {
            fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        }).UseMauiCommunityToolkit();

        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<LoginPage>();
        builder.Services.AddSingleton<SwipePage>();
        builder.Services.AddSingleton<MainPageViewModel>();
        builder.Services.AddSingleton<SwipePageViewModel>();

        return builder.Build();
    }
}