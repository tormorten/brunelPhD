package ac.uk.brunel.cloudhomescreen.util;

import java.text.SimpleDateFormat;
import java.util.Date;


public enum DateStringUtil {

    ;

    private static final SimpleDateFormat sdf = new SimpleDateFormat("dd/MM/yyyy - HH:mm:ss,SSSS");

    public static String getDateString() {
        return sdf.format(new Date());
    }
}
