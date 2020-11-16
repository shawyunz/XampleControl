using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _02FloatingActionButton : ContentPage
	{
		public _02FloatingActionButton()
		{
			InitializeComponent();
		}

		private async void Button_Clicked_A(object sender, EventArgs e)
		{
			await DisplayAlert("", "Button A clicked", "ok");
		}

		private async void Button_Clicked_B(object sender, EventArgs e)
		{
			await DisplayAlert("", "Button B clicked", "ok");
		}

		private void Button_Clicked_Plus(object sender, EventArgs e)
		{
			Task.WhenAll(
				BtnA.TranslateTo(0, -70),
				BtnA.FadeTo(1),
				BtnB.TranslateTo(-70, 0),
				BtnB.FadeTo(1),
				BtnPlus.FadeTo(0.4)
			);
		}

		private void ResetButtons(object sender, EventArgs e)
		{
			Task.WhenAll(
				BtnA.TranslateTo(0, 0),
				BtnA.FadeTo(0),
				BtnB.TranslateTo(0, 0),
				BtnB.FadeTo(0),
				BtnPlus.FadeTo(1)
			);
		}
	}
}