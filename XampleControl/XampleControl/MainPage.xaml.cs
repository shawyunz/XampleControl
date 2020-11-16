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
	}
}