using System.ComponentModel;
using MAUI_Custom_Controls.ViewModels;

namespace MAUI_Custom_Controls;

public partial class MainPage : ContentPage
{
	readonly MainPageViewModel vm;

	readonly Animation rotation;
    readonly Animation scaleOut;
    readonly Animation scaleIn;

    public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();
		this.vm = vm;
		BindingContext = vm;

        rotation = new Animation(v => MyBox.Rotation = v, 0, 360, Easing.Linear);

        scaleOut = new Animation(v => MyBox.Scale = v, 1, 2);
        scaleIn = new Animation(v => MyBox.Scale = v, 2, 1);

        vm.PropertyChanged += Vm_PropertyChanged;
	}

    private void Vm_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
		if (e.PropertyName == nameof(vm.RotationEnabled))
		{
			if (vm.RotationEnabled)
			{
                //animate

                rotation.Add(0, 0.5, scaleOut);
                rotation.Add(0.5, 1, scaleIn);

                rotation.Commit(this, "rotate", 16, 1000, Easing.Linear, (v, c) =>
                {
                    MyBox.Rotation = 0;
                    MyBox.Scale = 1;
                },
                () => true);
            }

            else
            {
                //stop
                this.AbortAnimation("rotate");
            }
        }
    }
}

