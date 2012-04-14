using System;
using System.Collections.Generic;
using System.Text;
//using Microsoft.WindowsMobile.Status;
using Microsoft.WindowsCE.Forms;
namespace Outlook_1.Handlers
{
    //this class handles generatation of info / event / resource based on
//soc context, loc context and app/task
class GenerationHandler {
        private string gpsPos;
private string context;
private Notification _notification;
private string notificationURL;
public string GpsPos {
            get { return gpsPos; }
set { gpsPos = value; }
        }
public string Context {
            get { return context; }
set { context = value; }
			}
public GenerationHandler() {
}
public void createURLNotification(string url, 
Business.AppointmentVO appVO) {
            string subject = "";
if(appVO._Id != null)
                subject = appVO._Subject;
            notificationURL = url;
_notification = new Notification();
_notification.Caption = "News: ";
            _notification.Critical = false;
            //
StringBuilder HTMLString = new StringBuilder();
HTMLString.Append("<html><body>");
HTMLString.Append("<font color=\"#0000FF\">Information); availiable for:</font><br>");
            HTMLString.Append("<font color=\"#0000FF\"><b>Appointment: " + subject + "</b></font><br/>");
            HTMLString.Append("<form method=\"GET\" action=notify>");
            HTMLString.Append("<br/><input type=button name='show' value='Show info'>");
            HTMLString.Append("<input type=button name='cancel' value='Cancel'/>");
HTMLString.Append("</body></html>");
_notification.Text = HTMLString.ToString();
//
_notification.BalloonChanged += new 
BalloonChangedEventHandler(_notification_BalloonChanged);
            _notification.ResponseSubmitted += new 
ResponseSubmittedEventHandler(_notification_ResponseSubmitted);
_notification.InitialDuration = 20;
_notification.Visible = true;
        }
void _notification_ResponseSubmitted(object sender, 
ResponseSubmittedEventArgs e) {
            if (e.Response == "show") {
                System.Diagnostics.Process.Start("iexplore", 
notificationURL);
_notification.Dispose();
            }
else if(e.Response == "cancel")
                _notification.Dispose();
        }
void _notification_BalloonChanged(object sender, 
BalloonChangedEventArgs e) {
            if (e.Visible == true) {
                // some action
            }
			 }
public void generateInfo(Business.ZoneVO zoneVO) {
            AppointmentHandler appHandler = new AppointmentHandler();
Business.AppointmentVO appVO = 
(Business.AppointmentVO)appHandler.getCurrentAppointment();
              this.generateEvent(zoneVO, appVO);
        }
public void generateEvent(Business.ZoneVO zoneVO, 
Business.AppointmentVO appVO) {
            int gpsLocation;
string[] socialState;
if (zoneVO != null)
				 gpsLocation = zoneVO.getZoneID(); //is computed from gps location
            else
                gpsLocation = 0;
            if(appVO._Id != null)
                socialState = appVO.getCategoryTab();
            else
                socialState = new string [] {"0","0"};
            string social0 = socialState[0].ToString().ToLower().Trim();
string social1 = socialState[1].ToString().ToLower().Trim();
#region 1
if (gpsLocation == 1) { //Zone 1, Gamle Oslo
                if (social0 == "work" || social1 == "work") {
                        if (social0=="meeting" || social1=="meeting") {
                            createURLNotification("http://www.nith.no", 
appVO);
                        }
                        else if (social0=="preperation" || social1=="preperation") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="own time" || social1=="owntime") {
                            createURLNotification("url", appVO);
                        }
                }
if (social0 == "travel" || social1 == "travel") {
                        if (social0=="train" || social1=="train") {
                            createURLNotification("url", appVO); 
                        }
else if (social0=="tube" || social1=="tube") {
                           createURLNotification("url", appVO);
                        }
                        else if (social0=="car" || social1=="car") {
                             createURLNotification("url", appVO);
                        }
else if (social0=="foot" || social1=="foot") {
                            
createURLNotification("http://oyafestivalen.com/", appVO);
                        }
                }
                 if (social0 == "leisure" || social1 == "leisure") {
                        if (social0=="shopping" || social1=="shopping") {
                             createURLNotification("url", appVO);
                        }
else if (social0=="cinema" || social1=="cinema") 
{
                             createURLNotification("url", appVO);
                        }
                        else if (social0=="sparetime" || 
social1=="sparetime") {
                             createURLNotification("url", appVO);
                        }
else if (social0=="food" || social1=="food") {
                            createURLNotification("url", appVO);
                        }
                 }
				  }
#endregion
#region 2
else if (gpsLocation == 2) { //Zone 2, Sentrum
               if (social0 == "work" || social1 == "work") {
                     if (social0=="meeting" || social1=="meeting") {
                         createURLNotification("url", appVO);
                        }
					  else if (social0=="preperation" || social1=="preperation") {
                            
createURLNotification("http://www.regjeringen.no/nb.html?id=4", appVO);
                        }
else if (social0=="own time" || social1=="own time") {
                            createURLNotification("url", appVO);
                        }
                    }
                if (social0 == "travel" || social1 == "travel") {
                    if (social0 == "train" || social1 == "train") {
                            
createURLNotification("http://www.nsb.no/internet/jp/trafficdelays/index.jhtml?page=trafficdelays_inc.jhtml", appVO);
                        }
else if (social0=="tube" || social1=="tube") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="car" || social1=="car") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="foot" || social1=="foot") {
                            createURLNotification("url", appVO);
                    }
                }
                 if (social0 == "leisure" || social1 == "leisure") {
                        if (social0=="shopping" || social1=="shopping") {
                            
createURLNotification("http://www.oslocity.no/site/page.aspx?Page=Forside", appVO);
                        }
else if (social0=="cinema" || social1=="cinema") 
{
                            createURLNotification("url", appVO);
                        }
else if (social0=="sparetime" || 
social1=="sparetime") {
                            createURLNotification("url", appVO);
                        }
                        else if (social0=="food" || social1=="food") {
                            createURLNotification("url", appVO);
                        }
                   }
            }
