package ac.uk.brunel.client.contextaware.service;

import ac.uk.brunel.client.contextaware.dto.Meeting;

public interface MeetingStateHandler {
    public void setStartedMeeting(final Meeting meeting);
    public int increaseAndGetSlideNumber();
    public int decreaseAndGetSlideNumber();
    public String getMeetingId();
}
