using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUI_Custom_Controls.ViewModels
{
	public partial class TimeViewModel : ObservableObject
	{
		[ObservableProperty]
		TimeSpan time;

		public TimeViewModel()
		{
			time = DateTime.Now.TimeOfDay;
		}
	}
}

