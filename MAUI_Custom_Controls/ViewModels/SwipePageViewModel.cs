using System;
using CommunityToolkit.Mvvm.Input;
using MvvmHelpers;

namespace MAUI_Custom_Controls.ViewModels
{
	public partial class SwipePageViewModel : BaseViewModel
	{
		bool isAnimationPlaying;
		public bool IsAnimationPlaying { get => isAnimationPlaying; set => SetProperty(ref isAnimationPlaying, value); }

		string buttonText;
		public string ButtonText { get => buttonText; set => SetProperty(ref buttonText, value); }

		public SwipePageViewModel()
		{
			IsAnimationPlaying = false;

			ButtonText = "Start";
		}

		[RelayCommand]
		void AnimationPlay()
		{
			if (IsAnimationPlaying)
			{
                IsAnimationPlaying = false;
				ButtonText = "Start";
			}
			else
			{
                IsAnimationPlaying = true;
				ButtonText = "Stop";
			}
		}
	}
}

