using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace RevitPanel
{
	public static class DebugHelper
	{
		public static void LaunchDebuggerForUser()
		{
			// Define allowed usernames and machine names
			string[] allowedUsers = { "Lunar", "AKoulousis" };
			string[] allowedMachines = { "ARISTOTELIS" , "WS-AKOULOUSIS" };

			string currentUser = Environment.UserName;
			string currentMachine = Environment.MachineName;

			// Check if debugger is already attached, and if user AND machine match
			if (!Debugger.IsAttached &&
			    Array.Exists(allowedUsers, u => u.Equals(currentUser, StringComparison.OrdinalIgnoreCase)) &&
			    Array.Exists(allowedMachines, m => m.Equals(currentMachine, StringComparison.OrdinalIgnoreCase)))
			{
				if (MessageBox.Show("Launch debugger for " + Assembly.GetExecutingAssembly().GetName().Name, "DEBUG?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					Debugger.Launch();
			}
		}
	}
}
