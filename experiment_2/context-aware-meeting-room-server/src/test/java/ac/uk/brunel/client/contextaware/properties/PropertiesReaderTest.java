package ac.uk.brunel.client.contextaware.properties;

import org.junit.Test;

import static org.junit.Assert.assertEquals;
import static org.junit.Assert.assertTrue;

public class PropertiesReaderTest {
    private static final String TEST_KEY = "server.cloud.service.presentermeetinglist";
    private static final String TEST_VALUE = "presenterMeetingList";

    @Test
    public void testGetValidKey() {
        final String value = PropertiesReader.SERVER_APP.get(TEST_KEY);
        assertEquals(TEST_VALUE, value);
    }

    @Test
    public void testGetInvalidKey() {
        final String value = PropertiesReader.SERVER_APP.get("not a key");
        assertTrue(value.length() == 0);
    }

    @Test
    public void testGetNullKey() {
        final String value = PropertiesReader.SERVER_APP.get(null);
        assertTrue(value.length() == 0);
    }

    @Test
    public void testGetCloudServiceName() {
        final String value = PropertiesReader.SERVER_APP.getCloudServiceName(TEST_KEY);
        assertTrue(value.contains("http://"));
        assertTrue(value.length() > TEST_VALUE.length());
    }
}
