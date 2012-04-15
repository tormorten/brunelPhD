package ac.uk.brunel.server.contextaware.exception.calendar;

import ac.uk.brunel.server.contextaware.exception.MeetingRoomException;


public class CalendarCommunicationException extends MeetingRoomException {
    
    public CalendarCommunicationException(final String message) {
        super(message);
    }

    public CalendarCommunicationException(String message, Throwable throwable) {
        super(message, throwable);
    }
}
