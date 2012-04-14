using System;
using System.Collections.Generic;
using System.Text;

namespace Outlook_1.Business
{
	class AppointmentVO
	{
		//This class wraps in the PocketOutlook Appointment object and exposes some properties.
//The class is also used for adding contextbased information to the PocketOutlook object.      
        
		public AppointmentVO ()
		{
			_Id = "";
			_Subject = "";
			_Category = "1,2";
			_Start = "";
			Duration = "";
			_Sensitivity = "";
		}

		public AppointmentVO (Microsoft.WindowsMobile.PocketOutlook.Appointment app)
		{
			if (app != null) {
				_Id = app.ItemId.ToString ();
				_Subject = app.Subject;
				if (app.Categories != null)
					_Category = app.Categories;
				else
					_Category = "1,2";
				_Start = app.Start.ToShortTimeString ();
				_Duration = app.Duration.Hours.ToString ();
				_Sensitivity = app.Sensitivity.ToString ();
			}
		}

		public AppointmentVO (string id, string sub, string cat, string st, string dur, string sens)
		{
			_Id = id;
			_Subject = sub;
			_Category = cat;
			_Start = st;
			_Duration = dur;
			_Sensitivity = sens;
		}
//Unique id
		private string id;

		public string _Id {
			get { return id; }
			set { id = value; }
		}
//Appointment subject
		private string subject;

		public string _Subject {
			get { return subject; }
			set { subject = value; }
		}
//Appointment sensitivity
		private string sensitivity;

		public string _Sensitivity {
			get { return sensitivity; }
			set { sensitivity = value; }
		}
		//category 
		private string category;

		public string _Category {
			get { return category; }
			set { category = value; }
		}
//TableOfCategories
		public string[] getCategoryTab ()
		{
			try {
				return category.Split (new Char[] { ',' });
			} catch (Exception ex) {
				Logger.LogEvent ("Error in AppointmentVO :" + ex.Message);
				return new string[] {"1","2"};
			}
		}
//start time
		private string start;

		public string _Start {
			get { return start; }
			set { start = value; }
		}
//duartation
		private string duartion;

		public string _Duration {
			get { return duartion; }
			set { duartion = value; }
		}
	}
}