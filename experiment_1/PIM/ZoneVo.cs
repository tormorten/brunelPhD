using System;
using System.Collections.Generic;
using System.Text;

namespace Outlook_1.Business
{
	public class ZoneVO
	{
		//staticstatic
		private  int zoneId;
		private  string zoneName;

		public ZoneVO ()
		{
			ZoneId = 0;
		}

		public ZoneVO (double lat, double lon)
		{
			setZone (lat, lon);
		}
       
		private int ZoneId {
			get { return zoneId; }
			set {
				zoneId = value;
				if (value == 1)
					zoneName = "Gamle Oslo";
				else if (value == 2)
					zoneName = "Sentrum";
				else if (value == 3)
					zoneName = "Frogner";
				else if (value == 4)
					zoneName = "Grunerlokka";
				else if (value == 5)
					zoneName = "St. Haugen";
				else if (value == 6)
					zoneName = "(home)";
				else {
					zoneId = 0;
					zoneName = "Other";
				}
			}
		}

		public string ZoneName {
			get { return zoneName; }
		}

		public int getZoneID ()
		{
			return this.ZoneId;
		}

		private double lon = 0, lat = 0;
		private double answer = 0;

		public Boolean Moved (GpsLib.GpsPosition posObj)
		{
            
			answer = ComputeLatLonDistance (lat, lon, posObj.dblLatitude, 
posObj.dblLongitude);
			if (answer >= 0.05) { 
				lat = posObj.dblLatitude;
				lon = posObj.dblLongitude;
				return true;
			} else
				return false;
		}

		public string setZone (double lat, double lon)
		{
			if (inZone1 (lat, lon))
				ZoneId = 1;
			else if (inZone2 (lat, lon))
				ZoneId = 2;
			else if (inZone3 (lat, lon))
				ZoneId = 3;
			else if (inZone4 (lat, lon))
				ZoneId = 4;
			else if (inZone5 (lat, lon))
				ZoneId = 5;
			else if (inZone6 (lat, lon))
				ZoneId = 6;
			else
				ZoneId = 0; 
			return this.ZoneId.ToString ();
		}

		private bool inZone1 (double lat, double lon)
		{
			double answer;
			double x1, y1, x2, y2; //end points in the line
//double x, y; // point to check
			bool bottom = false, right = false, top = false, left = 
false;
			//line 1 (bottom)
			x1 = 59.90168001982767;
			y1 = 10.750336647033691;
			x2 = 59.89321026233944;
			y2 = 10.812134742736816;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				bottom = true;
			}
//lin2 (right)
			x1 = 59.89321026233944;
			y1 = 10.812134742736816;
			x2 = 59.907264358045;
			y2 = 10.81277847290039;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				right = true;
			}
//line 3 (top)
			x1 = 59.91624682360586;
			y1 = 10.758833885192871;
			x2 = 59.907264358045;
			y2 = 10.81277847290039;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				top = true;
			}
//line 4 (left)
			x1 = 59.90165849840346;
			y1 = 10.750315189361572;
			x2 = 59.91624682360586;
			y2 = 10.758833885192871;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				left = true;
			}
			if (top && right && bottom && left) {
				return true;
			} else
				return false;
		}

		private bool inZone2 (double lat, double lon)
		{
			double answer;
			double x1, y1, x2, y2; //end points in the line
//double x, y; // point to check
			bool bottom = false, right = false, top = false, left = 
false;
			//line 1 (bottom)
			x1 = 59.90940530995541;
			y1 = 10.711584091186523;
			x2 = 59.90169078053454;
			y2 = 10.749950408935547;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				bottom = true;
			}
			//lin2 (right)
			x1 = 59.90169078053454;
			y1 = 10.749950408935547;
			x2 = 59.916268335575836;
			y2 = 10.758490562438965;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				right = true;
			}
//line 3 (top)
			x1 = 59.92190399137404;
			y1 = 10.729973316192627;
			x2 = 59.916268335575836;
			y2 = 10.758490562438965;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				top = true;
			}
//line 4 (left)
			x1 = 59.90940530995541;
			y1 = 10.711584091186523;
			x2 = 59.92190399137404;
			y2 = 10.729973316192627;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				left = true;
			}
			if (top && right && bottom && left) {
				return true;
			} else
				return false;
		}

		private bool inZone3 (double lat, double lon)
		{
			double answer;
			double x1, y1, x2, y2; //end points in the line
//double x, y; // point to check
			bool bottom = false, right = false, top = false, left = 
false;
			//line 1 (bottom)
			x1 = 59.91840870687968;
			y1 = 10.687980651855469;
			x2 = 59.90955592449003;
			y2 = 10.711283683776855;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				bottom = true;
			}
			//lin2 (right)
			x1 = 59.90955592449003;
			y1 = 10.711283683776855;
			x2 = 59.9219685162423;
			y2 = 10.729780197143555;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				right = true;
			}
			//line 3 (top)
			x1 = 59.92694730685895;
			y1 = 10.705060958862305;
			x2 = 59.9219685162423;
			y2 = 10.729780197143555;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				top = true;
			}