#endregion
#region 3
else if (gpsLocation == 3) { //Zone 3, Frogner
                if (social0 == "work" || social1 == "work") {
                        if (social0=="meeting" || social1=="meeting") {
						                            
createURLNotification("http://www.norway.com/directories/d_company.asp?lang=47&id=7424", appVO);
                        }
else if (social0=="preperation" || 
social1=="preperation") {
                            createURLNotification("url", appVO);
                        }
                        else if (social0=="own time" || social1=="own time") {
                            createURLNotification("url", appVO);
                        }
                  }
                if (social0 == "travel" || social1 == "travel") {
                        if (social0=="transport" || social1=="transport") 
{
                            
createURLNotification("http://trafikanten.no/", appVO);
                        }
else if (social0=="tube" || social1=="tube") {
						createURLNotification("url", appVO);
                        }
else if (social0=="car" || social1=="car") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="foot" || social1=="foot") {
                            createURLNotification("url", appVO);
                        }
                       }
                 if (social0 == "leisure" || social1 == "leisure") {
                        if (social0=="shopping" || social1=="shopping") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="cinema" || social1=="cinema") 
{
                            createURLNotification("url", appVO);
                        }
else if (social0=="sparetime" || 
social1=="sparetime") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="food" || social1=="food") {
                            createURLNotification("url", appVO);
                        }
                       
                    
                        }
                
            }
#endregion
			 #region 4
            else if (gpsLocation == 4) { //Zone 4, Grünerløkka
               if (social0 == "work" || social1 == "work") {
                        if (social0=="meeting" || social1=="meeting") {
                            createURLNotification("url", appVO);
// needed? break;
                        }
else if (social0=="preperation" || 
social1=="preperation") {
                            createURLNotification("url", appVO);
                        }
                        else if (social0=="own time" || social1=="own time") {
                            createURLNotification("url", appVO);
                        }
                       }
                if (social0 == "travel" || social1 == "travel") {
                        if (social0=="train" || social1=="train") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="tube" || social1=="tube") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="car" || social1=="car") {
                            createURLNotification("url", appVO);
                        }
                        else if (social0=="foot" || social1=="foot") {
                            createURLNotification("url", appVO);
                        }
                         }
                 if (social0 == "leisure" || social1 == "leisure") {
                        if (social0=="shopping" || social1=="shopping") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="culture" || 
social1=="culture") {
                            
createURLNotification("http://www.munch.museum.no/", appVO);
					}
					else if (social0=="sparetime" || 
social1=="sparetime") {
                            createURLNotification("url", appVO);
                        }
                        else if (social0=="food" || social1=="food") {
                            createURLNotification("url", appVO);
                        }
                       
                        }
                
            }
            #endregion
            #region 5
else if (gpsLocation == 5) { //Zone 5, St. Haugen
               if (social0 == "work" || social1 == "work") {
                        if (social0=="meeting" || social1=="meeting") {
                            createURLNotification("url", appVO);
                            // needed? break;
                        }
else if (social0=="preperation" || 
social1=="preperation") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="own time" || social1=="own time") {
                            createURLNotification("url", appVO);
                        }
                       }
                if (social0 == "travel" || social1 == "travel") {
                        if (social0=="train" || social1=="train") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="tube" || social1=="tube") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="car" || social1=="car") {
                            createURLNotification("url", appVO);
                        }
                        else if (social0=="foot" || social1=="foot") {
                            createURLNotification("url", appVO);
                       }
                }
                 if (social0 == "leisure" || social1 == "leisure") {
                        if (social0=="shopping" || social1=="shopping") {
                            
createURLNotification("http://www.bogstadveien.no/", appVO);
                        }
else if (social0=="cinema" || social1=="cinema") 
{
                            createURLNotification("url", appVO);
                        }
else if (social0=="sparetime" || 
social1=="sparetime") {
                            createURLNotification("url", appVO);
                        }
                        else if (social0=="food" || social1=="food") {
                            
createURLNotification("http://www.kaffebrenneriet.no/", appVO);
                        }
                      
                        }
                
            }
#endregion
#region 6
else if (gpsLocation == 6) { //for testing home
                if (social0 == "work" || social1 == "work") {
                    if (social0=="meeting" || social1=="meeting") {
                        createURLNotification("url", appVO);
						 // needed? break;
                    }
else if (social0=="preperation" || 
social1=="preperation") {
                        createURLNotification("url", appVO);
                    }
else if (social0=="own time" || social1=="own time") 
{
                        createURLNotification("url", appVO);
                    }
                }
if (social0 == "travel" || social1 == "travel") {
                        if (social0=="train" || social1=="train") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="tube" || social1=="tube") {
                            createURLNotification("url", appVO);
                        }
else if (social0=="car" || social1=="car") {
                            createURLNotification("url", appVO);
                        }
                       else if (social0=="foot" || social1=="foot") {
                            createURLNotification("url", appVO);
                        }
                       
                }
            }
#endregion
        }
        
} //end class
} //end namespace