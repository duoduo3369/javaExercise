package sys;

import java.io.Serializable;
import java.util.HashSet;
import java.util.Iterator;
import java.util.HashMap;
import java.util.Map.Entry;
import java.util.Set;

public class Student implements Serializable{
	private String no;
	private String name;
	private HashMap<String,MajorScore> grades;
	public Student(String no, String name) {
		super();
		this.no = no;
		this.name = name;
		this.grades = new HashMap<String,MajorScore>();
	}
	public void addMajorScore(MajorScore ms){
		this.grades.put(ms.getClass().getName(),ms);
	}
	public void changeName(String name){
		this.name = name;
	}
	public boolean changeMajorScore(MajorScore ms){
		if(deleteMajorScore(ms)){
			addMajorScore(ms);
		}
		return false;
	}
	public boolean deleteMajorScore(MajorScore ms){
		String key = ms.getClass().getName();
		if(grades.containsKey(key)){
			grades.remove(key);
			return true;
		}
		return false;
	}
	public HashMap<String,MajorScore> getMajorScoreMap(){
		return grades;
	}
	public Iterator<Entry<String, MajorScore>> getMajorScoreMapIteratro(){
		Set<Entry<String, MajorScore>> entryset = grades.entrySet();
		Iterator<Entry<String, MajorScore>> iteratorEntry =  entryset.iterator();
		return iteratorEntry;
	}
	public void printMajorScores(){
		Iterator<Entry<String, MajorScore>> iterator = getMajorScoreMapIteratro();
		while(iterator.hasNext()){
			Entry<String, MajorScore> entry = iterator.next();
			System.out.println(entry.getValue());
		}
	}
	public int hashCode(){
		if(no == null){
			return super.hashCode();
		}
		int length = no.length();
		char ch;
		int result = 0;
		for(int i = 0; i < length; i++){
			result += no.charAt(i);
		}
		return result;
	}
	public String getNo() {
		return no;
	}
	public String getName() {
		return name;
	}
	public String toString() {
		return "ѧ��:" + no + " ����:" + name;
	}
	public boolean equals(Object obj){
		if(obj instanceof Student){
			Student s = (Student)obj;
			return s.no.equals(this.no);
		}
		return false;
	}
}