//line 4 (left)
			x1 = 59.91840870687968;
			y1 = 10.687980651855469;
			x2 = 59.92694730685895;
			y2 = 10.705060958862305;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				left = true;
			}
			if (top && right && bottom && left) {
				return true;
			} else
				return false;
		}

		private bool inZone4 (double lat, double lon)
		{
			double answer;
			double x1, y1, x2, y2; //end points in the line
//double x, y; // point to check
			bool bottom = false, right = false, top = false, left = 
false;
			//line 1 (bottom)
			x1 = 59.91805378048155;
			y1 = 10.749671459197998;
			x2 = 59.907361187996464;
			y2 = 10.81277847290039;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				bottom = true;
			}
//lin2 (right)
			x1 = 59.907361187996464;
			y1 = 10.81277847290039;
			x2 = 59.927044079404155;
			y2 = 10.804581642150879;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				right = true;
			}
//line 3 (top)
			x1 = 59.931495311357594;
			y1 = 10.76162338256836;
			x2 = 59.927044079404155;
			y2 = 10.804581642150879;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				top = true;
			}
//line 4 (left)
			x1 = 59.91805378048155;
			y1 = 10.749671459197998;
			x2 = 59.931495311357594;
			y2 = 10.76162338256836;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				left = true;
			}
			if (top && right && bottom && left) {
				return true;
			} else
				return false;
		}

		private bool inZone5 (double lat, double lon)
		{
			double answer;
			double x1, y1, x2, y2; //end points in the line
//double x, y; // point to check
			bool bottom = false, right = false, top = false, left = 
false;
			//line 1 (bottom)
			x1 = 59.927076336856494;
			y1 = 10.705232620239258;
			x2 = 59.91819360042482;
			y2 = 10.74962854385376;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				bottom = true;
			}
			//lin2 (right)
			x1 = 59.91819360042482;
			y1 = 10.74962854385376;
			x2 = 59.93158131961962;
			y2 = 10.761387348175049;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				right = true;
			}
//line 3 (top)
			x1 = 59.942201625641374;
			y1 = 10.74038028717041;
			x2 = 59.93158131961962;
			y2 = 10.761387348175049;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				top = true;
			}
//line 4 (left)
			x1 = 59.927076336856494;
			y1 = 10.705232620239258;
			x2 = 59.942201625641374;
			y2 = 10.74038028717041;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				left = true;
			}
			if (top && right && bottom && left) {
				return true;
			} else
				return false;
		}

		private bool inZone6 (double lat, double lon)
		{
			double answer;
			double x1, y1, x2, y2; //end points in the line
//double x, y; // point to check
			bool bottom = false, right = false, top = false, left = 
false;
//line 1 (bottom)
			x1 = 60.398009968603475;
			y1 = 10.475850105285645;
			x2 = 60.397988769615296;
			y2 = 10.481321811676025;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				bottom = true;
			}
//lin2 (right)
			x1 = 60.397988769615296;
			y1 = 10.481321811676025;
			x2 = 60.400362970473836;
			y2 = 10.481364727020264;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				right = true;
			}
//line 3 (top)
			x1 = 60.40041596405281;
			y1 = 10.475850105285645;
			x2 = 60.400362970473836;
			y2 = 10.481364727020264;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer < 0) {
				top = true;
			}
//line 4 (left)
			x1 = 60.398009968603475;
			y1 = 10.475850105285645;
			x2 = 60.40041596405281;
			y2 = 10.475850105285645;
			answer = lon - y1 - ((y2 - y1) / (x2 - x1)) * (lat - x1);
			if (answer > 0) {
				left = true;
			}
			if (top && right && bottom && left) {
				return true;
			} else
				return false;
		}

		public void IOtest (double la, double lo)
		{
			System.IO.StreamWriter outStream = new 
System.IO.StreamWriter (@"\Temp\minGPS.txt", true);
			outStream.WriteLine ("----" + DateTime.Now);
			outStream.WriteLine (la.ToString ());
			outStream.WriteLine (lo.ToString ());
			outStream.Flush ();
			outStream.Close ();
		}

		public double ComputeLatLonDistance (double Lat1,
                  double Long1, double Lat2, double Long2)
		{
			/*The Haversine formula according to:
			http://mathforum.org/library/drmath/view/51879.html
            */
			double dDistance = Double.MinValue;
			double dLat1InRad = Lat1 * (Math.PI / 180.0);
			double dLong1InRad = Long1 * (Math.PI / 180.0);
			double dLat2InRad = Lat2 * (Math.PI / 180.0);
			double dLong2InRad = Long2 * (Math.PI / 180.0);
			double dLongitude = dLong2InRad - dLong1InRad;
			double dLatitude = dLat2InRad - dLat1InRad;
			// Intermediate result a.
			double a = Math.Pow (Math.Sin (dLatitude / 2.0), 2.0) +
                       Math.Cos (dLat1InRad) * Math.Cos (dLat2InRad) *
			Math.Pow (Math.Sin (dLongitude / 2.0), 2.0);
			// Intermediate result c (great circle distance in Radians).
			double c = 2.0 * Math.Atan2 (Math.Sqrt (a), Math.Sqrt (1.0 -a));
			// Distance
			const Double kEarthRadiusKms = 6371;
			dDistance = kEarthRadiusKms * c;
			return dDistance;
		}
	}
}