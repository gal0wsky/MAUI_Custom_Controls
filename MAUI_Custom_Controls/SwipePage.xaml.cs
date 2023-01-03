namespace MAUI_Custom_Controls;

using System;
using System.ComponentModel;
using MAUI_Custom_Controls.ViewModels;

public partial class SwipePage : ContentPage
{
    SwipePageViewModel vm;

	Animation swipe;

	public SwipePage(SwipePageViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
		BindingContext = this.vm;

		this.vm.PropertyChanged += Vm_PropertyChanged;

		swipe = new Animation(v => Container.Opacity = v, 0, 1);
	}

    private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
		if (e.PropertyName == nameof(vm.IsAnimationPlaying))
		{
			if (vm.IsAnimationPlaying)
			{
				//animate

				Animation moveIn = new Animation(v => Container.TranslationY = v, 200, 100);

				swipe.Add(0, 1, moveIn);

				swipe.Commit(this, "swipe", 15, 1500, Easing.Linear, (v, c) =>
				{
					Container.Opacity = 0;
					Container.TranslationY = 250;
				},
				() => true);

				Container.TranslationY -= 50;
			}
			else
			{
				//stop
				this.AbortAnimation("swipe");
			}
		}
	}
}
