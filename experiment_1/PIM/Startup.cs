using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.InteropServices;
using Microsoft.WindowsMobile.Status;
using Microsoft.WindowsMobile;
using Microsoft.WindowsMobile.PocketOutlook.MessageInterception;
using Microsoft.WindowsCE.Forms;

namespace Outlook_1.Gui
{
	public partial class Startup : Form
	{
		SystemState calendarNewAppointment;
		Microsoft.WindowsCE.Forms.Notification notification;
		private bool notificationStatus = false;
		MessageInterceptor sms;
		private bool firstGPSCoordinate = true;
		private string zoneNameCompare = "";
		private EventHandler updateDataHandler;
		private GpsLib.Gps gps = new GpsLib.Gps ();
		private GpsLib.GpsPosition position = null;
		private GpsLib.GpsDeviceState device = null;
#region startup
		
		public Startup ()
		{
			InitializeComponent ();
			InitListViewComponent ();
			InitZoneComponent ();
			lblSetGps.Text = gps.GetDeviceState().
				DeviceState.ToString ();
			//Following two lines handles entry of new Appointment
			calendarNewAppointment = new SystemState 
				(SystemProperty.CalendarAppointment);
			calendarNewAppointment.Changed += new 
			ChangeEventHandler (calendarApp_Changed);
		}
		
		//Current appointment has changed
		void calendarApp_Changed (object sender, ChangeEventArgs args)
		{
			string testVar = "";
			if (notificationStatus) {
				notification.Visible = true;
				notificationStatus = false;
			}
			Microsoft.WindowsMobile.PocketOutlook.Appointment currentApp 
=
              
(Microsoft.WindowsMobile.PocketOutlook.Appointment)SystemState.CalendarAppointment;
			if (currentApp != null) { //If Null, then current Appointment is deleted
				if (gps != null) {
					if (gps.ZoneObj.getZoneID ().ToString ().Trim () == 
currentApp.Location.ToString ().Trim ())
						generateInformation ();
					else
						testVar = "nyVerdi";
				}
			}
		}

		private void InitZoneComponent ()
		{
			lblSetZone.Text = gps.ZoneObj.ZoneName;
			//true == minimize ok (even X is displayed) else ok showed -closes application
			MinimizeBox = true;
		}

		private void InitListViewComponent ()
		{
			//A header 
			txtStatus.Text = "Upcomming appointments\r\n";
			//Body
			Handlers.AppointmentHandler appHandler = new 
Outlook_1.Handlers.AppointmentHandler ();
			ArrayList alApps = 
(ArrayList)appHandler.getAllNewAppointments ();
			if (alApps.Count == 0) {
				txtStatus.Text = "None";
			} else {
				int counter = 0;
				foreach (Business.AppointmentVO app in alApps) {
					txtStatus.Text += app._Subject + ":\r\n " + 
app._Start + "\r\n";
					counter++;
					if (counter > 10) //Current max number displayed
						break;
				}
			}
			string sInfo = 
((Business.AppointmentVO)appHandler.getCurrentAppointment ())._Category;
			if (sInfo != null)
				lblSetSocial.Text = sInfo;
			else
				lblSetSocial.Text = "N/A";
            
		}
#endregion
        
#region events
		private void Startup_Load (object sender, EventArgs e)
		{
			updateDataHandler = new EventHandler (UpdateData); //This calls the UpdateData(...)
			this.Width = Screen.PrimaryScreen.WorkingArea.Width;
			this.Height = Screen.PrimaryScreen.WorkingArea.Height;
			gps.DeviceStateChanged += new 
			GpsLib.DeviceStateChangedEventHandler (gps_DeviceStateChanged);
			gps.LocationChanged += new 
			GpsLib.LocationChangedEventHandler (gps_LocationChanged);
			//sms
			sms = new MessageInterceptor (InterceptionAction.NotifyAndDelete);
			sms.MessageCondition = new MessageCondition ();
			sms.MessageReceived += new MessageInterceptorEventHandler (sms_MessageReceived);
		}

		protected void gps_LocationChanged (object sender, GpsLib.LocationChangedEventArgs args)
		{
			position = args.Position;
// call the UpdateData method via the updateDataHandler so that we
			// update the UI on the UI thread
			Invoke (updateDataHandler);
         
		}

		void gps_DeviceStateChanged (object sender, 
GpsLib.DeviceStateChangedEventArgs args)
		{
			device = args.DeviceState;
// call the UpdateData method via the updateDataHandler so that we
// update the UI on the UI thread
			Invoke (updateDataHandler);
		}

		private void menuItemExit_Click (object sender, EventArgs e)
		{
			if (gps.Opened) {
				gps.Close ();
			}
			Application.Exit ();
		}

		private void btnRefresh_Click (object sender, EventArgs e)
		{
			txtStatus.Text = "";
			InitListViewComponent ();
		}

		private void menuItemGpsOn_Click (object sender, EventArgs e)
		{
			txtStatus.Text = "GPS started";
			if (!gps.Opened) {
				gps.Open ();
			}
			lblSetGps.Text = "Starting";
		}

