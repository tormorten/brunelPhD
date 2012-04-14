using System;
using System.Collections.Generic;
using System.Text;

namespace Outlook_1.Business
{
	public static class Logger
	{
		//Logging strings to local text file on device
		public static void LogEvent (String msg)
		{
			try {
				string fileName = 
System.DateTime.Today.ToShortDateString ();
				System.IO.StreamWriter outStream = new 
System.IO.StreamWriter (@"\Temp\" + fileName + ".txt", true);
				outStream.WriteLine (System.DateTime.Now.Hour + "-" + 
System.DateTime.Now.Minute + "-" + System.DateTime.Now.Second);
				outStream.WriteLine (msg);
				outStream.WriteLine ("\r\n");
				outStream.Flush ();
				outStream.Close ();
			} catch (Exception ex) {
				//do nothing, will not let Logger cause system failure
				string temp = ex.Message;
			}
		}
	}
}