package ac.uk.brunel.benchmark.server.sender.ua;

import org.apache.commons.codec.binary.Base64;
import org.slf4j.Logger;
import org.slf4j.LoggerFactory;

import java.io.IOException;
import java.io.OutputStreamWriter;
import java.net.HttpURLConnection;
import java.net.MalformedURLException;
import java.net.URL;

/**
 * @Author Jarle Hansen (jarle@jarlehansen.net)
 * Created: 5:48 PM - 11/22/11
 */
public class UrbanAirshipSender {
    private static final Logger logger = LoggerFactory.getLogger(UrbanAirshipSender.class);

    private URL url;

    public UrbanAirshipSender() {
        try {
            url = new URL("https://go.urbanairship.com/api/push/");
        } catch (MalformedURLException mal) {
            throw new IllegalStateException("Malformed url", mal);
        }
    }

    public void send(String message, String regId) {
        try {
            HttpURLConnection connection = (HttpURLConnection) url.openConnection();
            connection.setDoOutput(true);
            connection.setRequestMethod("POST");
            connection.setRequestProperty("Content-type", "application/json");

            String authString = "zjBnRrOJTli38yggCggWTQ:7yxnpGL-SgieZMZAUTlA1A";
            byte[] authEncoded = Base64.encodeBase64(authString.getBytes());
            String authStringEncoded = new String(authEncoded);
            connection.setRequestProperty("Authorization", "Basic " + authStringEncoded);

            OutputStreamWriter writer = new OutputStreamWriter(connection.getOutputStream());
            writer.write("{\"android\": {\"alert\": \"" + message + "\"}, \"apids\": [\"" + regId + "\"]}");
            writer.close();

            int responseCode = connection.getResponseCode();
            logger.info("Response code: {}", responseCode);
        } catch (IOException io) {
            logger.error("Unable to send message", io);
        }

    }
}
/*

public String getAuthToken() {
        String token = "";

        try {
            HttpURLConnection connection = authenticationData.getHttpConnection();
            connection.setDoOutput(true);
            connection.setRequestMethod("POST");
            connection.setRequestProperty("Content-type", "application/x-www-form-urlencoded;charset=UTF-8");

            OutputStreamWriter writer = new OutputStreamWriter(connection.getOutputStream());
            writer.write(authenticationData.createAuthString());
            writer.close();

            StringBuilder response = new StringBuilder();
            //Get the response
            if (connection.getResponseCode() == HttpURLConnection.HTTP_OK) {
                BufferedReader rd = new BufferedReader(new
                        InputStreamReader(connection.getInputStream()));
                String line;

                while ((line = rd.readLine()) != null) {
                    response.append(line);
                }

                rd.close();
            }

            if (response.length() == 0) {
                logger.warn("Unable to retrieve token, http response is null");
            } else {
                String[] parts = response.toString().split("=");
                token = parts[parts.length - 1];

                logger.info("Token received: " + token);
            }
        } catch (IOException io) {
            logger.error("Unable to connect to the c2dm authentication url", io);
            throw new IllegalStateException("Unable to connect to the c2dm authentication url");
        }

        return token;
    }
 */
