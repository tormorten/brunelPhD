package ac.uk.brunel.server.contextaware.exception;


public class MeetingRoomException extends RuntimeException {
    public MeetingRoomException(final String message) {
        super(message);
    }

    public MeetingRoomException(final String message, final Throwable throwable) {
        super(message, throwable);
    }
}
