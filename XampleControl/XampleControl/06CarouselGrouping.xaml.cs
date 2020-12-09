using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XampleControl
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class _06CarouselGrouping : ContentPage
	{
		public _06CarouselGrouping()
		{
			InitializeComponent();
			MockGrouping = MockColorList
				.GroupBy(u => u.Type)
				.Select(grp => new ColorGroup(){
					ColorCategory = grp.Key,
					ColorList = grp.ToList()
				})
				.ToList();

			BindingContext = this;
		}

		public List<ColorBox> MockColorList => new List<ColorBox>()
		{
			new ColorBox {
				Type = "red",
				Code = "#fbe2ea"
			},
			new ColorBox {
				Type = "red",
				Code = "#f7bcd0"
			},
			new ColorBox {
				Type = "red",
				Code = "#fb82ab"
			},
			new ColorBox {
				Type = "red",
				Code = "#fa4482"
			},
			new ColorBox {
				Type = "red",
				Code = "#c01e5c"
			},
			new ColorBox {
				Type = "red",
				Code = "#86134f"
			},

			new ColorBox {
				Type = "green",
				Code = "#aafeeb"
			},
			new ColorBox {
				Type = "green",
				Code = "#34e8b7"
			},
			new ColorBox {
				Type = "green",
				Code = "#2abea5"
			},
			new ColorBox {
				Type = "green",
				Code = "#1e838e"
			},
			new ColorBox {
				Type = "green",
				Code = "#136063"
			},

			new ColorBox {
				Type = "purple",
				Code = "#8d2ca8"
			},
			new ColorBox {
				Type = "purple",
				Code = "#5e3aae"
			},
			new ColorBox {
				Type = "purple",
				Code = "#7c54fb"
			}
		};

		public List<ColorGroup> MockGrouping { get; set; }
	}

	public class ColorBox
	{
		public string Code { get; set; }
		public string Type { get; set; }
	}

	public class ColorGroup
	{
		public string ColorCategory { get; set; }
		public List<ColorBox> ColorList { get; set; }
	}
}