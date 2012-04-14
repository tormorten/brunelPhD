using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Text;

namespace Outlook_1.GpsLib
{
	/*Building on and extending Microsoft Windows Mobile 5 example*/
	public delegate void LocationChangedEventHandler (object sender,
LocationChangedEventArgs args);

	public delegate void DeviceStateChangedEventHandler (object sender,
DeviceStateChangedEventArgs args);

	public class Gps
	{
		//zone computation and alert
		private Business.ZoneVO zones;

		public Business.ZoneVO ZoneObj {
			get { return zones; }
		}
// handle to the gps device
		IntPtr gpsHandle = IntPtr.Zero;
// handle to the native event when the devices gets a new location
		IntPtr newLocationHandle = IntPtr.Zero;
// handle to the native event when the device state changes
		IntPtr deviceStateChangedHandle = IntPtr.Zero;
		IntPtr stopHandle = IntPtr.Zero;
		System.Threading.Thread gpsEventThread = null;

		event LocationChangedEventHandler locationChanged;

		public event LocationChangedEventHandler LocationChanged {
			add {
				locationChanged += value;
				CreateGpsEventThread ();
			}
			remove {
				locationChanged -= value;
			}
		}

		event DeviceStateChangedEventHandler deviceStateChanged;

		public event DeviceStateChangedEventHandler DeviceStateChanged {
			add {
				deviceStateChanged += value;
				CreateGpsEventThread ();
			}
			remove {
				deviceStateChanged -= value;
			}
		}

		public bool Opened {
			get { return gpsHandle != IntPtr.Zero; }
		}

		public Gps ()
		{
			zones = new Outlook_1.Business.ZoneVO ();
		}

		~Gps ()
		{
			// make sure that the GPS was closed.
			Close ();
		}

		public void Open ()
		{
			if (!Opened) {
				// create handles for GPS events
				newLocationHandle = CreateEvent (IntPtr.Zero, 0, 0, null);
				deviceStateChangedHandle = CreateEvent (IntPtr.Zero, 0, 0, 
null);
				stopHandle = CreateEvent (IntPtr.Zero, 0, 0, null);
				gpsHandle = GPSOpenDevice (newLocationHandle, 
deviceStateChangedHandle, null, 0);
				if (locationChanged != null || deviceStateChanged != 
null) {
					CreateGpsEventThread ();
				}
			}
		}

		public void Close ()
		{
			if (gpsHandle != IntPtr.Zero) {
				GPSCloseDevice (gpsHandle);
				gpsHandle = IntPtr.Zero;
			}
			if (stopHandle != IntPtr.Zero) {
				EventModify (stopHandle, eventSet);
			}
			lock (this) {
				if (newLocationHandle != IntPtr.Zero) {
					CloseHandle (newLocationHandle);
					newLocationHandle = IntPtr.Zero;
				}
				if (deviceStateChangedHandle != IntPtr.Zero) {
					CloseHandle (deviceStateChangedHandle);
					deviceStateChangedHandle = IntPtr.Zero;
				}
				if (stopHandle != IntPtr.Zero) {
					CloseHandle (stopHandle);
					stopHandle = IntPtr.Zero;
				}
			}
		}

		public GpsPosition GetPosition ()
		{
			return GetPosition (TimeSpan.Zero);
		}
       
		public GpsPosition GetPosition (TimeSpan maxAge)
		{
			GpsPosition gpsPosition = null;
			if (Opened) {
				IntPtr ptr = Utils.LocalAlloc (Marshal.SizeOf (typeof(GpsPosition)));
				gpsPosition = new GpsPosition ();
				gpsPosition.dwVersion = 1;
				gpsPosition.dwSize = Marshal.SizeOf (typeof(GpsPosition));
				Marshal.StructureToPtr (gpsPosition, ptr, false);
				int result = GPSGetPosition (gpsHandle, ptr, 500000, 0);
				if (result == 0) {
					gpsPosition = (GpsPosition)Marshal.PtrToStructure (ptr, typeof(GpsPosition));
					if (maxAge != TimeSpan.Zero) {
						if (!gpsPosition.TimeValid || DateTime.Now -maxAge > gpsPosition.Time) {
							gpsPosition = null;
						}
					}
				}
				Utils.LocalFree (ptr);
			}
			return gpsPosition;
		}
       
