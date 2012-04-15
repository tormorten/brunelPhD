package ac.uk.brunel.cloudhomescreen.config;

import java.io.IOException;
import java.util.Properties;


public enum PropertiesLoader {
    APP("/application.properties");

    private final Properties properties;

    private PropertiesLoader(final String propertiesFile) {
        properties = new Properties();
        try {
            properties.load(getClass().getResourceAsStream(propertiesFile));
        } catch (IOException io) {
            throw new IllegalStateException("Unable to find application.properties file", io);
        }
    }

    public String getProperty(final String key) {
        return properties.getProperty(key, "");
    }
}
