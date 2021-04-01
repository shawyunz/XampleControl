using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _07ToggleSwitch : ContentPage
	{
		public _07ToggleSwitch()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public bool IsSelected { get; set; } = true;

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			if (IsSelected)
			{
				await SwitchEllips.TranslateTo(32, 0, 120, Easing.CubicInOut);
			}
			else
			{
				await SwitchEllips.TranslateTo(0, 0, 110, Easing.CubicInOut);
			}

			IsSelected = !IsSelected;
			OnPropertyChanged(nameof(IsSelected));
		}
	}
}