#if __ANDROID__
using Android.App;
using Android.Content;
using Android.Service.Controls;
using Android.Views;
#endif

namespace MAUI_Custom_Controls.CustomControls;

public class CustomTimePicker : TimePicker
{
#if __ANDROID__
    private class CustomTimePickerDialog : TimePickerDialog
    {
        CustomTimePicker picker;
        TimeSpan time;

        public CustomTimePickerDialog(Context context, EventHandler<TimeSetEventArgs> callBack, int hourOfDay, int minute, bool is24HourView, ref CustomTimePicker picker) : base(context, callBack, hourOfDay, minute, is24HourView)
        {
            this.picker = picker;
        }

        public override void OnTimeChanged(Android.Widget.TimePicker view, int hourOfDay, int minute)
        {
            base.OnTimeChanged(view, hourOfDay, minute);
            this.time = new TimeSpan(hourOfDay, minute, 0);
        }

        public override void OnClick(IDialogInterface dialog, int which)
        {
            base.OnClick(dialog, which);

            if (which == -1)
            {
                TimeHelpers.Time = this.time;
                picker.SelectedTime = this.time;
            }
        }
    }

    CustomTimePickerDialog dialog = null;
#endif

	public static readonly BindableProperty SelectedTimeProperty = BindableProperty.Create(
		propertyName: nameof(SelectedTime),
		returnType: typeof(TimeSpan),
		defaultValue: DateTime.Now.TimeOfDay,
		declaringType: typeof(CustomTimePicker),
		defaultBindingMode: BindingMode.TwoWay);

	public TimeSpan SelectedTime { get => (TimeSpan)GetValue(SelectedTimeProperty); set => SetValue(SelectedTimeProperty, value); }

	public CustomTimePicker()
	{
		Format = @"HH\:mm";
		
		TimeHelpers.Time = SelectedTime;

		PropertyChanged += (s, e) =>
		{
			Time = SelectedTime;
		};

		Microsoft.Maui.Handlers.TimePickerHandler.Mapper.AppendToMapping(nameof(CustomTimePicker), (handler, view) =>
		{
			if (view is CustomTimePicker)
			{
#if __ANDROID__
				handler.PlatformView.Click += (s, e) =>
				{
					if (dialog is null)
					{
						var hour = TimeHelpers.Time.Hours;
						var minute = TimeHelpers.Time.Minutes;

						var picker = this;

						dialog = new CustomTimePickerDialog(handler.MauiContext.Context, (s,e) =>
						{
							TimeHelpers.Time = this.SelectedTime;
						}, hour, minute, true, ref picker);
					}

					dialog.Show();
                };
#endif
			}
		});
	}
}

public static class TimeHelpers
{
	public static TimeSpan Time { get; set; }
}