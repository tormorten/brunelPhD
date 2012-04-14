using System;
using System.Runtime.InteropServices;
using System.Collections;

namespace Outlook_1.GpsLib
{
	/*Building on and extending Microsoft Windows Mobile 5 example*/
#region Internal Native Structures
	[StructLayout(LayoutKind.Sequential)]
internal struct SystemTime
	{
		internal short year;
		internal short month;
		internal short dayOfWeek;
		internal short day;
		internal short hour;
		internal short minute;
		internal short second;
		internal short millisecond;
	}

	[StructLayout(LayoutKind.Sequential)]
internal struct SatelliteArray
	{
		int a, b, c, d, e, f, g, h, i, j, k, l;

		public int Count {
			get { return 12; }
		}

		public int this [int value] {
			get {
				if (value == 0)
					return a;
				else if (value == 1)
					return b;
				else if (value == 2)
					return c;
				else if (value == 3)
					return d;
				else if (value == 4)
					return e;
				else if (value == 5)
					return f;
				else if (value == 6)
					return g;
				else if (value == 7)
					return h;
				else if (value == 8)
					return i;
				else if (value == 9)
					return j;
				else if (value == 10)
					return k;
				else if (value == 11)
					return l;
				else
					throw new ArgumentOutOfRangeException ("value must be 0 - 11");
			}
		}
	}
#endregion
	enum FixQuality : int
	{
		Unknown = 0,
		Gps,
		DGps
	}

	enum FixType : int
	{
		Unknown = 0,
		XyD,
		XyzD
	}

	enum FixSelection : int
	{
		Unknown = 0,
		Auto,
		Manual
	}

	public class Satellite
	{
		public Satellite ()
		{
		}

		public Satellite (int id, int elevation, int azimuth, int 
signalStrength)
		{
			this.id = id;
			this.elevation = elevation;
			this.azimuth = azimuth;
			this.signalStrength = signalStrength;
		}

		int id;

		public int Id {
			get {
				return id;
			}
			set {
				id = value;
			}
		}

		int elevation;

		public int Elevation {
			get {
				return elevation;
			}
			set {
				elevation = value;
			}
		}

		int azimuth;

		public int Azimuth {
			get {
				return azimuth;
			}
			set {
				azimuth = value;
			}
		}

		int signalStrength;

		public int SignalStrength {
			get {
				return signalStrength;
			}
			set {
				signalStrength = value;
			}
		}
	}

	[StructLayout(LayoutKind.Sequential)]
public class GpsPosition
	{
		internal GpsPosition ()
		{
		}

