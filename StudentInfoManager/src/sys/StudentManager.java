package sys;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map.Entry;
import java.util.Set;

import score.MajorScore;

public class StudentManager{
	private HashMap<String,Student> studentMap;
	public StudentManager(){
		studentMap = new HashMap<String,Student>();
	}
	public StudentManager(HashSet<Student> set){
		studentMap = new HashMap<String,Student>();
		Iterator<Student> iteratorStudent = set.iterator();
		while(iteratorStudent.hasNext()){
			Student student = iteratorStudent.next();
			this.addStudent(student);
		}
	}
	public void addStudent(Student student){
		studentMap.put(student.getNo(), student);
	}
	public boolean deleteStudent(String no){
		if(studentMap.containsKey(no)){
			studentMap.remove(no);
			return true;
		}
		return false;
	}
	public Student getStudent(String no){
		if(studentMap.containsKey(no)){
			return studentMap.get(no);
		}
		return null;
	}
	public boolean changeStudentMajorScore(String no,MajorScore ms){
		Student student = this.getStudent(no);
		if(student != null){
			student.changeMajorScore(ms);
			return true;
		}
		return false;
	}
	public void addStudentMajorScore(String no,MajorScore ms){
		Student student = this.getStudent(no);
		if(student != null){
			student.addMajorScore(ms);
		}
	}
	
	public void printAllStudent(){
		Iterator<Entry<String, Student>> iteratorEntry = this.iterator();
		while(iteratorEntry.hasNext()){
			Entry<String, Student> entry = iteratorEntry.next();
			Student student = entry.getValue();
			System.out.println(student);
		}
	}
	public Iterator<Entry<String, Student>> iterator(){
		Set<Entry<String, Student>> entrys = studentMap.entrySet();
		Iterator<Entry<String, Student>> iteratorEntry = entrys.iterator();
		return iteratorEntry;
	}
}
