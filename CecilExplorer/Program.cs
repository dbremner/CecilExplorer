﻿using System;
using Unclassified.Util;

namespace CecilExplorer
{
	internal class Program
	{
		/// <summary>
		/// Application entry point.
		/// </summary>
		/// <remarks>
		/// The App class is set to the build action "ApplicationDefinition" which also generates a
		/// Main method suitable as application entry point. Therefore, this class must be selected
		/// as start object in the project configuration. If the App class was set up otherwise,
		/// Visual Studio would not find the application-wide resources in the App.xaml file and
		/// mark all such StaticResource occurences in XAML files as an error.
		/// </remarks>
		[STAThread]
		public static void Main()
		{
			App.InitializeSettings();

			// Make sure the settings are properly saved in the end
			AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;

			InitializeLocalisation();

			// Keep the setup away
			GlobalMutex.Create("Unclassified.CecilExplorer");

			App app = new App();
			app.InitializeComponent();
			app.Run();
		}

		/// <summary>
		/// Called when the current process exits.
		/// </summary>
		/// <remarks>
		/// The processing time in this event is limited. All handlers of this event together must
		/// not take more than ca. 3 seconds. The processing will then be terminated.
		/// </remarks>
		private static void CurrentDomain_ProcessExit(object sender, EventArgs args)
		{
			if (App.Settings != null)
			{
				App.Settings.SettingsStore.Dispose();
			}
		}

		private static void InitializeLocalisation()
		{
		}
	}
}
