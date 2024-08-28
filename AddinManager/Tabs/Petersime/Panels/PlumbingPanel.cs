using AddinManager.Attributes;
using AddinManager.Buttons;
using AddinManager.Misc;
using AddinManager.Resources;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinManager.Tabs.Petersime.Panels
{
	public static class PlumbingPanel
	{
		public static void DefineAddins()
		{
			#region PlumbingPanel

			#region Pipe edits
			//Add-in Replace reduction
			AddinAttr replaceReductionAttr = new AddinAttr()
			{
				Name = "Replace reduction",
				Title = "Replace reduction",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.Piping.ReplaceReduction",
				ToolTip = "Replace an invalid pipe reduction by a series of valid reductions",
				LongDescription = "",
				Image = Tools.LoadImage("replaceReduction16x16.png"),
				LargeImage = Tools.LoadLargeImage("replaceReduction32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData replaceReductionData = ButtonStructure.CreatePushButtonData(replaceReductionAttr);

			//Add-in Weld saddle diameters
			AddinAttr weldSaddleDiametersAttr = new AddinAttr()
			{
				Name = "Weld saddle diameters",
				Title = "Weld saddle diameters",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.WeldSaddleDiameters",
				ToolTip = "Fill in the diameter of the main pipe of all PP-RCT weld saddles",
				LongDescription = "",
				Image = Tools.LoadImage("weldSaddleDiameters16x16.png"),
				LargeImage = Tools.LoadLargeImage("weldSaddleDiameters32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData weldSaddleDiametersData = ButtonStructure.CreatePushButtonData(weldSaddleDiametersAttr);
			#endregion

			#region Pipe splits
			//Add-in PP-RCT split 3m
			AddinAttr pprctSplit3mAttr = new AddinAttr()
			{
				Name = "PP-RCT split 3m",
				Title = "PP-RCT split 3m",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.PP_RCTSplit",
				ToolTip = "Click on PP-RCT pipes to split in 3 meter. Does not reconnect taps",
				LongDescription = "",
				Image = Tools.LoadImage("pprctSplit16x16.png"),
				LargeImage = Tools.LoadLargeImage("pprctSplit32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData pprctSplit3mData = Data.CreatePushButtonData(pprctSplit3mAttr);

			//Add-in PP-RCT split 4m
			AddinAttr pprctSplit4mAttr = new AddinAttr()
			{
				Name = "PP-RCT split 4m",
				Title = "PP-RCT split 4m",
				AssemblyPath = $@"{Directories.Dlls}\PlumbingPanel\PpRctSplit.dll",
				ClassName = "PpRctSplit.Command",
				ToolTip = "Click on PP-RCT pipes to split in 4 meter. Does not reconnect taps",
				LongDescription = "",
				Image = Tools.LoadImage("pprctSplit16x16.png"),
				LargeImage = Tools.LoadLargeImage("pprctSplit32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData pprctSplit4mData = Data.CreatePushButtonData(pprctSplit4mAttr);

			//Add-in PP-RCT split all 3m
			AddinAttr pprctSplitAll3mAttr = new AddinAttr()
			{
				Name = "PP-RCT split all 3m",
				Title = "PP-RCT split all 3m",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.PP_RCTSplitAll",
				ToolTip = "Split all PP-RCT pipes per 3m",
				LongDescription = "",
				Image = Tools.LoadImage("pprctSplitAll16x16.png"),
				LargeImage = Tools.LoadLargeImage("pprctSplitAll32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData pprctSplitAll3mData = Data.CreatePushButtonData(pprctSplitAll3mAttr);

			//Add-in PP-RCT split all 4m
			AddinAttr pprctSplitAll4mAttr = new AddinAttr()
			{
				Name = "PP-RCT split all 4m",
				Title = "PP-RCT split all 4m",
				AssemblyPath = $@"{Directories.Dlls}\PlumbingPanel\PpRctSplitAll.dll",
				ClassName = "PpRctSplitAll.Command",
				ToolTip = "Split all PP-RCT pipes per 4m",
				LongDescription = "",
				Image = Tools.LoadImage("pprctSplitAll16x16.png"),
				LargeImage = Tools.LoadLargeImage("pprctSplitAll32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData pprctSplitAll4mData = Data.CreatePushButtonData(pprctSplitAll4mAttr);
			#endregion

			#region Connections
			//Add-in Flex pipe connection
			AddinAttr flexPipeConnectionAttr = new AddinAttr()
			{
				Name = "Flex pipe connection",
				Title = "Flex pipe connection",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.Piping.FlexPipeConnection",
				ToolTip = "Create a flex pipe connection between 2 pipes",
				LongDescription = "",
				Image = Tools.LoadImage("flexPipeConnection16x16.png"),
				LargeImage = Tools.LoadLargeImage("flexPipeConnection32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Flexible pipe connection.pdf")
			};
			PushButtonData flexPipeConnectionData = Data.CreatePushButtonData(flexPipeConnectionAttr);

			//Add-in Connect tap high pressure cleaning
			AddinAttr connectTapHpcAttr = new AddinAttr()
			{
				Name = "Connect tap high pressure cleaning",
				Title = "Connect tap high pressure cleaning",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.Piping.ConnectTapHPC",
				ToolTip = "Connect a high pressure cleaning tap to a pipe",
				LongDescription = "",
				Image = Tools.LoadImage("connectTapHpc16x16.png"),
				LargeImage = Tools.LoadLargeImage("connectTapHpc32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData connectTapHpcData = Data.CreatePushButtonData(connectTapHpcAttr);
			#endregion

			#region Incubators piping
			//Add-in 2D symbols for XSTR
			AddinAttr piping2dDetailAttr = new AddinAttr()
			{
				Name = "2D symbols for XSTR",
				Title = "2D symbols for XSTR",
				AssemblyPath = $@"{Directories.Dlls}\Piping2DDetail.dll",
				ClassName = "Piping2D.Piping2DDetailCommand",
				ToolTip = "Change 2D scheme for compressed air | cooling water | humidifying",
				LongDescription = "",
				Image = Tools.LoadImage("piping2dDetail16x16.png"),
				LargeImage = Tools.LoadLargeImage("piping2dDetail32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData piping2dDetailData = Data.CreatePushButtonData(piping2dDetailAttr);
			#endregion

			#endregion
		}
	}
}
