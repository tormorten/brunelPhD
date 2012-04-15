package ac.uk.brunel.client.contextaware.integration.presenter;


public interface PresenterEventSender {
    public void sendPresenterEvent(final String meetingId, final int currentSlideNumber);
}
