using Microsoft.Maui.Controls;

namespace MAUI_Custom_Controls.CustomControls;

public class CustomEntry : Entry
{
	public CustomEntry()
	{
		BackgroundColor = Colors.Transparent;
		TextColor = Colors.Black;
		FontSize = 15;
		CharacterSpacing = 20;
		FontFamily = "Roboto";
		CursorPosition = 1;
		Keyboard = Keyboard.Numeric;
		HorizontalTextAlignment = TextAlignment.Center;
		ReturnType = ReturnType.Default;
		MaxLength = 6;

		TextChanged += (s, e) =>
		{
#if __ANDROID__
			this.TextColor = Colors.White;
			this.BackgroundColor = Colors.Red;

#elif WINDOWS8_0_OR_GREATER

			this.BackgroundColor = Colors.Pink;

#endif
		};

		Completed += (s, e) =>
		{
			this.FontSize = 25;

#if __ANDROID__
			this.TextColor = Colors.Green;
#endif
		};

		ReturnCommand = new Command(() =>
		{
            this.FontSize = 25;

#if __ANDROID__
            this.TextColor = Colors.Green;
#endif
        });

		Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(CustomEntry), (handler, view) =>
		{
			if (view is CustomEntry)
			{
#if __ANDROID__
				handler.PlatformView.SetSelectAllOnFocus(true);
#endif
			}
		});
	}
}