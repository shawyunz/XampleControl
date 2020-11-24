using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _03FakeTabs : ContentPage
	{
		public _03FakeTabs()
		{
			InitializeComponent();
		}

		private void ResetViews()
		{
			View1.IsVisible = false;
			View2.IsVisible = false;
			View3.IsVisible = false;
		}

		private void TapToView1(object sender, EventArgs e)
		{
			ResetViews();
			View1.IsVisible = true;
			SelectedHighlight.TranslateTo(0, 0, 150, easing: Easing.SinInOut);
		}

		private void TapToView2(object sender, EventArgs e)
		{
			ResetViews();
			View2.IsVisible = true;
			SelectedHighlight.TranslateTo(90, 0, 150, easing: Easing.SinInOut);
		}

		private void TapToView3(object sender, EventArgs e)
		{
			ResetViews();
			View3.IsVisible = true;
			SelectedHighlight.TranslateTo(180, 0, 150, easing: Easing.SinInOut);
		}
	}
}