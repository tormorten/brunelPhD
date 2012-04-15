package ac.uk.brunel.server.contextaware.integration.calendar;

import com.google.gdata.client.calendar.CalendarService;


public interface CalendarLogon {
    void accountLogon(final CalendarService calendarService);
}
