using MAUI_Custom_Controls.ViewModels;

namespace MAUI_Custom_Controls;

public partial class ScrollAnimationPage : ContentPage
{
	double scrollPrev;
	readonly ScrollAnimationViewModel vm;
	bool buttonHidden;
	double buttonDefaultPosition;

	public ScrollAnimationPage(ScrollAnimationViewModel vm)
	{
		InitializeComponent();

		this.vm = vm;
		BindingContext = vm;

		buttonHidden = false;

		buttonDefaultPosition = AddButton.TranslationY;

		//scrollPrev = Container.ScrollY;
	}

    void Container_Scrolled(System.Object sender, Microsoft.Maui.Controls.ScrolledEventArgs e)
    {
		var scrollValue = e.ScrollY;

		CounterLabel.Text = scrollValue.ToString();

        var buttonPosition = AddButton.TranslationY;

        if (scrollValue >= 50 && !buttonHidden)
		{
			//hide animation

			var animation = new Animation(v => AddButton.Opacity = v, 1, 0);
			AddButton.IsEnabled = false;
			var hideAnimation = new Animation(v => AddButton.TranslationY = v, buttonPosition, buttonPosition += 50);

			animation.Add(0, 1, hideAnimation);

			animation.Commit(this, "hideButton", 16, 500, Easing.Linear, (v, c) =>
			{
				AddButton.Opacity = 0;
				AddButton.IsEnabled = false;
				AddButton.TranslationY = buttonPosition;
				buttonHidden = true;
			}, () => false);
		}
		else
		{
			if (scrollValue < 50 && buttonHidden)
			{
                //show animation
                var animation = new Animation(v => AddButton.Opacity = v, 0, 1);
                var showAnimation = new Animation(v => AddButton.TranslationY = v, buttonPosition, buttonDefaultPosition);

                animation.Add(0, 1, showAnimation);

                animation.Commit(this, "showButton", 16, 500, Easing.Linear, (v, c) =>
                {
                    AddButton.Opacity = 1;
                    AddButton.TranslationY = buttonDefaultPosition;
                    AddButton.IsEnabled = true;
					buttonHidden = false;
                },
                () => false);
            }
		}
	}
}
