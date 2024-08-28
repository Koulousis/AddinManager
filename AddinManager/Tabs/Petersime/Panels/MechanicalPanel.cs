using AddinManager.Attributes;
using AddinManager.Resources;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddinManager.Buttons;
using AddinManager.Misc;

namespace AddinManager.Tabs.Petersime.Panels
{
	public static class MechanicalPanel
	{
		public static void DefineAddins()
		{
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
			PushButtonData odmBracketsData = ButtonStructure.CreatePushButtonData(odmBracketsAttr);

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
			PushButtonData r7RailsData = ButtonStructure.CreatePushButtonData(r7RailsAttr);

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
			PushButtonData ductThroughCeilingData = ButtonStructure.CreatePushButtonData(ductThroughCeilingAttr);

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
			PushButtonData ductThroughWallData = ButtonStructure.CreatePushButtonData(ductThroughWallAttr);

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
			PushButtonData ventilatorOnDuctData = ButtonStructure.CreatePushButtonData(ventilatorOnDuctAttr);

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
			PushButtonData quantitiesData = ButtonStructure.CreatePushButtonData(quantitiesAttr);

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
			PushButtonData takeOffMainDiametersData = ButtonStructure.CreatePushButtonData(takeOffMainDiametersAttr);
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
			PushButtonData ductSplitData = ButtonStructure.CreatePushButtonData(ductSplitAttr);

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
			PushButtonData rtDuctSplitData = ButtonStructure.CreatePushButtonData(rtDuctSplitAttr);
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
			PushButtonData exhaustRunData = ButtonStructure.CreatePushButtonData(exhaustRunAttr);

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
			PushButtonData exhaustOffsetData = ButtonStructure.CreatePushButtonData(exhaustOffsetAttr);
			#endregion

			#region AHU
			//Add-in AHU editor
			AddinAttr ahuEditorAttr = new AddinAttr()
			{
				Name = "AHU editor",
				Title = "AHU editor",
				AssemblyPath = $@"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Projects\MechanicalPanel\mechanical-ahu-editor\AhuEditor\bin\Debug\AhuEditor.dll",
				ClassName = "AhuEditor.Command",
				ToolTip = "AHU Editor window",
				LongDescription = "",
				Image = Tools.LoadImage("ahuEditor16x16.png"),
				LargeImage = Tools.LoadLargeImage("ahuEditor32x32.png"),
				Help = new ContextualHelp(ContextualHelpType.Url, $@"{Directories.Guidelines}\AHU editor.pdf")
			};
			PushButtonData ahuEditorData = ButtonStructure.CreatePushButtonData(ahuEditorAttr);

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
			PushButtonData create3DViewData = ButtonStructure.CreatePushButtonData(create3DViewAttr);
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
			PushButtonData insertCvdVavData = ButtonStructure.CreatePushButtonData(insertCvdVavAttr);
			#endregion
		}
	}
}
