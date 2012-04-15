package ac.uk.brunel.client.contextaware.service;

import ac.uk.brunel.contextaware.network.generated.PresenterActionProtobuf;

public interface PresenterService {
    public void performPresenterAction(final PresenterActionProtobuf.PresenterAction presenterAction);
}
