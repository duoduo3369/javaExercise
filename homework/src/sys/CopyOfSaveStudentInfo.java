package sys;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;
import java.util.HashSet;
import java.util.Iterator;

public class CopyOfSaveStudentInfo {
	private static String filename = "stdentinfo.ds";
	public static void save(HashSet<Student> set){
		try {
			File f = new File(filename); 
			FileOutputStream fout = new FileOutputStream(f,true);
			MyObjectOutputStream moos = MyObjectOutputStream.newInstance(f, fout);
			Student student = null;
			Iterator<Student> iterator = set.iterator();
			while(iterator.hasNext()){
				student = iterator.next();
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
	public static void save(HashSet<Student> set,boolean append){
		if(append == true){
			save(set);
			return ;
		}
		FileOutputStream fout;
		try {
			fout = new FileOutputStream(filename);
			ObjectOutputStream oout = new ObjectOutputStream(fout);
			Student student = null;
			Iterator<Student> iterator = set.iterator();
			while(iterator.hasNext()){
				student = iterator.next();
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
