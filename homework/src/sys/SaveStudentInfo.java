package sys;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map.Entry;

public class SaveStudentInfo {
	private static String filename = "stdentinfo.ds";
	public static void save(StudentManager studentManager){
		try {
			File f = new File(filename); 
			FileOutputStream fout = new FileOutputStream(f,true);
			MyObjectOutputStream moos = MyObjectOutputStream.newInstance(f, fout);
			Entry<String, Student> entry;
			Iterator<Entry<String, Student>> iterator = studentManager.iterator();
			while(iterator.hasNext()){
				entry = iterator.next();
				Student student = entry.getValue();
				moos.writeObject(student);
				moos.flush();
			}
			moos.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
	}
	public static void save(StudentManager studentManager,boolean append){
		if(append == true){
			save(studentManager);
			return ;
		}
		FileOutputStream fout;
		try {
			fout = new FileOutputStream(filename);
			ObjectOutputStream oout = new ObjectOutputStream(fout);
			Iterator<Entry<String, Student>> iterator = studentManager.iterator();
			Entry<String, Student> entry;
			while(iterator.hasNext()){
				entry = iterator.next();
				Student student = entry.getValue();
				oout.writeObject(student);
				oout.flush();
			}
			oout.close();
		} catch (FileNotFoundException e) {
			e.printStackTrace();
		} catch (IOException e) {
			e.printStackTrace();
		}
		
	}
	
}
