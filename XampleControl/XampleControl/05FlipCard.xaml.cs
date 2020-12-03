using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _05FlipCard : ContentPage, INotifyPropertyChanged
	{
		private bool isFliping = false;

		private bool isFront = true;

		public _05FlipCard()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public bool IsBack => !IsFront;

		public bool IsFront
		{
			get { return isFront; }
			set { SetProperty(ref isFront, value); OnPropertyChanged(nameof(IsBack)); }
		}

		protected bool SetProperty<T>(ref T backingStore, T value,
			[CallerMemberName] string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		private void Button_Clicked2(object sender, EventArgs e)
		{
			if (IsFront)
			{
				FlipCard(Card1View, Card2View);
			}
			else
			{
				FlipCard(Card2View, Card1View);
			}
		}

		private async void FlipCard(View view1, View view2)
		{
			if (isFliping)
			{
				return;
			}

			isFliping = true;
			view2.RotationX = -270;
			await view1.RotateXTo(-90, 2000, Easing.CubicIn);
			view1.IsVisible = false;
			view2.IsVisible = true;
			await view2.RotateXTo(-360, 2000, Easing.CubicOut);
			view2.RotationX = 0;

			IsFront = !IsFront;
			isFliping = false;
		}

		private async void FlipCardByDragging(View view1, View view2, double distance)
		{
			double rotation = distance * -2;

			int angle = Math.Abs(((int)Math.Round(rotation)) % 360);
			if (angle <= 90 || angle > 270)
			{
				IsFront = true;
				await view1.RotateXTo(rotation, 1, Easing.Linear);
			}
			else
			{
				IsFront = false;
				await view2.RotateXTo(rotation, 1, Easing.Linear);
			}
		}

		private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
		{
			var offset = e.TotalY;
			LabelStatus.Text = e.StatusType.ToString();
			LabelX.Text = "X distance: " + Math.Round(e.TotalX, 1);
			LabelY.Text = "Y distance: " + Math.Round(offset, 1);

			if (e.StatusType.ToString() == "Started" || e.StatusType.ToString() == "Completed")
			{
				Card2View.RotationX = IsFront ? -270 : 0;
				Card1View.RotationX = !IsFront ? -270 : 0;
			}

			if (IsFront)
			{
				FlipCardByDragging(Card1View, Card2View, offset);
			}
			else
			{
				FlipCardByDragging(Card2View, Card1View, offset);
			}
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable CS0114 // Member hides inherited member; missing override keyword

		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
#pragma warning restore CS0114 // Member hides inherited member; missing override keyword
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion INotifyPropertyChanged
	}
}