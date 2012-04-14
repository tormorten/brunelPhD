using System;
using System.Runtime.InteropServices;

public enum GpsServiceState : int
{
	Off = 0,
	On = 1,
	StartingUp = 2,
	ShuttingDown = 3,
	Unloading = 4,
	Uninitialized = 5,
	Unknown = -1
}
namespace Outlook_1.GpsLib
{
	/*Building on and extending Microsoft Windows Mobile 5 example*/
	[StructLayout(LayoutKind.Sequential)]
internal struct FileTime
	{
		int dwLowDateTime;
		int dwHighDateTime;
	}

	[StructLayout(LayoutKind.Sequential)]
public class GpsDeviceState
	{
		public static int GpsMaxFriendlyName = 64;
		public static int GpsDeviceStructureSize = 216;
		int serviceState = 0;

		public GpsServiceState ServiceState {
			get { return (GpsServiceState)serviceState; }
		}

		int deviceState = 0;

		public GpsServiceState DeviceState {
			get { return (GpsServiceState)deviceState; }
		}

		string friendlyName = "";

		public string FriendlyName {
			get { return friendlyName; }
		}

		public GpsDeviceState (IntPtr pGpsDevice)
		{
			if (pGpsDevice == IntPtr.Zero) {
				throw new ArgumentException ();
			}
// read in the service state which starts at offset 8
			serviceState = Marshal.ReadInt32 (pGpsDevice, 8);
// read in the device state which starts at offset 12
			deviceState = Marshal.ReadInt32 (pGpsDevice, 12);
			IntPtr pFriendlyName = (IntPtr)(pGpsDevice.ToInt32 () + 88);
// the friendly name starts at offset 88
			friendlyName = Marshal.PtrToStringUni (pFriendlyName);
		}
	}
}