#region Assemblies
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AddinManager.Attributes;
using AddinManager.Buttons;
using AddinManager.Misc;
using AddinManager.Resources;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

#endregion

namespace RevitPanel
{
	public class AddinManager : IExternalApplication
	{
		public Result OnStartup(UIControlledApplication application)
		{
			string username = System.Environment.UserName;

			#region Add-ins

			#region Mechanical

			#region Suspension
			//Add-in ODM Brackets
			AddinAttr odmBracketsAttr = new AddinAttr()
			{
				Name = "ODM Brackets",
				Title = "ODM Brackets",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.ODMbrackets",
				ToolTip = "Place all the suspension markers for ODM brackets + distance to roof",
				LongDescription = "",
				Image = Tools.LoadImage("odmBrackets16x16.png"),
				LargeImage = Tools.LoadLargeImage("odmBrackets32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData odmBracketsData = Data.CreatePushButtonData(odmBracketsAttr);

			//Add-in R7 Rails
			AddinAttr r7RailsAttr = new AddinAttr()
			{
				Name = "R7 Rails",
				Title = "R7 Rails",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.R7Rails",
				ToolTip = "Place all the suspension markers for R7 rails under rectangular ducts + distance to roof",
				LongDescription = "",
				Image = Tools.LoadImage("r7Rails16x16.png"),
				LargeImage = Tools.LoadLargeImage("r7Rails32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData r7RailsData = Data.CreatePushButtonData(r7RailsAttr);

			//Add-in Duct through ceiling
			AddinAttr ductThroughCeilingAttr = new AddinAttr()
			{
				Name = "Duct through ceiling",
				Title = "Duct through ceiling",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.DuctTroughCeiling",
				ToolTip = "Place all the suspension markers for R7 rails under rectangular ducts + distance to roof",
				LongDescription = "",
				Image = Tools.LoadImage("ductThroughCeiling16x16.png"),
				LargeImage = Tools.LoadLargeImage("ductThroughCeiling32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData ductThroughCeilingData = Data.CreatePushButtonData(ductThroughCeilingAttr);

			//Add-in Duct through wall
			AddinAttr ductThroughWallAttr = new AddinAttr()
			{
				Name = "Duct through wall",
				Title = "Duct through wall",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.DuctTroughWall",
				ToolTip = "Place all the suspension markers for ducts through walls",
				LongDescription = "",
				Image = Tools.LoadImage("ductThroughWall16x16.png"),
				LargeImage = Tools.LoadLargeImage("ductThroughWall32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData ductThroughWallData = Data.CreatePushButtonData(ductThroughWallAttr);

			//Add-in Ventilator on duct
			AddinAttr ventilatorOnDuctAttr = new AddinAttr()
			{
				Name = "Ventilator on duct",
				Title = "Ventilator on duct",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.VentilatorOnDuct",
				ToolTip = "Place all the suspension markers for ventilators on ducts",
				LongDescription = "",
				Image = Tools.LoadImage("ventilatorOnDuct16x16.png"),
				LargeImage = Tools.LoadLargeImage("ventilatorOnDuct32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData ventilatorOnDuctData = Data.CreatePushButtonData(ventilatorOnDuctAttr);

			//Add-in Quantities
			AddinAttr quantitiesAttr = new AddinAttr()
			{
				Name = "Quantities",
				Title = "Quantities",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.Quantities",
				ToolTip = "Fill in total quantities",
				LongDescription = "",
				Image = Tools.LoadImage("quantities16x16.png"),
				LargeImage = Tools.LoadLargeImage("quantities32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData quantitiesData = Data.CreatePushButtonData(quantitiesAttr);

			//Add-in Take off main diameters
			AddinAttr takeOffMainDiametersAttr = new AddinAttr()
			{
				Name = "Take off main diameters",
				Title = "Take off main diameters",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.DuctTapDiameters",
				ToolTip = "Fill in the diameter of the main duct of all round curved take offs",
				LongDescription = "",
				Image = Tools.LoadImage("takeOffMainDiameters16x16.png"),
				LargeImage = Tools.LoadLargeImage("takeOffMainDiameters32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData takeOffMainDiametersData = Data.CreatePushButtonData(takeOffMainDiametersAttr);
			#endregion

			#region Duct split
			//Add-in Duct split
			AddinAttr ductSplitAttr = new AddinAttr()
			{
				Name = "Duct split",
				Title = "Duct split",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.DuctSplit",
				ToolTip = "Splits round and rectangular ducts",
				LongDescription = "",
				Image = Tools.LoadImage("ductSplit16x16.png"),
				LargeImage = Tools.LoadLargeImage("ductSplit32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData ductSplitData = Data.CreatePushButtonData(ductSplitAttr);

			//Add-in RT Duct split 2xF
			AddinAttr rtDuctSplitAttr = new AddinAttr()
			{
				Name = "RT Duct split 2xF",
				Title = "RT Duct split 2xF",
				AssemblyPath = $@"{Directories.Dlls}\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.RTDuctSplit2F",
				ToolTip = "Splits rectangular ducts with first & last duct + F",
				LongDescription = "",
				Image = Tools.LoadImage("rtDuctSplit16x16.png"),
				LargeImage = Tools.LoadLargeImage("rtDuctSplit32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData rtDuctSplitData = Data.CreatePushButtonData(rtDuctSplitAttr);
			#endregion

			#region Exhausts
			//Add-in Exhaust run
			AddinAttr exhaustRunAttr = new AddinAttr()
			{
				Name = "Exhaust run",
				Title = "Exhaust run",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.ExhaustTower",
				ToolTip = "Create a vertical duct through a roof with OKA, roof hood and 3 inspection doors",
				LongDescription = "",
				Image = Tools.LoadImage("exhaustRun16x16.png"),
				LargeImage = Tools.LoadLargeImage("exhaustRun32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData exhaustRunData = Data.CreatePushButtonData(exhaustRunAttr);

			//Add-in Exhaust offset
			AddinAttr exhaustOffsetAttr = new AddinAttr()
			{
				Name = "Exhaust offset",
				Title = "Exhaust offset",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.ExhaustOffset",
				ToolTip = "Parallel displacement of a duct by inserting 2 elbows",
				LongDescription = "",
				Image = Tools.LoadImage("exhaustOffset16x16.png"),
				LargeImage = Tools.LoadLargeImage("exhaustOffset32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData exhaustOffsetData = Data.CreatePushButtonData(exhaustOffsetAttr);
			#endregion

			#region AHU
			//Add-in AHU editor
			AddinAttr ahuEditorAttr = new AddinAttr()
			{
				Name = "AHU editor",
				Title = "AHU editor",
				AssemblyPath = $@"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Projects\Mechanical\mechanical-ahu-editor\AhuEditor\bin\Debug\AhuEditor.dll",
				ClassName = "AhuEditor.Command",
				ToolTip = "AHU Editor window",
				LongDescription = "",
				Image = Tools.LoadImage("ahuEditor16x16.png"),
				LargeImage = Tools.LoadLargeImage("ahuEditor32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\AHU editor.pdf")
			};
			PushButtonData ahuEditorData = Data.CreatePushButtonData(ahuEditorAttr);

			//Add-in Create 3D view
			AddinAttr create3DViewAttr = new AddinAttr()
			{
				Name = "Create 3D view",
				Title = "Create 3D view",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.create3Dview",
				ToolTip = "Create isometric view of an instance",
				LongDescription = "",
				Image = Tools.LoadImage("create3DView16x16.png"),
				LargeImage = Tools.LoadLargeImage("create3DView32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData create3DViewData = Data.CreatePushButtonData(create3DViewAttr);
			#endregion

			#region Accesorries
			//Add-in Insert CVD and VAV
			AddinAttr insertCvdVavAttr = new AddinAttr()
			{
				Name = "Insert CVD and VAV",
				Title = "Insert CVD and VAV",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.InsertConstantVolumeDamper",
				ToolTip = "Insert CDV and VAV with VF connectors",
				LongDescription = "",
				Image = Tools.LoadImage("insertCvdVav16x16.png"),
				LargeImage = Tools.LoadLargeImage("insertCvdVav32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData insertCvdVavData = Data.CreatePushButtonData(insertCvdVavAttr);
			#endregion

			#endregion

			#region Electrical

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
			PushButtonData cableLengthsData = Data.CreatePushButtonData(cableLengthsAttr);

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
			PushButtonData removeConduitLinesData = Data.CreatePushButtonData(removeConduitLinesAttr);

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
			PushButtonData calculateLineLengthsData = Data.CreatePushButtonData(calculateLineLengthsAttr);

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
			PushButtonData aCableInfoData = Data.CreatePushButtonData(aCableInfoAttr);
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
			PushButtonData associateCableMarkerData = Data.CreatePushButtonData(associateCableMarkerAttr);

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
			PushButtonData createCableMarkersData = Data.CreatePushButtonData(createCableMarkersAttr);
			#endregion

			#endregion

			#region Plumbing

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
			PushButtonData replaceReductionData = Data.CreatePushButtonData(replaceReductionAttr);

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
			PushButtonData weldSaddleDiametersData = Data.CreatePushButtonData(weldSaddleDiametersAttr);
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
				AssemblyPath = $@"{Directories.Dlls}\Plumbing\PpRctSplit.dll",
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
				AssemblyPath = $@"{Directories.Dlls}\Plumbing\PpRctSplitAll.dll",
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

			#region Data

			#region Data to compare
			//Add-in Data grid
			AddinAttr dataGridAttr = new AddinAttr()
			{
				Name = "Data grid",
				Title = "Data grid",
				AssemblyPath = $@"{Directories.Dlls}\DataGrid.dll",
				ClassName = "DataGrid.parameterDatagrid",
				ToolTip = "Data grid for family parameters",
				LongDescription = "",
				Image = Tools.LoadImage("dataGrid16x16.png"),
				LargeImage = Tools.LoadLargeImage("dataGrid32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData dataGridData = Data.CreatePushButtonData(dataGridAttr);

			//Add-in Cable data
			AddinAttr cableDataAttr = new AddinAttr()
			{
				Name = "Cable data",
				Title = "Cable data",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.CheckCableData",
				ToolTip = "Compare cable marker data with excel regulation file",
				LongDescription = "",
				Image = Tools.LoadImage("cableData16x16.png"),
				LargeImage = Tools.LoadLargeImage("cableData32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Cable data.pdf")
			};
			PushButtonData cableDataData = Data.CreatePushButtonData(cableDataAttr);
			#endregion

			#region Export data
			//Add-in Dwfx | Dwg | Pdf
			AddinAttr DwfxDwgPdfAttr = new AddinAttr()
			{
				Name = "Dwfx | Dwg | Pdf",
				Title = "Dwfx | Dwg | Pdf",
				AssemblyPath = $@"{Directories.Dlls}\SheetExport.dll",
				ClassName = "SheetExport.SheetExport",
				ToolTip = "Exports files,data and sheets from Revit",
				LongDescription = "",
				Image = Tools.LoadImage("DwfxDwgPdf16x16.png"),
				LargeImage = Tools.LoadLargeImage("DwfxDwgPdf32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Dwfx - Dwg - Pdf.pdf")
			};
			PushButtonData DwfxDwgPdfData = Data.CreatePushButtonData(DwfxDwgPdfAttr);

			//Add-in Bumper lengths
			AddinAttr bumperLengthsAttr = new AddinAttr()
			{
				Name = "Bumper lengths",
				Title = "Bumper lengths",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.calculateBumperLengths",
				ToolTip = "Calculate the bumper lengths based on filled regions",
				LongDescription = "",
				Image = Tools.LoadImage("bumperLengths16x16.png"),
				LargeImage = Tools.LoadLargeImage("bumperLengths32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData bumperLengthsData = Data.CreatePushButtonData(bumperLengthsAttr);

			//Add-in Translations
			AddinAttr translationsAttr = new AddinAttr()
			{
				Name = "Translations",
				Title = "Translations",
				AssemblyPath = $@"{Directories.Dlls}\Translations.dll",
				ClassName = "Translations.Translate",
				ToolTip = "Add translations for cable Position, cable description, room name",
				LongDescription = "",
				Image = Tools.LoadImage("translations16x16.png"),
				LargeImage = Tools.LoadLargeImage("translations32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData translationsData = Data.CreatePushButtonData(translationsAttr);

			//Add-in Eagle eye layouts
			AddinAttr eagleEyeLayoutsAttr = new AddinAttr()
			{
				Name = "Eagle eye layouts",
				Title = "Eagle eye layouts",
				AssemblyPath = $@"{Directories.TestDlls}\EagleEyeLayouts.dll",
				ClassName = "EagleEyeLayouts.Command",
				ToolTip = "Export Eagle Eye layout images",
				LongDescription = "",
				Image = Tools.LoadImage("eagleEyeLayouts16x16.png"),
				LargeImage = Tools.LoadLargeImage("eagleEyeLayouts32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Eagle eye layouts.pdf")
			};
			PushButtonData eagleEyeLayoutsData = Data.CreatePushButtonData(eagleEyeLayoutsAttr);
			
			#region Data to validate
			//Add-in Checking tools
			AddinAttr checkingToolsAttr = new AddinAttr()
			{
				Name = "Checking tools",
				Title = "Checking tools",
				AssemblyPath = $@"{Directories.Dlls}\PETAddin.dll",
				ClassName = "PETAddin.Tools",
				ToolTip = "Opens a window with the available checking tools",
				LongDescription = "",
				Image = Tools.LoadImage("checkingTools16x16.png"),
				LargeImage = Tools.LoadLargeImage("checkingTools32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData checkingToolsData = Data.CreatePushButtonData(checkingToolsAttr);
			#endregion

			#endregion

			#region Plan

			#region Revit shortcuts
			//Add-in Center room tags
			AddinAttr centerRoomsTagsAttr = new AddinAttr()
			{
				Name = "Center room tags",
				Title = "Center room tags",
				AssemblyPath = $@"{Directories.Dlls}\HVAC.dll",
				ClassName = "HVAC.Rooms.CenterAllRoomTags",
				ToolTip = "Center all the room tags in the active view",
				LongDescription = "",
				Image = Tools.LoadImage("centerRoomsTags16x16.png"),
				LargeImage = Tools.LoadLargeImage("centerRoomsTags32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData centerRoomsTagsData = Data.CreatePushButtonData(centerRoomsTagsAttr);

			//Add-in Structure Selector
			AddinAttr structureSelectorAttr = new AddinAttr()
			{
				Name = "Structure Selector",
				Title = "Structure Selector",
				AssemblyPath = $@"{Directories.Dlls}\StructureSelector.dll",
				ClassName = "StructureSelector.Command",
				ToolTip = "Steel structure selector help the user to select a group of structure components",
				LongDescription = "",
				Image = Tools.LoadImage("structureSelector16x16.png"),
				LargeImage = Tools.LoadLargeImage("structureSelector32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soons.pdf")
			};
			PushButtonData structureSelectorData = Data.CreatePushButtonData(structureSelectorAttr);

			//Add-in Renumber duct system
			AddinAttr renumberDuctSystemAttr = new AddinAttr()
			{
				Name = "Renumber duct system",
				Title = "Renumber duct system",
				AssemblyPath = $@"{Directories.Dlls}\RenumberElements 2016.dll",
				ClassName = "RenumberElements",
				ToolTip = "Add alphabetic and arithmetic order to a duct system for 3D views",
				LongDescription = "",
				Image = Tools.LoadImage("renumberDuctSystem16x16.png"),
				LargeImage = Tools.LoadLargeImage("renumberDuctSystem32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData renumberDuctSystemData = Data.CreatePushButtonData(renumberDuctSystemAttr);
			#endregion

			//Add-in Weekplanning
			AddinAttr weekplanningAttr = new AddinAttr()
			{
				Name = "Weekplanning",
				Title = "Weekplanning",
				AssemblyPath = $@"{Directories.Dlls}\Weekplanning.dll",
				ClassName = "Weekplanning.Command",
				ToolTip = "Opens the weekplanning pdf file",
				LongDescription = "",
				Image = Tools.LoadImage("weekplanning16x16.png"),
				LargeImage = Tools.LoadLargeImage("weekplanning32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Coming soon.pdf")
			};
			PushButtonData weekplanningData = Data.CreatePushButtonData(weekplanningAttr);

			//Add-in Family parameter read
			AddinAttr familyReadParameterAttr = new AddinAttr()
			{
				Name = "Family read parameter",
				Title = "Family Read\rParameter",
				AssemblyPath = $@"{Directories.Dlls}\FamilyReadParameter.dll",
				ClassName = "FamilyReadParameter.Command",
				ToolTip = "Select any amount of families, then select a parameter group and select a family to print it's parameters into a grid view",
				LongDescription = "",
				Image = Tools.LoadImage("familyReadParameter16x16.png"),
				LargeImage = Tools.LoadLargeImage("familyReadParameter32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Family Read Parameter.pdf")
			};
			PushButtonData familyReadParameterData = Data.CreatePushButtonData(familyReadParameterAttr);

			//Add-in Family upgrade
			AddinAttr familyUpgradeAttr = new AddinAttr()
			{
				Name = "Family upgrade",
				Title = "Family\rUpgrade",
				AssemblyPath = $@"{Directories.Dlls}\FamilyUpgrade.dll",
				ClassName = "FamilyUpgrade.Command",
				ToolTip = "Upgrade selected families to the current version of Revit you are running this add-in",
				LongDescription = "Example: You are using right now Revit 2023. You can select families older than 2023 and the add-in will upgrade them to 2023 version.",
				Image = Tools.LoadImage("familyUpgrade16x16.png"),
				LargeImage = Tools.LoadLargeImage("familyUpgrade32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\Family upgrade.pdf")
			};
			PushButtonData familyUpgradeData = Data.CreatePushButtonData(familyUpgradeAttr);

			#endregion

			#endregion

			#region Testing
			
			#endregion

			#endregion

			#region UI Elements
			//Ribbon panel
			application.CreateRibbonTab("Petersime");

			RibbonPanel mechanicalPanel = application.CreateRibbonPanel("Petersime", "Mechanical");
			RibbonPanel electricalPanel = application.CreateRibbonPanel("Petersime", "Electrical");
			RibbonPanel plumbingPanel = application.CreateRibbonPanel("Petersime", "Plumbing");
			RibbonPanel dataPanel = application.CreateRibbonPanel("Petersime", "Data");
			RibbonPanel planPanel = application.CreateRibbonPanel("Petersime", "Plan");

			#region Mechanical
			//Suspension
			PulldownButtonAttr suspensionPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Suspension",
				Title = "Suspension",
				ToolTip = "Suspension add-ins",
				LongDescription = "",
				Image =  Tools.LoadImage("suspension16x16.png"),
				LargeImage = Tools.LoadLargeImage("suspension32x32.png")
			};
			PulldownButtonData suspensionPulldownButtonData = Data.CreatePulldownButtonData(suspensionPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, suspensionPulldownButtonData, new List<PushButtonData>() { odmBracketsData, r7RailsData, ductThroughCeilingData, ductThroughWallData, ventilatorOnDuctData, quantitiesData, takeOffMainDiametersData });

			//Duct splits
			PulldownButtonAttr ductSplitPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Duct splits",
				Title = "Duct\rsplits",
				ToolTip = "Duct splits add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("ductSplits16x16.png"),
				LargeImage = Tools.LoadLargeImage("ductSplits32x32.png")
			};
			PulldownButtonData ductSplitPulldownButtonData = Data.CreatePulldownButtonData(ductSplitPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, ductSplitPulldownButtonData, new List<PushButtonData>() { ductSplitData, rtDuctSplitData });

			//Exhausts
			PulldownButtonAttr exhaustsPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Exhausts",
				Title = "Exhausts",
				ToolTip = "Exhausts add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("exhausts16x16.png"),
				LargeImage = Tools.LoadLargeImage("exhausts32x32.png")
			};
			PulldownButtonData exhaustsPulldownButtonData = Data.CreatePulldownButtonData(exhaustsPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, exhaustsPulldownButtonData, new List<PushButtonData>() { exhaustRunData, exhaustOffsetData });

			//AHU
			PulldownButtonAttr ahuPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "AHU",
				Title = "AHU",
				ToolTip = "AHU add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("ahu16x16.png"),
				LargeImage = Tools.LoadLargeImage("ahu32x32.png")
			};
			PulldownButtonData ahuPulldownButtonData = Data.CreatePulldownButtonData(ahuPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, ahuPulldownButtonData, new List<PushButtonData>() { ahuEditorData, create3DViewData });

			//Accessories
			PulldownButtonAttr accessoriesPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Accessories",
				Title = "Accessories",
				ToolTip = "Accessories add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("accessories16x16.png"),
				LargeImage = Tools.LoadLargeImage("accessories32x32.png")
			};
			PulldownButtonData accessoriesPulldownButtonData = Data.CreatePulldownButtonData(accessoriesPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, accessoriesPulldownButtonData, new List<PushButtonData>() { insertCvdVavData });
			#endregion

			#region Electrical
			//Cables
			PulldownButtonAttr cablesPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Cables",
				Title = "Cables",
				ToolTip = "Cables add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("cables16x16.png"),
				LargeImage = Tools.LoadLargeImage("cables32x32.png")
			};
			PulldownButtonData cablesPulldownButtonData = Data.CreatePulldownButtonData(cablesPulldownButtonAttr);
			CreateRibbonPulldownButtons(electricalPanel, cablesPulldownButtonData, new List<PushButtonData>() { cableLengthsData, removeConduitLinesData, calculateLineLengthsData, aCableInfoData });

			//Markers
			PulldownButtonAttr markersPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Markers",
				Title = "Markers",
				ToolTip = "Markers add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("markers16x16.png"),
				LargeImage = Tools.LoadLargeImage("markers32x32.png")
			};
			PulldownButtonData markersPulldownButtonData = Data.CreatePulldownButtonData(markersPulldownButtonAttr);
			CreateRibbonPulldownButtons(electricalPanel, markersPulldownButtonData, new List<PushButtonData>() { associateCableMarkerData, createCableMarkersData });
			#endregion

			#region Plumbing
			//Pipe edits
			PulldownButtonAttr pipeEditsPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Pipe edits",
				Title = "Pipe\redits",
				ToolTip = "Pipe edits add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("pipeEdits16x16.png"),
				LargeImage = Tools.LoadLargeImage("pipeEdits32x32.png")
			};
			PulldownButtonData pipeEditsPulldownButtonData = Data.CreatePulldownButtonData(pipeEditsPulldownButtonAttr);
			CreateRibbonPulldownButtons(plumbingPanel, pipeEditsPulldownButtonData, new List<PushButtonData>() { replaceReductionData, weldSaddleDiametersData });

			//Pipe splits
			PulldownButtonAttr pipeSplitsPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Pipe splits",
				Title = "Pipe\rsplits",
				ToolTip = "Pipe splits add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("pipeSplits16x16.png"),
				LargeImage = Tools.LoadLargeImage("pipeSplits32x32.png")
			};
			PulldownButtonData pipeSplitsPulldownButtonData = Data.CreatePulldownButtonData(pipeSplitsPulldownButtonAttr);
			CreateRibbonPulldownButtons(plumbingPanel, pipeSplitsPulldownButtonData, new List<PushButtonData>() { pprctSplit3mData, pprctSplit4mData, pprctSplitAll3mData, pprctSplitAll4mData });

			//Connections
			PulldownButtonAttr connectionsPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Connections",
				Title = "Connections",
				ToolTip = "Connections add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("connections16x16.png"),
				LargeImage = Tools.LoadLargeImage("connections32x32.png")
			};
			PulldownButtonData connectionsPulldownButtonData = Data.CreatePulldownButtonData(connectionsPulldownButtonAttr);
			CreateRibbonPulldownButtons(plumbingPanel, connectionsPulldownButtonData, new List<PushButtonData>() { flexPipeConnectionData, connectTapHpcData });

			//Incubators piping
			PulldownButtonAttr incubatorsPipingPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Incubators piping",
				Title = "Incubators\rpiping",
				ToolTip = "Incubators piping add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("incubatorsPiping16x16.png"),
				LargeImage = Tools.LoadLargeImage("incubatorsPiping32x32.png")
			};
			PulldownButtonData incubatorsPipingPulldownButtonData = Data.CreatePulldownButtonData(incubatorsPipingPulldownButtonAttr);
			CreateRibbonPulldownButtons(plumbingPanel, incubatorsPipingPulldownButtonData, new List<PushButtonData>() { piping2dDetailData });
			#endregion

			#region Data
			//Data to compare
			PulldownButtonAttr dataComparePulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Data compare",
				Title = "Data\rcompare",
				ToolTip = "Data compare add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("dataCompare16x16.png"),
				LargeImage = Tools.LoadLargeImage("dataCompare32x32.png")
			};
			PulldownButtonData dataComparePulldownButtonData = Data.CreatePulldownButtonData(dataComparePulldownButtonAttr);
			CreateRibbonPulldownButtons(dataPanel, dataComparePulldownButtonData, new List<PushButtonData>() { dataGridData, cableDataData });

			//Data to export
			PulldownButtonAttr dataExportPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Data export",
				Title = "Data\rexport",
				ToolTip = "Data export add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("dataExport16x16.png"),
				LargeImage = Tools.LoadLargeImage("dataExport32x32.png")
			};
			PulldownButtonData dataExportPulldownButtonData = Data.CreatePulldownButtonData(dataExportPulldownButtonAttr);
			CreateRibbonPulldownButtons(dataPanel, dataExportPulldownButtonData, new List<PushButtonData>() { DwfxDwgPdfData, bumperLengthsData, translationsData, eagleEyeLayoutsData });

			//Data to validate
			PulldownButtonAttr dataValidationPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Data validation",
				Title = "Data\rvalidation",
				ToolTip = "Data validation add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("dataValidation16x16.png"),
				LargeImage = Tools.LoadLargeImage("dataValidation32x32.png")
			};
			PulldownButtonData dataValidationPulldownButtonData = Data.CreatePulldownButtonData(dataValidationPulldownButtonAttr);
			CreateRibbonPulldownButtons(dataPanel, dataValidationPulldownButtonData, new List<PushButtonData>() { checkingToolsData });
			#endregion

			#region Plan
			//Revit shortcuts
			PulldownButtonAttr revitShortcutsPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Revit shortcuts",
				Title = "Revit\rshortcuts",
				ToolTip = "Revit shortcuts add-ins",
				LongDescription = "",
				Image = Tools.LoadImage("revitShortcuts16x16.png"),
				LargeImage = Tools.LoadLargeImage("revitShortcuts32x32.png")
			};
			PulldownButtonData revitShortcutsPulldownButtonData = Data.CreatePulldownButtonData(revitShortcutsPulldownButtonAttr);
			CreateRibbonPulldownButtons(planPanel, revitShortcutsPulldownButtonData, new List<PushButtonData>() { centerRoomsTagsData, structureSelectorData, renumberDuctSystemData });
			
			CreateRibbonPushButton(planPanel, weekplanningData);

			CreateRibbonPushButton(planPanel, familyReadParameterData);

			CreateRibbonPushButton(planPanel, familyUpgradeData);
			#endregion

			#region Testing
			
			#endregion

			#endregion

			return Result.Succeeded;
		}

		public Result OnShutdown(UIControlledApplication application)
		{
			return Result.Succeeded;
		}

		#region Buttons data
		
		#endregion

		#region Ribbon buttons
		/// <summary>
		/// A PushButton is a simple button control that triggers an external command when clicked.
		/// </summary>
		private void CreateRibbonPushButton(RibbonPanel ribbonPanel, PushButtonData pushButtonData)
		{
			PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
		}

		/// <summary>
		/// A SplitButton is a button control that consists of two parts: a primary button and a drop-down menu.
		/// The primary button triggers an external command, while the drop-down menu provides additional commands.
		/// </summary>
		private void CreateRibbonSplitButtons(RibbonPanel ribbonPanel, SplitButtonData splitButtonData, List<PushButtonData> pushButtonDatas)
		{
			SplitButton splitButton = ribbonPanel.AddItem(splitButtonData) as SplitButton;
			foreach (PushButtonData pushButtonData in pushButtonDatas)
			{
				splitButton.AddPushButton(pushButtonData);
			}
		}

		/// <summary>
		/// A PulldownButton is a button control that displays a drop-down menu with additional commands when clicked.
		/// </summary>
		private void CreateRibbonPulldownButtons(RibbonPanel ribbonPanel, PulldownButtonData pulldownButtonData, List<PushButtonData> pushButtonDatas)
		{
			PulldownButton pullDownButton = ribbonPanel.AddItem(pulldownButtonData) as PulldownButton;
			foreach (PushButtonData pushButtonData in pushButtonDatas)
			{
				pullDownButton.AddPushButton(pushButtonData);
			}
		}


		/// <summary>
		/// A ComboBox is a drop-down control that allows users to select an item from a list.
		/// </summary>
		void CreateComboBox(RibbonPanel ribbonPanel)
		{
			ComboBoxData comboBoxData = new ComboBoxData("MyComboBox");
			Autodesk.Revit.UI.ComboBox comboBox = ribbonPanel.AddItem(comboBoxData) as Autodesk.Revit.UI.ComboBox;

			// Add items to the ComboBox
			ComboBoxMemberData item1 = new ComboBoxMemberData("Item1", "Item 1");
			ComboBoxMemberData item2 = new ComboBoxMemberData("Item2", "Item 2");
			comboBox.AddItem(item1);
			comboBox.AddItem(item2);

			// Set the ComboBox event handler
			comboBox.CurrentChanged += ComboBox_CurrentChanged;

			// Event handler method
			void ComboBox_CurrentChanged(object sender, ComboBoxCurrentChangedEventArgs e)
			{
				// Handle the ComboBox item selection
				ComboBoxMember selectedMember = e.NewValue;

				// Handle the selected item (e.g., perform a specific action or set a parameter)
				switch (selectedMember.Name)
				{
					case "Item1":
						TaskDialog.Show("Revit Add-in", "Hello from item 1");
						break;
					case "Item2":
						TaskDialog.Show("Revit Add-in", "Hello from item 2");
						break;
					default:
						break;
				}
			}
		}

		/// <summary>
		/// A TextBox is a control that allows users to enter text.
		/// </summary>
		void CreateTextBox(RibbonPanel ribbonPanel)
		{
			TextBoxData textBoxData = new TextBoxData("MyTextBox");
			Autodesk.Revit.UI.TextBox textBox = ribbonPanel.AddItem(textBoxData) as TextBox;
		}
		#endregion
	}
}