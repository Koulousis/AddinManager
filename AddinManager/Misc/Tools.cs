using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace AddinManager.Misc
{
	public static class Tools
	{
		public static string GetImagePath(string imageName)
		{
			string assemblyDirectory = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\RevitAddins\RevitPanel\RevitPanel\Images\";
			string imagePath = Path.Combine(assemblyDirectory, imageName);

			return imagePath;
		}

		public static string GetLargeImagePath(string largeImageName)
		{
			string assemblyDirectory = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\RevitAddins\RevitPanel\RevitPanel\LargeImages\";
			string largeImagePath = Path.Combine(assemblyDirectory, largeImageName);

			return largeImagePath;
		}

		public static BitmapImage LoadImage(string imageName)
		{
			BitmapImage Image = File.Exists(GetImagePath(imageName)) ? new BitmapImage(new Uri(GetImagePath(imageName))) : null;
			return Image;
		}

		public static BitmapImage LoadLargeImage(string largeImageName)
		{
			BitmapImage LargeImage = File.Exists(GetLargeImagePath(largeImageName)) ? new BitmapImage(new Uri(GetLargeImagePath(largeImageName))) : null;
			return LargeImage;
		}
	}
}