		public GpsDeviceState GetDeviceState ()
		{
			GpsDeviceState device = null;
			IntPtr pGpsDevice = Utils.LocalAlloc (GpsDeviceState.GpssDeviceStructureSize);
			Marshal.WriteInt32 (pGpsDevice, 1);
			Marshal.WriteInt32 (pGpsDevice, 4, GpsDeviceState.GpsDeviceStructureSize);
			int result = GPSGetDeviceState (pGpsDevice);
			if (result == 0) {
				device = new GpsDeviceState (pGpsDevice);
			}
			Utils.LocalFree (pGpsDevice);
			return device;
		}

		private void CreateGpsEventThread ()
		{
			if (gpsEventThread == null && gpsHandle != IntPtr.Zero) {
				gpsEventThread = new System.Threading.Thread (new 
System.Threading.ThreadStart (WaitForGpsEvents));
				gpsEventThread.Start ();
			}
		}
      
		private void WaitForGpsEvents ()
		{
			lock (this) {
				bool listening = true;
				IntPtr handles = Utils.LocalAlloc (12);
				Marshal.WriteInt32 (handles, 0, stopHandle.ToInt32 ());
				Marshal.WriteInt32 (handles, 4, deviceStateChangedHandle.ToInt32 ());
				Marshal.WriteInt32 (handles, 8, newLocationHandle.ToInt32 ());
				while (listening) {             
					int obj = WaitForMultipleObjects (3, handles, 0, -1);
					if (obj != waitFailed) {
						switch (obj) {
						case 0:
                               // stop signalled triggered
							listening = false;
							break;
						case 1:
                                // device state has changed
							if (deviceStateChanged != null) {
								deviceStateChanged (this, new DeviceStateChangedEventArgs (GetDeviceState ()));
							}
							break;
						case 2:
                                // location has changed
							if (locationChanged != null) {
								if (zones.Moved (GetPosition ())) {
                                        
									zones.setZone (this.GetPosition ().dblLatitude, this.GetPosition ().dblLongitude);
									Business.Logger.
									LogEvent (this.GetPosition ().dblLatitude + " : " + 
									          this.GetPosition ().dblLongitude + " : " + zones.ZoneName);
									locationChanged (this, new LocationChangedEventArgs (GetPosition ()));
								}
							}
							break;
						}
					}
				}
				Utils.LocalFree (handles);
				gpsEventThread = null;
			}
		}
		
		//PInvokes to gpsapi.dll
		[DllImport("gpsapi.dll")]
		static extern IntPtr GPSOpenDevice (IntPtr hNewLocationData, 
IntPtr hDeviceStateChange, string szDeviceName, int dwFlags);
        
		[DllImport("gpsapi.dll")]
		static extern int GPSCloseDevice (IntPtr hGPSDevice);

		[DllImport("gpsapi.dll")]
		static extern int GPSGetPosition (IntPtr hGPSDevice, IntPtr 
pGPSPosition, int dwMaximumAge, int dwFlags);

		[DllImport("gpsapi.dll")]
		static extern int GPSGetDeviceState (IntPtr pGPSDevice);
		// PInvokes to coredll.dll
		[DllImport("coredll.dll")]
		static extern IntPtr CreateEvent (IntPtr lpEventAttributes, int 
bManualReset, int bInitialState, StringBuilder lpName);

		[DllImport("coredll.dll")]
		static extern int CloseHandle (IntPtr hObject);

		const int waitFailed = -1;

		[DllImport("coredll.dll")]
		static extern int WaitForMultipleObjects (int nCount, IntPtr 
lpHandles, int fWaitAll, int dwMilliseconds);

		const int eventSet = 3;

		[DllImport("coredll.dll")]
		static extern int EventModify (IntPtr hHandle, int dwFunc);
	}
}