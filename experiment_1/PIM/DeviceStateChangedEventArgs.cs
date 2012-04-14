#region Using directives
using System;

#endregion
namespace Outlook_1.GpsLib
{
	/*Building on and extending Microsoft Windows Mobile 5 example*/
	public class DeviceStateChangedEventArgs : EventArgs
	{
		public DeviceStateChangedEventArgs (GpsDeviceState deviceState)
		{
			this.deviceState = deviceState;
		}

		public GpsDeviceState DeviceState {
			get {
				return deviceState;
			}
		}

		private GpsDeviceState deviceState;
	}
}