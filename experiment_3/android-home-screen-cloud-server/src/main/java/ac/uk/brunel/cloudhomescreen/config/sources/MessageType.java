package ac.uk.brunel.cloudhomescreen.config.sources;


public enum MessageType {
    APPLICATION(1),
    PUSH_MESSAGE(2);

    private final int type;

    private MessageType(final int type) {
        this.type = type;
    }

    public int getType() {
        return type;
    }
}
