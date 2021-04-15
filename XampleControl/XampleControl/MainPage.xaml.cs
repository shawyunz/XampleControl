using System;
using Xamarin.Forms;

namespace XampleControl
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

		private async void Button_Clicked01(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _01AnimatedCounter());
		}

		private async void Button_Clicked02(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _02FloatingActionButton());
		}

		private async void Button_Clicked03(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _03FakeTabs());
		}

		private async void Button_Clicked04(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _04BottomDrawer());
		}

		private async void Button_Clicked05(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _05FlipCard());
		}

		private async void Button_Clicked06(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _06CarouselGrouping());
		}

		private async void Button_Clicked07(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _07ToggleSwitch());
		}

		private async void Button_Clicked08(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new _08CutoutTextbox());
		}
	}
}