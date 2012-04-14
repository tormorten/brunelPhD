using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Outlook_1
{
	static class Program
	{
		/// Startup class for the application.
		[MTAThread]
		static void Main ()
		{
			Application.Run (new Gui.Startup ());
		}
	}
}