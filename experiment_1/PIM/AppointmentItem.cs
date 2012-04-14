using System;
using System.Collections;
using System.Text;

//Import Microsoft Outlook libraries
using Microsoft.WindowsMobile;
using Microsoft.WindowsMobile.PocketOutlook;

namespace Outlook_1.Outlook
{
	class AppointmentInfo
	{
		private OutlookSession Osession;

		public AppointmentInfo ()
		{
			if (Osession == null)
				Osession = new OutlookSession ();
		}

		public Appointment getAppointmentByID (int appID)
		{
			AppointmentCollection appointments = 
Osession.Appointments.Items;
			Appointment appointment = null;
			System.Collections.IEnumerator appIterator = 
appointments.GetEnumerator ();
			while (appIterator.MoveNext()) {
				appointment = (Appointment)appIterator.Current;
				if (appointment.ItemId.ToString () == appID.ToString ()) {
					appointment = (Appointment)appIterator.Current;
					break;
				}
			}
			return appointment;
		}

		public ArrayList getAllNewAppointments ()
		{
			ArrayList alListe = new ArrayList ();
			if (Osession != null) {
				AppointmentCollection appointments = Osession.Appointments.Items;
				foreach (Appointment ap in appointments) {
					//34-36 ok if "Locale" is properly set in device, preferably 24h 
					if (ap.Start > System.DateTime.Now) {
						alListe.Add (new Business.AppointmentVO (
                            ap.ItemId.ToString (), ap.Subject, 
							ap.Categories, ap.Start.ToString (), ap.Duration.ToString (),
							ap.Sensitivity.ToString ()));
					}
				}
				return alListe;
			} else
				throw new MobileException ("oS does not exist");
		}

		public Business.AppointmentVO getNextAppointment ()
		{
			try {
				return 
(Business.AppointmentVO)getAllNewAppointments () [0];
			} catch (IndexOutOfRangeException iorEx) {
				return null;
			} catch (ArgumentOutOfRangeException) {
				return null;
			}
		}

		public Business.AppointmentVO getCurrentAppointment ()
		{
			//Shared resources
			Business.AppointmentVO appVo = null;
		//New implementation
			Appointment currentApp = Microsoft.WindowsMobile.Status.
				SystemState.CalendarAppointment;// CalendarNextAppointment;
			appVo = new Outlook_1.Business.AppointmentVO (currentApp);
			if (appVo == null)
				return new Business.AppointmentVO ();//return new empty 
			else
				return appVo;
		}

		public void deleteAllAppointments ()
		{
			ArrayList al = new ArrayList ();
			if (Osession != null) {
				AppointmentCollection appointments = 
Osession.Appointments.Items;
				foreach (Appointment ap in appointments) {
					al.Add (ap);
				}
				for (int i = 0; i<al.Count; i++) {
					Appointment ap = (Appointment)al [i];
					ap.Delete ();
				}
                    
			} else
				throw new MobileException ("oS does not exist");
		}

		public void deleteAllContacts ()
		{
			ArrayList al = new ArrayList ();
			if (Osession != null) {
				ContactCollection contacts = Osession.Contacts.Items;
				foreach (Contact  ap in contacts) {
					al.Add (ap);
				}
				for (int i = 0; i < al.Count; i++) {
					Contact ap = (Contact)al [i];
					ap.Delete ();
				}
			} else
				throw new MobileException ("oS does not exist");
		}
	}
}