		internal static int GPS_VALID_UTC_TIME = 0x00000001;
		internal static int GPS_VALID_LATITUDE = 0x00000002;
		internal static int GPS_VALID_LONGITUDE = 0x00000004;
		internal static int GPS_VALID_SPEED = 0x00000008;
		internal static int GPS_VALID_HEADING = 0x00000010;
		internal static int GPS_VALID_MAGNETIC_VARIATION = 0x00000020;
		internal static int GPS_VALID_ALTITUDE_WRT_SEA_LEVEL = 
0x00000040;
		internal static int GPS_VALID_ALTITUDE_WRT_ELLIPSOID = 
0x00000080;
		internal static int GPS_VALID_POSITION_DILUTION_OF_PRECISION = 
0x00000100;
		internal static int GPS_VALID_HORIZONTAL_DILUTION_OF_PRECISION = 
0x00000200;
		internal static int GPS_VALID_VERTICAL_DILUTION_OF_PRECISION = 
0x00000400;
		internal static int GPS_VALID_SATELLITE_COUNT = 0x00000800;
		internal static int GPS_VALID_SATELLITES_USED_PRNS = 0x00001000;
		internal static int GPS_VALID_SATELLITES_IN_VIEW = 0x00002000;
		internal static int GPS_VALID_SATELLITES_IN_VIEW_PRNS = 
0x00004000;
		internal static int GPS_VALID_SATELLITES_IN_VIEW_ELEVATION = 
0x00008000;
		internal static int GPS_VALID_SATELLITES_IN_VIEW_AZIMUTH = 
0x00010000;
		internal static int 
GPS_VALID_SATELLITES_IN_VIEW_SIGNAL_TO_NOISE_RATIO = 0x00020000;
		internal int dwVersion = 1;             // Current version of GPSID client is using.
		internal int dwSize = 0;                // sizeof(_GPS_POSITION)
		internal int dwValidFields = 0;
// Additional information about this location structure (GPS_DATA_FLAGS_XXX)
		internal int dwFlags = 0;
		internal SystemTime stUTCTime = new SystemTime ();  //  UTC according to GPS clock.
		internal double dblLatitude = 0.0;
		internal double dblLongitude = 0.0;
		internal float flSpeed = 0.0f;
		internal float flHeading = 0.0f;
		internal double dblMagneticVariation = 0.0;
		internal float flAltitudeWRTSeaLevel = 0.0f;
		internal float flAltitudeWRTEllipsoid = 0.0f;
//** Quality of this fix
		internal FixQuality fixQuality = FixQuality.Unknown;
		internal FixType fixType = FixType.Unknown;
		internal FixSelection selectionType = FixSelection.Unknown;
		internal float flPositionDilutionOfPrecision = 0.0f;
		internal float flHorizontalDilutionOfPrecision = 0.0f;
		internal float flVerticalDilutionOfPrecision = 0.0f;
		//** Satellite information
		internal int dwSatelliteCount = 0;
		internal SatelliteArray rgdwSatellitesUsedPRNs = new 
SatelliteArray ();
		internal int dwSatellitesInView = 0;
		internal SatelliteArray rgdwSatellitesInViewPRNs = new 
SatelliteArray ();
		internal SatelliteArray rgdwSatellitesInViewElevation = new 
SatelliteArray ();
		internal SatelliteArray rgdwSatellitesInViewAzimuth = new 
SatelliteArray ();
		internal SatelliteArray rgdwSatellitesInViewSignalToNoiseRatio = 
new SatelliteArray ();

		public DateTime Time {
			get {
				DateTime time = new DateTime (stUTCTime.year, 
stUTCTime.month, stUTCTime.day, stUTCTime.hour, stUTCTime.minute, 
stUTCTime.second, stUTCTime.millisecond);
				return time;
			}
		}

		public bool TimeValid {
			get { return (dwValidFields & GPS_VALID_UTC_TIME) != 0; }
		}
       
		public Satellite[] GetSatellitesInSolution ()
		{
			Satellite[] inViewSatellites = GetSatellitesInView ();
			ArrayList list = new ArrayList ();
			for (int index = 0; index < dwSatelliteCount; index++) {
				Satellite found = null;
				for (int viewIndex = 0; viewIndex < 
inViewSatellites.Length && found == null; viewIndex++) {
					if (rgdwSatellitesUsedPRNs [index] == 
inViewSatellites [viewIndex].Id) {
						found = inViewSatellites [viewIndex];
						list.Add (found);
					}
				}
			}
			return (Satellite[])list.ToArray (typeof(Satellite));
		}
      
		public bool SatellitesInSolutionValid {
			get {
				return (dwValidFields & GPS_VALID_SATELLITES_USED_PRNS) 
!= 0;
			}
		}

		public Satellite[] GetSatellitesInView ()
		{
			Satellite[] satellites = null;
			if (dwSatellitesInView != 0) {
				satellites = new Satellite[dwSatellitesInView];
				for (int index = 0; index < satellites.Length; index++) {
					satellites [index] = new Satellite ();
					satellites [index].Azimuth = 
rgdwSatellitesInViewAzimuth [index];
					satellites [index].Elevation = 
rgdwSatellitesInViewElevation [index];
					satellites [index].Id = 
rgdwSatellitesInViewPRNs [index];
					satellites [index].SignalStrength = 
rgdwSatellitesInViewSignalToNoiseRatio [index];
				}
			}
			return satellites;
		}

