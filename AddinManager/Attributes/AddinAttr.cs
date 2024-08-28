using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;

namespace AddinManager.Attributes
{
	public class AddinAttr
	{
		public string Name { get; set; }
		public string Title { get; set; }
		public string AssemblyPath { get; set; }
		public string ClassName { get; set; }
		public string ToolTip { get; set; }
		public string LongDescription { get; set; }
		public BitmapImage Image { get; set; }
		public BitmapImage LargeImage { get; set; }
		public ContextualHelp Help { get; set; }

		/// <remarks>
		/// Image property: typically 16x16 pixels.
		/// Large Image property: typically 32x32 pixels.
		/// </remarks>
		public AddinAttr()
		{
			
		}
	}
}
