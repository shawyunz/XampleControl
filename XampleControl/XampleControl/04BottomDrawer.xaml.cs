using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _04BottomDrawer : ContentPage
	{
		public _04BottomDrawer()
		{
			InitializeComponent();
		}

		private async void Button_Clicked01(object sender, EventArgs e)
		{
			await LeftDrawer.TranslateTo(-20, 0, 300, Easing.CubicIn);
		}

		private async void Button_Clicked02(object sender, EventArgs e)
		{
			await RightDrawer.TranslateTo(20, 0, 300, Easing.CubicIn);
		}

		private async void Button_Clicked03(object sender, EventArgs e)
		{
			await BottomDrawer.TranslateTo(0, 20, 300, Easing.CubicIn);
		}

		private async void Button_Clicked04(object sender, EventArgs e)
		{
			await Task.WhenAll(
			BottomDrawer.TranslateTo(0, 170, 300, Easing.CubicIn),
			LeftDrawer.TranslateTo(-170, 0, 300, Easing.CubicIn),
			RightDrawer.TranslateTo(170, 0, 300, Easing.CubicIn));
		}

		private async void SwipeGestureRecognizer_Swiped01(object sender, SwipedEventArgs e)
		{
			await BottomDrawer.TranslateTo(0, 20, 300, Easing.CubicIn);
		}

		private async void SwipeGestureRecognizer_Swiped02(object sender, SwipedEventArgs e)
		{
			await LeftDrawer.TranslateTo(-20, 0, 300, Easing.CubicIn);
		}

		private async void SwipeGestureRecognizer_Swiped03(object sender, SwipedEventArgs e)
		{
			await RightDrawer.TranslateTo(20, 0, 300, Easing.CubicIn);
		}
	}
}