package ac.uk.brunel.benchmark.server.sender.c2dm;

import com.googlecode.sc2dm.server.sender.AuthTokenUpdater;
import com.googlecode.sc2dm.server.sender.C2DMMessageSender;
import com.googlecode.sc2dm.server.sender.MessageData;
import com.googlecode.sc2dm.server.sender.MessageSender;

/**
 * @Author Jarle Hansen (jarle@jarlehansen.net)
 * Created: 5:47 PM - 11/22/11
 */
public class C2DMSender {
    private String storedToken = "DQAAAM8AAABjywVhdmFfOPN3AQKtKYznekDhhdyknbZhYdY79KxULbwkGBgdQmyXLoWQsNUr7Yp80ada-FSRDk6NqARNdWcbDriN4kPZAj2CK6tFI1DepLy2V_ZRchhCgPX5YC8xCOW3_sgfF2M6uRTPDcv3UMVdN0jgC_BF4VS0wP4B9NRQjjI6Q-lft_czr0ygn1Rwbn_RLcoQJD1VPNyzGMo_-vVwRCshHzURWt6K1SSx7ii7xV7d3UrsN15UTs2fjMoB4H_z990yPFO_AZiEIMuT0HDd";

    private AuthTokenUpdater authTokenUpdater = new AuthTokenUpdater() {
        @Override
        public void updateToken(String updatedToken) {
            storedToken = updatedToken;
        }
    };

    public void send(String token, String message, String regId) {
        if (storedToken == null) {
            storedToken = token;
        }

        MessageData messageData = new MessageData(message, regId);

        MessageSender messageSender = C2DMMessageSender.createMessageSender(storedToken, authTokenUpdater);
        messageSender.sendMessage(messageData);
    }
}
