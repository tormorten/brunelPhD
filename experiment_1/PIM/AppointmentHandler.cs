using System;
using System.Text;
using System.Collections;
namespace Outlook_1.Handlers {
    class AppointmentHandler {
        
private Outlook.AppointmentInfo _appInfo;
public AppointmentHandler() {
            if (_appInfo == null)
                _appInfo = new Outlook_1.Outlook.AppointmentInfo();
        }
public ArrayList getAllAppointments() {
            return _appInfo.getAllNewAppointments();
        }
public ArrayList getAllNewAppointments() {
            return _appInfo.getAllNewAppointments();
        }
public Microsoft.WindowsMobile.PocketOutlook.Appointment 
getAppointmentByID(int id) {
            return _appInfo.getAppointmentByID(id);
        }
public Business.AppointmentVO getNextAppointment() {
            return _appInfo.getNextAppointment();
        }
public Business.AppointmentVO getCurrentAppointment() {
            return _appInfo.getCurrentAppointment();
        }
        
    }
}