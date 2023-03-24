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
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

namespace RevitPanel
{
	public class Panel : IExternalApplication
	{
		public Result OnStartup(UIControlledApplication application)
		{
			#region Add-ins
			//Add-in Structure Selector
			AddinAttr structureSelectorAttr = new AddinAttr()
			{
				Name = "Structure Selector",
				Title = "Structure Selector",
				AssemblyPath = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\DLLs\StructureSelector.dll",
				ClassName = "StructureSelector.Command",
				ToolTip = "Steel structure selector help the user to select a group of structure components",
				LongDescription = "Steel structure selector provides a form where steel structure components are grouped by type and by clicking a button, triggers" +
				                  "revit to select all the components related to the group name",
				Image = File.Exists(GetImagePath("structureSelector16x16.png")) ? new BitmapImage(new Uri(GetImagePath("structureSelector16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("structureSelector32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("structureSelector32x32.png"))) : null
			};
			PushButtonData structureSelectorData = CreateButtonData(structureSelectorAttr);

			//Add-in ODM Brackets
			AddinAttr odmBracketsAttr = new AddinAttr()
			{
				Name = "ODM Brackets",
				Title = "ODM Brackets",
				AssemblyPath = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\DLLs\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.ODMbrackets",
				ToolTip = "Place all the suspension markers for ODM brackets + distance to roof",
				LongDescription = "",
				Image = File.Exists(GetImagePath("odmBrackets16x16.png")) ? new BitmapImage(new Uri(GetImagePath("odmBrackets16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("odmBrackets32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("odmBrackets32x32.png"))) : null
			};
			PushButtonData odmBracketsData = CreateButtonData(odmBracketsAttr);

			//Add-in R7 Rails
			AddinAttr r7RailsAttr = new AddinAttr()
			{
				Name = "R7 Rails",
				Title = "R7 Rails",
				AssemblyPath = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\DLLs\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.R7Rails",
				ToolTip = "Place all the suspension markers for R7 rails under rectangular ducts + distance to roof",
				LongDescription = "",
				Image = File.Exists(GetImagePath("r7Rails16x16.png")) ? new BitmapImage(new Uri(GetImagePath("r7Rails16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("r7Rails32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("r7Rails32x32.png"))) : null
			};
			PushButtonData r7RailsData = CreateButtonData(r7RailsAttr);

			//Add-in Duct through ceiling
			AddinAttr ductThroughCeilingAttr = new AddinAttr()
			{
				Name = "Duct through ceiling",
				Title = "Duct through ceiling",
				AssemblyPath = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\DLLs\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.DuctTroughCeiling",
				ToolTip = "Place all the suspension markers for R7 rails under rectangular ducts + distance to roof",
				LongDescription = "",
				Image = File.Exists(GetImagePath("ductThroughCeiling16x16.png")) ? new BitmapImage(new Uri(GetImagePath("ductThroughCeiling16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("ductThroughCeiling32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("ductThroughCeiling32x32.png"))) : null
			};
			PushButtonData ductThroughCeilingData = CreateButtonData(ductThroughCeilingAttr);

			//Add-in Duct through wall
			AddinAttr ductThroughWallAttr = new AddinAttr()
			{
				Name = "Duct through wall",
				Title = "Duct through wall",
				AssemblyPath = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\DLLs\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.DuctTroughWall",
				ToolTip = "Place all the suspension markers for ducts through walls",
				LongDescription = "",
				Image = File.Exists(GetImagePath("ductThroughWall16x16.png")) ? new BitmapImage(new Uri(GetImagePath("ductThroughWall16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("ductThroughWall32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("ductThroughWall32x32.png"))) : null
			};
			PushButtonData ductThroughWallData = CreateButtonData(ductThroughWallAttr);

			//Add-in Ventilator on duct
			AddinAttr ventilatorOnDuctAttr = new AddinAttr()
			{
				Name = "Ventilator on duct",
				Title = "Ventilator on duct",
				AssemblyPath = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\DLLs\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.VentilatorOnDuct",
				ToolTip = "Place all the suspension markers for ventilators on ducts",
				LongDescription = "",
				Image = File.Exists(GetImagePath("ventilatorOnDuct16x16.png")) ? new BitmapImage(new Uri(GetImagePath("ventilatorOnDuct16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("ventilatorOnDuct32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("ventilatorOnDuct32x32.png"))) : null
			};
			PushButtonData ventilatorOnDuctData = CreateButtonData(ventilatorOnDuctAttr);

			//Add-in Quantities
			AddinAttr quantitiesAttr = new AddinAttr()
			{
				Name = "Quantities",
				Title = "Quantities",
				AssemblyPath = @"J:\Drawings REVIT FAMILIES\02 NEW\Aris\Addins\PetersimeV2\DLLs\SuspensionMarkers.dll",
				ClassName = "SuspensionMarkers.Quantities",
				ToolTip = "Fill in total quantities",
				LongDescription = "",
				Image = File.Exists(GetImagePath("quantities16x16.png")) ? new BitmapImage(new Uri(GetImagePath("quantities16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("quantities32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("quantities32x32.png"))) : null
			};
			PushButtonData quantitiesData = CreateButtonData(quantitiesAttr);
			#endregion

			#region UI Elements
			//Ribbon panel
			application.CreateRibbonTab("Petersime");
			RibbonPanel toolsPanel = application.CreateRibbonPanel("Petersime", "Tools");
			RibbonPanel mechanicalPanel = application.CreateRibbonPanel("Petersime", "Mechanical");
			RibbonPanel electricalPanel = application.CreateRibbonPanel("Petersime", "Electrical");
			RibbonPanel plumbingPanel = application.CreateRibbonPanel("Petersime", "Plumbing");
			RibbonPanel dataPanel = application.CreateRibbonPanel("Petersime", "Data");
			RibbonPanel planPanel = application.CreateRibbonPanel("Petersime", "Plan");

			//Push buttons
			CreateRibbonPushButton(toolsPanel, structureSelectorData);
			
			//Pulldown buttons
			//Suspension
			PulldownButtonAttr suspensionPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Suspension",
				Title = "Suspension",
				ToolTip = "Suspension add-ins",
				LongDescription = "",
				Image = File.Exists(GetImagePath("suspension16x16.png")) ? new BitmapImage(new Uri(GetImagePath("suspension16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("suspension32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("suspension32x32.png"))) : null
			};
			PulldownButtonData suspensionPulldownButtonData = CreatePulldownButtonData(suspensionPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, suspensionPulldownButtonData, new List<PushButtonData>() { odmBracketsData, r7RailsData, ductThroughCeilingData, ductThroughWallData, ventilatorOnDuctData, quantitiesData });

			//Duct split
			PulldownButtonAttr ductSplitPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Duct split",
				Title = "Duct split",
				ToolTip = "Duct split add-ins",
				LongDescription = "",
				Image = File.Exists(GetImagePath("ductSplit16x16.png")) ? new BitmapImage(new Uri(GetImagePath("ductSplit16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("ductSplit32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("ductSplit32x32.png"))) : null
			};
			PulldownButtonData ductSplitPulldownButtonData = CreatePulldownButtonData(ductSplitPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, ductSplitPulldownButtonData, new List<PushButtonData>() { });

			//Exhausts
			PulldownButtonAttr exhaustsPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Exhausts",
				Title = "Exhausts",
				ToolTip = "Exhausts add-ins",
				LongDescription = "",
				Image = File.Exists(GetImagePath("exhausts16x16.png")) ? new BitmapImage(new Uri(GetImagePath("exhausts16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("exhausts32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("exhausts32x32.png"))) : null
			};
			PulldownButtonData exhaustsPulldownButtonData = CreatePulldownButtonData(exhaustsPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, exhaustsPulldownButtonData, new List<PushButtonData>() { });

			//AHU
			PulldownButtonAttr ahuPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "AHU",
				Title = "AHU",
				ToolTip = "AHU add-ins",
				LongDescription = "",
				Image = File.Exists(GetImagePath("ahu16x16.png")) ? new BitmapImage(new Uri(GetImagePath("ahu16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("ahu32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("ahu32x32.png"))) : null
			};
			PulldownButtonData ahuPulldownButtonData = CreatePulldownButtonData(ahuPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, ahuPulldownButtonData, new List<PushButtonData>() { });

			//Accessories
			PulldownButtonAttr accessoriesPulldownButtonAttr = new PulldownButtonAttr()
			{
				Name = "Accessories",
				Title = "Accessories",
				ToolTip = "Accessories add-ins",
				LongDescription = "",
				Image = File.Exists(GetImagePath("ahu16x16.png")) ? new BitmapImage(new Uri(GetImagePath("ahu16x16.png"))) : null,
				LargeImage = File.Exists(GetLargeImagePath("ahu32x32.png")) ? new BitmapImage(new Uri(GetLargeImagePath("ahu32x32.png"))) : null
			};
			PulldownButtonData accessoriesPulldownButtonData = CreatePulldownButtonData(accessoriesPulldownButtonAttr);
			CreateRibbonPulldownButtons(mechanicalPanel, accessoriesPulldownButtonData, new List<PushButtonData>() { });
			#endregion

			return Result.Succeeded;
		}

		public Result OnShutdown(UIControlledApplication application)
		{
			return Result.Succeeded;
		}

		#region Buttons data
		PushButtonData CreateButtonData(AddinAttr buttonAttr)
		{
			PushButtonData pushButtonData = new PushButtonData(buttonAttr.Name, buttonAttr.Title, buttonAttr.AssemblyPath, buttonAttr.ClassName)
			{
				ToolTip = buttonAttr.ToolTip,
				LongDescription = buttonAttr.LongDescription,
				Image = buttonAttr.Image,
				LargeImage = buttonAttr.LargeImage
			};

			return pushButtonData;
		}

		SplitButtonData CreateSplitButtonData(SplitButtonAttr splitButtonAttr)
		{
			SplitButtonData splitButtonData = new SplitButtonData(splitButtonAttr.Name, splitButtonAttr.Title)
			{
				ToolTip = splitButtonAttr.ToolTip,
				LongDescription = splitButtonAttr.LongDescription,
				Image = splitButtonAttr.Image,
				LargeImage = splitButtonAttr.LargeImage
			};

			return splitButtonData;
		}

		PulldownButtonData CreatePulldownButtonData(PulldownButtonAttr pulldownButtonAttr)
		{
			PulldownButtonData pulldownButtonData = new PulldownButtonData(pulldownButtonAttr.Name, pulldownButtonAttr.Title)
			{
				ToolTip = pulldownButtonAttr.ToolTip,
				LongDescription = pulldownButtonAttr.LongDescription,
				Image = pulldownButtonAttr.Image,
				LargeImage = pulldownButtonAttr.LargeImage
			};

			return pulldownButtonData;
		}
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

		#region Other methods
		private string GetImagePath(string imageName)
		{
			string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string imagePath = Path.Combine(assemblyDirectory, "Images", imageName);

			return imagePath;
		}

		private string GetLargeImagePath(string largeImageName)
		{
			string assemblyDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
			string largeImagePath = Path.Combine(assemblyDirectory, "LargeImages", largeImageName);

			return largeImagePath;
		}
		#endregion
	}
}