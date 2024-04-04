package DDUNoteJsonTimingCreator;

public class Note{
    public int frameoffset;
    public float positionX;
    public double beat;
    public Note(int f, float p, double b){
        this.frameoffset = f;
        this.positionX = p;
        this.beat = b;
    }
}