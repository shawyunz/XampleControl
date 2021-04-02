using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _07ToggleSwitch : ContentPage
	{
		private bool isBusy = false;

		public _07ToggleSwitch()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public bool IsSelected { get; set; } = false;

		private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			if (isBusy)
			{
				return;
			}

			isBusy = true;
			if (!IsSelected)
			{
				Task.WhenAll(
					SwitchEllips.TranslateTo(32, 0, 120, Easing.CubicInOut),
					EllipsBackground.ScaleTo(30, 200)
				);
			}
			else
			{
				Task.WhenAll(
					SwitchEllips.TranslateTo(0, 0, 110, Easing.CubicInOut),
					EllipsBackground.ScaleTo(1, 200)
				);
			}

			IsSelected = !IsSelected;
			OnPropertyChanged(nameof(IsSelected));
			isBusy = false;
		}
	}
}