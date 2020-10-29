using System;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _01AnimatedCounter : ContentPage
	{
		public _01AnimatedCounter()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public int CurrentCount { get; set; }
		public int NextCount { get; set; }

		public double AnimationLength { get; set; } = 200;

		private async void Button_Clicked3(object sender, EventArgs e)
		{
			NextCount = CurrentCount + 1;
			OnPropertyChanged(nameof(NextCount));

			await Task.WhenAny
			(
				Label1.TranslateTo(0, -15, (uint)AnimationLength),
				Label1.FadeTo(0, (uint)AnimationLength),
				Label2.TranslateTo(0, -15, (uint)AnimationLength),
				Label2.FadeTo(1, (uint)AnimationLength)
			).ConfigureAwait(true);

			CurrentCount = NextCount;
			OnPropertyChanged(nameof(CurrentCount));

			await Task.WhenAny
			(
				Label1.TranslateTo(0, 0, 0),
				Label1.FadeTo(1, 0),
				Label2.TranslateTo(0, 0, 0),
				Label2.FadeTo(0, 0)
			).ConfigureAwait(true);
		}

		private void Button_Clicked4(object sender, EventArgs e)
		{
			CurrentCount += 1;
			OnPropertyChanged(nameof(CurrentCount));
		}

		private async void Button_Clicked5(object sender, EventArgs e)
		{
			await Task.WhenAny
			(
				Label1.TranslateTo(0, 0, 0),
				Label1.FadeTo(1, 0),
				Label2.TranslateTo(0, 0, 0),
				Label2.FadeTo(0, 0)
			).ConfigureAwait(true);

			CurrentCount = 0;
			NextCount = 0;
			AnimationLength = 200;
			OnPropertyChanged(nameof(CurrentCount));
			OnPropertyChanged(nameof(AnimationLength));
		}
	}
}