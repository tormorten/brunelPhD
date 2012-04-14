using System;

namespace Outlook_1.GpsLib
{
	/*Building on and extending Microsoft Windows Mobile 5 example*/
	public class DegreesMinutesSeconds
	{
		int degrees;
       
		public int Degrees {
			get { return degrees; }
		}

		int minutes;

		public int Minutes {
			get { return minutes; }
		}

		double seconds;

		public double Seconds {
			get { return seconds; }
		}

		public DegreesMinutesSeconds (double decimalDegrees)
		{
			degrees = (int)decimalDegrees;
			double doubleMinutes = (Math.Abs (decimalDegrees) -
Math.Abs ((double)degrees)) * 60.0;
			minutes = (int)doubleMinutes;
			seconds = (doubleMinutes - (double)minutes) * 60.0;
		}

		public DegreesMinutesSeconds (int degrees, int minutes, double 
seconds)
		{
			this.degrees = degrees;
			this.minutes = minutes;
			this.seconds = seconds;
		}
       
		public double ToDecimalDegrees ()
		{
			int absDegrees = Math.Abs (degrees);
			double val = (double)absDegrees + ((double)minutes / 60.0) + 
((double)seconds / 3600.0);
			if (degrees == 0) {
				return val;
			}
			;
			return val * (absDegrees / degrees);
		}
       
		public override string ToString ()
		{
			return degrees + "d " + minutes + "' " + seconds + "\"";
		}
	}
}