using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _09ScrollToHideNavigationBar : ContentPage
	{
		private double previousOffset;

		public _09ScrollToHideNavigationBar()
		{
			InitializeComponent();
		}

		private async void ScrollView_Scrolled(object sender, ScrolledEventArgs e)
		{
			double translation;
			bool visibility;

			if (previousOffset < e.ScrollY - 45)
			{
				translation = -72;
				visibility = false;
			}
			else if (previousOffset > e.ScrollY + 45)
			{
				translation = 0;
				visibility = true;
			}
			else
			{
				return;
			}

			await TitleLayout.TranslateTo(TitleLayout.TranslationX, translation, 300);
			await Task.Delay(100);
			TitleLayout.IsVisible = visibility;
			previousOffset = e.ScrollY;
		}
	}
}