		private void menuItemGpsOff_Click (object sender, EventArgs e)
		{
			if (gps.Opened) {
				gps.Close ();
			}
			System.Threading.Thread.Sleep (1000); //Delay to let GPS finnish shutdown
			lblSetGps.Text = gps.GetDeviceState ().DeviceState.ToString ();
		}

		private void menuItemGpsMenu_Click (object sender, EventArgs e)
		{
		}

		private void Form1_Closed (object sender, System.EventArgs e)
		{
			if (gps.Opened) {
				gps.Close ();
			}
		}
#endregion
		  #region business methods
		private void generateInformation ()
		{
			Handlers.GenerationHandler genHandler = new 
Outlook_1.Handlers.GenerationHandler ();
			genHandler.generateInfo (gps.ZoneObj);
		}

		private void UpdateData (object sender, EventArgs e)
		{
           
			if (gps.Opened) {
				lblSetGps.Text = 
gps.GetDeviceState ().DeviceState.ToString ();
				string str = "";
               
				if (position != null) {
					if (position.LatitudeValid && 
position.LongitudeValid) {
						if (firstGPSCoordinate) {
							zoneNameCompare = gps.ZoneObj.ZoneName; //Set the inital value
							firstGPSCoordinate = false;
						}
						str += "Latitude :\r\n   " + position.dblLatitude 
+ "\r\n"; //+ position.Latitude + "\r\n";
						str += "Longitude :\r\n   " + 
position.dblLongitude + "\r\n"; //+ position.Longitude + "\r\n";
					}
					if (gps.ZoneObj.ZoneName != zoneNameCompare) { //If zone is changed, run generateInformation() to compute new info
						generateInformation ();
						zoneNameCompare = gps.ZoneObj.ZoneName;
					}
					txtStatus.Text += str;
					lblSetZone.Text = gps.ZoneObj.ZoneName;
				}
			}
		}
#endregion
		void sms_MessageReceived (object sender, 
MessageeInterceptorEventArgs e)
		{
			Handlers.AppointmentHandler appHandler = new 
Handlers.AppointmentHandler ();
			Business.AppointmentVO appVO = 
(Business.AppointmentVO)appHandler.getCurrentAppointment ();
			if (appVO._Id == null) {
				//no current app
			} else {
				notification = new Microsoft.WindowsCE.Forms.Notification ();
               
				Microsoft.WindowsMobile.PocketOutlook.SmsMessage msg =
                    
(Microsoft.WindowsMobile.PocketOutlook.SmsMessage)e.Message;
				msg.Read = true;
				StringBuilder stb = new StringBuilder ();
				stb.Append (msg.Body + "<br>");
				stb.Append (msg.Received.ToString () + "<br>");
				stb.Append (msg.From + "<br>");
				notification.BalloonChanged += new 
BalloonChangedEventHandler (notification_BalloonChanged);
				notification.Text = stb.ToString ();
				notification.InitialDuration = 10;
				if (appVO._Sensitivity.ToLower ().Trim () == "private") {
					notification.Caption = "BlockedSmSMessage";
					notificationStatus = true;
				} else {
					notification.Caption = "IncommingSMSMessage";
					notification.Visible = true;
				}
			}
		}

		void notification_BalloonChanged (object sender, 
BalloonChangedEventArgs e)
		{
			if (e.Visible != true) {
				notification.Dispose ();
			}
		}

		public void testsub ()
		{
			Business.ZoneVO zoneVO_ = new Outlook_1.Business.ZoneVO (1, 
1);
			Handlers.AppointmentHandler appHandler = new 
Handlers.AppointmentHandler ();
			Business.AppointmentVO appVO = 
(Business.AppointmentVO)appHandler.getCurrentAppointment ();
			new Handlers.GenerationHandler ().generateEvent (zoneVO_, 
appVO);
        
		}

		private void menuMain_Click (object sender, EventArgs e)
		{
		}

		private void menuItem1_Click (object sender, EventArgs e)
		{
			MessageBox.Show ("Copyright Brunel ");
		}

		private void menuItem3_Click (object sender, EventArgs e)
		{
			Business.AppointmentVO app = new 
Handlers.AppointmentHandler ().getCurrentAppointment ();
			if (app._Id == null)
				MessageBox.Show ("Current appointment:\r\nNo current appointment");
			else
				MessageBox.Show ("Current appointment:\r\n" + 
app._Subject + " " + app._Start);
		}

		private void menuItem4_Click (object sender, EventArgs e)
		{
			Business.AppointmentVO app = new 
Handlers.AppointmentHandler ().getNextAppointment ();
			if (app._Id == null)
				MessageBox.Show ("Next appointment:\r\nNo upcomming appointment");
			else
				MessageBox.Show ("Next appointment:\r\n" + app._Subject + 
" " + app._Start);
		}

		private void button1_Click_1 (object sender, EventArgs e)
		{
			Handlers.AppointmentHandler appHandler = new 
Handlers.AppointmentHandler ();
			Business.AppointmentVO appVO = 
(Business.AppointmentVO)appHandler.getCurrentAppointment ();
			new Handlers.GenerationHandler ().generateEvent (null, appVO);
			ArrayList al = new ArrayList ();
			al.Contains ("work");
              
		}

		private void lblHeader_ParentChanged (object sender, EventArgs e)
		{
		}
       
	}
}
				