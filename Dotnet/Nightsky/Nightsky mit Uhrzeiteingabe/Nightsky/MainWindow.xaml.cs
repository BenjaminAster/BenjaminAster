using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Nightsky
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Canvas nightsky;

		Ellipse moon;

		public int moonProgress = 0;

		public MainWindow()
		{
			InitializeComponent();

			nightsky = this.FindName("cnvSky") as Canvas;

		}

		public Ellipse createMoon(int radius, int x, int y)
		{
			moon = createSkyObject(radius, x, y, System.Windows.Media.Brushes.Gray);

			//moon.ZIndex = 1;
			//nightsky.SetZIndex(moon, 2);



			return moon;
		}

		public Ellipse createStar(int radius, int x, int y)
		{
			Ellipse star = createSkyObject(radius, x, y, System.Windows.Media.Brushes.White);

			return star;
		}

		public Ellipse createSkyObject(int r, int x, int y, Brush color)
		{

			Ellipse skyObject = new Ellipse();
			skyObject.Width = r * 2;
			skyObject.Height = r * 2;
			skyObject.Fill = color;

			skyObject.Margin = new Thickness(x - r, y - r, 0, 0);

			return skyObject;
		}

		public void moveMoon()
		{
			moonProgress += 10;
			//double PI = 3.1415926535;
			moon.Margin = new Thickness(moonProgress - moon.Width / 2, 450 - Math.Sin(1.0 * moonProgress / 800 * Math.PI) * 225 - moon.Height / 2, 0, 0);
		}

		private void btnShowMoon_Click(object sender, RoutedEventArgs e)
		{
			TextBox radiusTbx = this.FindName("tbxMoonRadius") as TextBox;
			int radius = int.Parse(radiusTbx.Text);

			moon = createMoon(radius, 0, 450);
			nightsky.Children.Add(moon);
		}

		private void btnMoveMoon_Click(object sender, RoutedEventArgs e)
		{
			moveMoon();
		}

		private void btnShowStars_Click(object sender, RoutedEventArgs e)
		{
			Random rand = new Random();


			TextBox nTbx = this.FindName("tbxNumberOfStars") as TextBox;
			int n = int.Parse(nTbx.Text);

			int i = 0;

			while (i < n)
			{
				int x = rand.Next(801);
				int y = rand.Next(451);
				int r = rand.Next(6) + 2;

				if (!(x <= 150 + r && y <= 103 + r) && !(x >= 650 - r && y < 42 + r))
				{
					Ellipse star = createStar(r, x, y);
					nightsky.Children.Add(star);
					i++;
				}
			}
		}
	}
}
