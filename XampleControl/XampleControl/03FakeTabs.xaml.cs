using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
		private void TapToView1(object sender, EventArgs e)
		{
			ResetViews();
			View1.IsVisible = true;
		}

		private void TapToView2(object sender, EventArgs e)
		{
			ResetViews();
			View2.IsVisible = true;
		}

		private void TapToView3(object sender, EventArgs e)
		{
			ResetViews();
			View3.IsVisible = true;
		}

		private void ResetViews()
		{
			View1.IsVisible = false;
			View2.IsVisible = false;
			View3.IsVisible = false;
		}

	}
}