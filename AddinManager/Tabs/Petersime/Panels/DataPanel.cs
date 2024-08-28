using AddinManager.Attributes;
using AddinManager.Misc;
using AddinManager.Resources;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddinManager.Buttons;

namespace AddinManager.Tabs.Petersime.Panels
{
	public static class Data
	{
		public static void DefineAddins()
		{
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
			PushButtonData dataGridData = Buttons.ButtonStructure.CreatePushButtonData(dataGridAttr);

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
			PushButtonData cableDataData = Buttons.ButtonStructure.CreatePushButtonData(cableDataAttr);
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
			PushButtonData DwfxDwgPdfData = Buttons.ButtonStructure.CreatePushButtonData(DwfxDwgPdfAttr);

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
			PushButtonData bumperLengthsData = Buttons.ButtonStructure.CreatePushButtonData(bumperLengthsAttr);

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
			PushButtonData translationsData = Buttons.ButtonStructure.CreatePushButtonData(translationsAttr);

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
			PushButtonData eagleEyeLayoutsData = Buttons.ButtonStructure.CreatePushButtonData(eagleEyeLayoutsAttr);
			
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
			PushButtonData checkingToolsData = Buttons.ButtonStructure.CreatePushButtonData(checkingToolsAttr);
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
			PushButtonData centerRoomsTagsData = Buttons.ButtonStructure.CreatePushButtonData(centerRoomsTagsAttr);

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
			PushButtonData structureSelectorData = Buttons.ButtonStructure.CreatePushButtonData(structureSelectorAttr);

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
			PushButtonData renumberDuctSystemData = Buttons.ButtonStructure.CreatePushButtonData(renumberDuctSystemAttr);
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
			PushButtonData weekplanningData = Buttons.ButtonStructure.CreatePushButtonData(weekplanningAttr);

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
			PushButtonData familyReadParameterData = Buttons.ButtonStructure.CreatePushButtonData(familyReadParameterAttr);

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
			PushButtonData familyUpgradeData = Buttons.ButtonStructure.CreatePushButtonData(familyUpgradeAttr);

			#endregion

			#endregion
		}
	}
}
