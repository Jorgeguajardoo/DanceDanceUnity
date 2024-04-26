package DDUNoteJsonTimingCreator;
import java.util.*;
import java.io.*;


public class OffsetTesterCreator{
    public static void main(String[] args) throws Exception{
        Scanner scan = new Scanner(System.in);
        System.out.println("CREATOR FOR JSON FILES\nOutputted to terminal, please paste into notepad file");
        List<Note> list = new ArrayList<Note>();
        System.out.println("Please Enter Song BPM:");
        double bpm = scan.nextDouble();
        System.out.println("Please enter start of song frame offset");
        int frameoffset = scan.nextInt(); scan.nextLine();
        
        for(int beat = 0; beat<300; beat++){
            // System.out.println("Enter note formatted \"doubleBeatNumber,floatoffsetX\"");
            // System.out.println("Type \"FINISH\" to finish and print the json file string");
            // System.out.println("Type \"UNDO\" to remove the previous note");
            // if(list.size()>0){
                // System.out.println("Previous note info: " + list.get(list.size()-1).beat + " beat");
                // System.out.println("                    " + list.get(list.size()-1).positionX + " offset");
            // }
            // String[] arr = scan.nextLine().split(",");
            // if(arr[0].equals("FINISH")){
                // break;
            // }
            // if(arr[0].equals("UNDO")){
                // list.remove(list.size()-1);
            // }
            // if(arr.length!=2){
                // System.out.println("\fInvalid input.");
                // continue;
            // }
            // double beat = (Double.parseDouble(arr[0]));
            list.add(new Note((int)((beat-1.0)*(60.0/bpm)*100+frameoffset), 0, beat));
            // System.out.print("\f");
        }
        StringBuilder str = new StringBuilder("{\n  \"noteArray\": [\n");
        for(Note n : list){
            str.append("    {\n      \"frameoffset\":" + n.frameoffset + ",\n      \"positionX\":" + n.positionX + "\n    },\n");
        }
        str.deleteCharAt(str.length()-2);
        str.append("  ]\n}");
        System.out.print("\f");
        System.out.println("done");
        System.out.println("Enter name of file to write to");
        String name = scan.nextLine();
        try{
            File file = new File(name);
            if(file.createNewFile()){
                System.out.println("New file created");
            }else{
                System.out.println("File already exists, text will be overwritten");
            }
            FileWriter writer = new FileWriter(name);
            writer.write(str.toString());
            System.out.println("Wrote successfully");
            writer.close();
        }catch(IOException e){
            e.printStackTrace();
        }
        
    }
}