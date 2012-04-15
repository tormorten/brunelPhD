package ac.uk.brunel.server.contextaware.integration.calendar;

import ac.uk.brunel.server.contextaware.dto.Meeting;

import java.util.Date;
import java.util.List;


public interface CalendarIntegration {
    public List<Meeting> getMeetingList(Date fromDate, Date toDate);
}
