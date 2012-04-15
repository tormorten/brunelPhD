package ac.uk.brunel.cloudhomescreen.dto;

import ac.uk.brunel.cloudhomescreen.util.DateStringUtil;

import javax.persistence.Id;
import java.text.SimpleDateFormat;
import java.util.Date;


public class Stats {
    @Id
    private String dateCreated;
    private String timeUsed;

    public Stats() {
    }

    public Stats(final String timeUsed) {
        dateCreated = DateStringUtil.getDateString();
        this.timeUsed = timeUsed;
    }

    public String getDateCreated() {
        return dateCreated;
    }

    public String getTimeUsed() {
        return timeUsed;
    }

    @Override
    public String toString() {
        final StringBuilder sb = new StringBuilder();
        sb.append("Stats");
        sb.append("{dateCreated='").append(dateCreated).append('\'');
        sb.append(", timeUsed='").append(timeUsed).append('\'');
        sb.append('}');
        return sb.toString();
    }
}
