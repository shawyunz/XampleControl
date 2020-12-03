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
		private bool isBack;
		private bool startFromFront;

		public _05FlipCard()
		{
			InitializeComponent();
			BindingContext = this;
		}

		public bool IsBack
		{
			get { return isBack; }
			set { SetProperty(ref isBack, value); }
		}

		public bool IsFront
		{
			get { return isFront; }
			set
			{
				SetProperty(ref isFront, value);
				LabelX.Text = "Front: " + (isFront ? "Yes" : "No");
			}
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
			await view1.RotateXTo(-90, 1000, Easing.CubicIn);
			view1.IsVisible = false;
			view2.IsVisible = true;
			await view2.RotateXTo(-360, 1000, Easing.CubicOut);
			view2.RotationX = 0;

			IsFront = !IsFront;
			IsBack = !IsBack;
			isFliping = false;
		}

		private void FlipCardByDragging(View view1, View view2, double distance)
		{
			double rotation = distance * -2;
			int angle = Math.Abs(((int)Math.Round(rotation)) % 360);

			LabelAngle.Text = "Flip Angle: " + angle;

			if (angle <= 90 || angle > 270)
			{
				if (IsBack)
				{
					IsFront = true;
					IsBack = false;
				}
				view1.RotationX = rotation;
			}
			else
			{
				if (IsFront)
				{
					IsFront = false;
					IsBack = true;
				}
				view2.RotationX = rotation - 180;
			}
		}

		private void PanGestureRecognizer_PanUpdated(object sender, PanUpdatedEventArgs e)
		{
			var offset = e.TotalY;
			LabelStatus.Text = "Status: " + e.StatusType.ToString();
			LabelY.Text = "Movement: " + Math.Round(offset, 1);

			if (e.StatusType.ToString() == "Started" || e.StatusType.ToString() == "Completed")
			{
				startFromFront = IsFront;
				Card2View.RotationX = IsFront ? -270 : 0;
				Card1View.RotationX = !IsFront ? -270 : 0;
				OnPropertyChanged(nameof(IsFront));
				OnPropertyChanged(nameof(IsBack));
			}

			if (startFromFront)
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