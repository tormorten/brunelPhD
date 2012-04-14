using System;

namespace Outlook_1.GpsLib {
    /*Building on and extending Microsoft Windows Mobile 5 example*/
public class LocationChangedEventArgs : EventArgs {
        public LocationChangedEventArgs(GpsPosition position) {
            this.position = position;
        }
public GpsPosition Position {
            get {
                return position;
            }
        }
private GpsPosition position;
    }
}