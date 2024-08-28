using AddinManager.Attributes;
using AddinManager.Buttons;
using AddinManager.Misc;
using AddinManager.Resources;
using Autodesk.Revit.UI;

namespace AddinManager.Tabs.Petersime.Panels
{
	public static class ElectricalPanel
	{
		public static void DefineAddins()
		{
			#region ElectricalPanel

			#region Cables
			//Add-in Cable lengths
			AddinAttr cableLengthsAttr = new AddinAttr()
			{
				Name = "Cable lengths",
				Title = "Cable lengths",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.CableLength",
				ToolTip = "Calculate distances of Cable Markers to ESB's",
				LongDescription = "",
				Image = Tools.LoadImage("cableLengths16x16.png"),
				LargeImage = Tools.LoadLargeImage("cableLengths32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Cable lengths.pdf")
			};
			PushButtonData cableLengthsData = Buttons.ButtonStructure.CreatePushButtonData(cableLengthsAttr);

			//Add-in Remove conduit lines
			AddinAttr removeConduitLinesAttr = new AddinAttr()
			{
				Name = "Remove conduit lines",
				Title = "Remove conduit lines",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.removeConduitLines",
				ToolTip = "Remove all the conduit lines",
				LongDescription = "",
				Image = Tools.LoadImage("removeConduitLines16x16.png"),
				LargeImage = Tools.LoadLargeImage("removeConduitLines32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData removeConduitLinesData = Buttons.ButtonStructure.CreatePushButtonData(removeConduitLinesAttr);

			//Add-in Calculate line lengths
			AddinAttr calculateLineLengthsAttr = new AddinAttr()
			{
				Name = "Calculate line lengths",
				Title = "Calculate line lengths",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.calculateLineLengths",
				ToolTip = "Calculate total lengths of lines per line type",
				LongDescription = "",
				Image = Tools.LoadImage("calculateLineLengths16x16.png"),
				LargeImage = Tools.LoadLargeImage("calculateLineLengths32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData calculateLineLengthsData = Buttons.ButtonStructure.CreatePushButtonData(calculateLineLengthsAttr);

			//Add-in A cable info
			AddinAttr aCableInfoAttr = new AddinAttr()
			{
				Name = "A cable info",
				Title = "A cable info",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.ACableInfo",
				ToolTip = "Show data of A cables",
				LongDescription = "",
				Image = Tools.LoadImage("aCableInfo16x16.png"),
				LargeImage = Tools.LoadLargeImage("aCableInfo32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData aCableInfoData = Buttons.ButtonStructure.CreatePushButtonData(aCableInfoAttr);
			#endregion

			#region Markers
			//Add-in Associate cable marker
			AddinAttr associateCableMarkerAttr = new AddinAttr()
			{
				Name = "Associate cable marker",
				Title = "Associate cable marker",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.AssociateCableMarker",
				ToolTip = "Associate cable marker parameters with family parameters",
				LongDescription = "",
				Image = Tools.LoadImage("associateCableMarker16x16.png"),
				LargeImage = Tools.LoadLargeImage("associateCableMarker32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData associateCableMarkerData = Buttons.ButtonStructure.CreatePushButtonData(associateCableMarkerAttr);

			//Add-in Create cable markers
			AddinAttr createCableMarkersAttr = new AddinAttr()
			{
				Name = "Create cable markers",
				Title = "Create cable markers",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.createCableMarkers",
				ToolTip = "Create and associate cable markers",
				LongDescription = "",
				Image = Tools.LoadImage("createCableMarkers16x16.png"),
				LargeImage = Tools.LoadLargeImage("createCableMarkers32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Create cable markers.mp4")
			};
			PushButtonData createCableMarkersData = Buttons.ButtonStructure.CreatePushButtonData(createCableMarkersAttr);
			#endregion

			#endregion
		}
	}
}
