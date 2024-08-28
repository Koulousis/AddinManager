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
using AddinManager.Tabs.Petersime.Panels;
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

			MechanicalPanel.DefineAddins();

			ElectricalPanel.DefineAddins();

			PlumbingPanel.DefineAddins();



			

			#region Testing
			
			#endregion

			#endregion

			#region UI Elements
			//Ribbon panel
			application.CreateRibbonTab("Petersime");

			RibbonPanel mechanicalPanel = application.CreateRibbonPanel("Petersime", "MechanicalPanel");
			RibbonPanel electricalPanel = application.CreateRibbonPanel("Petersime", "ElectricalPanel");
			RibbonPanel plumbingPanel = application.CreateRibbonPanel("Petersime", "PlumbingPanel");
			RibbonPanel dataPanel = application.CreateRibbonPanel("Petersime", "Data");
			RibbonPanel planPanel = application.CreateRibbonPanel("Petersime", "Plan");

			#region MechanicalPanel
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
			PulldownButtonData suspensionPulldownButtonData = ButtonStructure.CreatePulldownButtonData(suspensionPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(mechanicalPanel, suspensionPulldownButtonData, new List<PushButtonData>() { odmBracketsData, r7RailsData, ductThroughCeilingData, ductThroughWallData, ventilatorOnDuctData, quantitiesData, takeOffMainDiametersData });

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
			PulldownButtonData ductSplitPulldownButtonData = ButtonStructure.CreatePulldownButtonData(ductSplitPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(mechanicalPanel, ductSplitPulldownButtonData, new List<PushButtonData>() { ductSplitData, rtDuctSplitData });

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
			PulldownButtonData exhaustsPulldownButtonData = ButtonStructure.CreatePulldownButtonData(exhaustsPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(mechanicalPanel, exhaustsPulldownButtonData, new List<PushButtonData>() { exhaustRunData, exhaustOffsetData });

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
			PulldownButtonData ahuPulldownButtonData = ButtonStructure.CreatePulldownButtonData(ahuPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(mechanicalPanel, ahuPulldownButtonData, new List<PushButtonData>() { ahuEditorData, create3DViewData });

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
			PulldownButtonData accessoriesPulldownButtonData = ButtonStructure.CreatePulldownButtonData(accessoriesPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(mechanicalPanel, accessoriesPulldownButtonData, new List<PushButtonData>() { insertCvdVavData });
			#endregion

			#region ElectricalPanel
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
			PulldownButtonData cablesPulldownButtonData = ButtonStructure.CreatePulldownButtonData(cablesPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(electricalPanel, cablesPulldownButtonData, new List<PushButtonData>() { cableLengthsData, removeConduitLinesData, calculateLineLengthsData, aCableInfoData });

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
			PulldownButtonData markersPulldownButtonData = ButtonStructure.CreatePulldownButtonData(markersPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(electricalPanel, markersPulldownButtonData, new List<PushButtonData>() { associateCableMarkerData, createCableMarkersData });
			#endregion

			#region PlumbingPanel
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
			PulldownButtonData pipeEditsPulldownButtonData = ButtonStructure.CreatePulldownButtonData(pipeEditsPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(plumbingPanel, pipeEditsPulldownButtonData, new List<PushButtonData>() { replaceReductionData, weldSaddleDiametersData });

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
			PulldownButtonData pipeSplitsPulldownButtonData = ButtonStructure.CreatePulldownButtonData(pipeSplitsPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(plumbingPanel, pipeSplitsPulldownButtonData, new List<PushButtonData>() { pprctSplit3mData, pprctSplit4mData, pprctSplitAll3mData, pprctSplitAll4mData });

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
			PulldownButtonData connectionsPulldownButtonData = ButtonStructure.CreatePulldownButtonData(connectionsPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(plumbingPanel, connectionsPulldownButtonData, new List<PushButtonData>() { flexPipeConnectionData, connectTapHpcData });

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
			PulldownButtonData incubatorsPipingPulldownButtonData = ButtonStructure.CreatePulldownButtonData(incubatorsPipingPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(plumbingPanel, incubatorsPipingPulldownButtonData, new List<PushButtonData>() { piping2dDetailData });
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
			PulldownButtonData dataComparePulldownButtonData = ButtonStructure.CreatePulldownButtonData(dataComparePulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(dataPanel, dataComparePulldownButtonData, new List<PushButtonData>() { dataGridData, cableDataData });

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
			PulldownButtonData dataExportPulldownButtonData = ButtonStructure.CreatePulldownButtonData(dataExportPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(dataPanel, dataExportPulldownButtonData, new List<PushButtonData>() { DwfxDwgPdfData, bumperLengthsData, translationsData, eagleEyeLayoutsData });

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
			PulldownButtonData dataValidationPulldownButtonData = ButtonStructure.CreatePulldownButtonData(dataValidationPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(dataPanel, dataValidationPulldownButtonData, new List<PushButtonData>() { checkingToolsData });
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
			PulldownButtonData revitShortcutsPulldownButtonData = ButtonStructure.CreatePulldownButtonData(revitShortcutsPulldownButtonAttr);
			Ribbon.CreateRibbonPulldownButtons(planPanel, revitShortcutsPulldownButtonData, new List<PushButtonData>() { centerRoomsTagsData, structureSelectorData, renumberDuctSystemData });
			
			Ribbon.CreateRibbonPushButton(planPanel, weekplanningData);

			Ribbon.CreateRibbonPushButton(planPanel, familyReadParameterData);

			Ribbon.CreateRibbonPushButton(planPanel, familyUpgradeData);
			#endregion
			
			#endregion

			return Result.Succeeded;
		}

		public Result OnShutdown(UIControlledApplication application)
		{
			return Result.Succeeded;
		}
	}
}