using AddinManager.Attributes;
using Autodesk.Revit.UI;

namespace AddinManager.Buttons
{
	public static class ButtonStructure
	{
		public static PushButtonData CreatePushButtonData(AddinAttr buttonAttr)
		{
			PushButtonData pushButtonData = new PushButtonData(buttonAttr.Name, buttonAttr.Title, buttonAttr.AssemblyPath, buttonAttr.ClassName)
			{
				ToolTip = buttonAttr.ToolTip,
				LongDescription = buttonAttr.LongDescription,
				Image = buttonAttr.Image,
				LargeImage = buttonAttr.LargeImage
			};
			pushButtonData.SetContextualHelp(buttonAttr.Help);

			return pushButtonData;
		}

		public static SplitButtonData CreateSplitButtonData(SplitButtonAttr splitButtonAttr)
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

		public static PulldownButtonData CreatePulldownButtonData(PulldownButtonAttr pulldownButtonAttr)
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
	}
}