		public bool SatellitesInViewValid {
			get {
				return (dwValidFields & GPS_VALID_SATELLITES_IN_VIEW) 
!= 0;
			}
		}

		public int SatelliteCount {
			get { return dwSatelliteCount; }
		}

		public bool SatelliteCountValid {
			get {
				return (dwValidFields & GPS_VALID_SATELLITE_COUNT) != 
0;
			}
		}

		public int SatellitesInViewCount {
			get { return dwSatellitesInView; }
		}

		public bool SatellitesInViewCountValid {
			get {
				return (dwValidFields & GPS_VALID_SATELLITES_IN_VIEW) 
!= 0;
			}
		}

		public float Speed {
			get { return flSpeed; }
		}
      
		public bool SpeedValid {
			get { return (dwValidFields & GPS_VALID_SPEED) != 0; }
		}

		public float EllipsoidAltitude {
			get { return flAltitudeWRTEllipsoid; }
		}

		public bool EllipsoidAltitudeValid {
			get {
				return (dwValidFields & 
GPS_VALID_ALTITUDE_WRT_ELLIPSOID) != 0;
			}
		}

		public float SeaLevelAltitude {
			get { return flAltitudeWRTSeaLevel; }
		}

		public bool SeaLevelAltitudeValid {
			get {
				return (dwValidFields & 
GPS_VALID_ALTITUDE_WRT_SEA_LEVEL) != 0;
			}
		}

		public double Latitude {
			get {
				return 
ParseDegreesMinutesSeconds (dblLatitude).ToDecimalDegrees ();
			}
		}

		public DegreesMinutesSeconds LatitudeInDegreesMinutesSeconds {
			get { return ParseDegreesMinutesSeconds (dblLatitude); }
		}

		public bool LatitudeValid {
			get { return (dwValidFields & GPS_VALID_LATITUDE) != 0; }
		}

		public double Longitude {
			get {
				return 
ParseDegreesMinutesSeconds (dblLongitude).ToDecimalDegrees ();
			}
		}

		public DegreesMinutesSeconds LongitudeInDegreesMinutesSeconds {
			get { return ParseDegreesMinutesSeconds (dblLongitude); }
		}

		public bool LongitudeValid {
			get { return (dwValidFields & GPS_VALID_LONGITUDE) != 0; }
		}

		public float Heading {
			get { return flHeading; }
		}

		public bool HeadingValid {
			get { return (dwValidFields & GPS_VALID_HEADING) != 0; }
		}

		public float PositionDilutionOfPrecision {
			get { return flPositionDilutionOfPrecision; }
		}
      
		public bool PositionDilutionOfPrecisionValid {
			get {
				return (dwValidFields & 
GPS_VALID_POSITION_DILUTION_OF_PRECISION) != 0;
			}
		}

		public float HorizontalDilutionOfPrecision {
			get { return flHorizontalDilutionOfPrecision; }
		}

		public bool HorizontalDilutionOfPrecisionValid {
			get {
				return (dwValidFields & 
GPS_VALID_HORIZONTAL_DILUTION_OF_PRECISION) != 0;
			}
		}

		public float VerticalDilutionOfPrecision {
			get { return flVerticalDilutionOfPrecision; }
		}

		public bool VerticalDilutionOfPrecisionValid {
			get {
				return (dwValidFields & 
GPS_VALID_VERTICAL_DILUTION_OF_PRECISION) != 0;
			}
		}

		private DegreesMinutesSeconds ParseDegreesMinutesSeconds (double 
val)
		{
			double degrees = (val / 100.0);
			double minutes = (Math.Abs (degrees) -
Math.Abs ((double)(int)(degrees))) * 100;
			double seconds = (Math.Abs (val) - Math.Abs ((double)(int)val)) 
* 60.0;
			return new DegreesMinutesSeconds ((int)degrees, (int)minutes, 
seconds);
		}
	}
}
			