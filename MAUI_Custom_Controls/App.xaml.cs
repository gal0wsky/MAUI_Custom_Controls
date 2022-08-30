using Microsoft.Maui.Handlers;
using MAUI_Custom_Controls.CustomControls;
/*#if __ANDROID__
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
using Microsoft.Maui.Platform;*/

namespace MAUI_Custom_Controls;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();

		/*Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
		{
			if (view is CustomEntry)
			{
#if __ANDROID__

				handler.PlatformView.SetSelectAllOnFocus(true);
				handler.PlatformView.SetBackgroundColor(Colors.Transparent.ToAndroid());
#endif
            }
        });*/
	}
}
