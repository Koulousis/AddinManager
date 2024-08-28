using Autodesk.Revit.UI.Events;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddinManager.Buttons
{
	public static class Ribbon
	{
		/// <summary>
		/// A PushButton is a simple button control that triggers an external command when clicked.
		/// </summary>
		public static void CreateRibbonPushButton(RibbonPanel ribbonPanel, PushButtonData pushButtonData)
		{
			PushButton pushButton = ribbonPanel.AddItem(pushButtonData) as PushButton;
		}

		/// <summary>
		/// A SplitButton is a button control that consists of two parts: a primary button and a drop-down menu.
		/// The primary button triggers an external command, while the drop-down menu provides additional commands.
		/// </summary>
		public static void CreateRibbonSplitButtons(RibbonPanel ribbonPanel, SplitButtonData splitButtonData, List<PushButtonData> pushButtonDatas)
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
		public static void CreateRibbonPulldownButtons(RibbonPanel ribbonPanel, PulldownButtonData pulldownButtonData, List<PushButtonData> pushButtonDatas)
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
		public static void CreateComboBox(RibbonPanel ribbonPanel)
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
		public static void CreateTextBox(RibbonPanel ribbonPanel)
		{
			TextBoxData textBoxData = new TextBoxData("MyTextBox");
			Autodesk.Revit.UI.TextBox textBox = ribbonPanel.AddItem(textBoxData) as TextBox;
		}
	}
}
