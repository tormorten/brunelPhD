package ac.uk.brunel.client.contextaware.service;

import ac.uk.brunel.client.contextaware.dto.Meeting;
import com.google.inject.Singleton;

import java.util.concurrent.atomic.AtomicInteger;

@Singleton
public class MeetingStateHandlerImpl implements MeetingStateHandler {
    private String meetingId = "";
    private final AtomicInteger currentSlideNumber = new AtomicInteger(0);

    public MeetingStateHandlerImpl() {
    }

    public synchronized  void setStartedMeeting(final Meeting meeting) {
        this.meetingId = meeting.getMeetingId();
    }

    public int increaseAndGetSlideNumber() {
        return currentSlideNumber.incrementAndGet();
    }

    public int decreaseAndGetSlideNumber() {
        return currentSlideNumber.decrementAndGet();
    }

    public synchronized String getMeetingId() {
        return meetingId;
    }
}
