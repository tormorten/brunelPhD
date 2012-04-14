using System;
using System.Collections.Generic;
using System.Text;

namespace Outlook_1
{
	class MobileException : Exception
	{
		private string message;

		public new string Message {
			get { return message; }
		}

		public MobileException ()
		{
			throw new Exception ("Udefined custom exception");
		}

		public MobileException (string msg)
		{
			message = msg;
			throw new Exception (msg);
		}
	}
}