package sys;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map.Entry;

public class StudentTest {

	public static void main(String[] args) {
		//HashSet<Student> set = new HashSet<Student>();
		
		StudentManager studentManager = new StudentManager();
		Student a = new Student("101","¿Óπ„");
		MathScore ms = new MathScore(0, a); 
		SoftWareScore ss = new SoftWareScore(79,a);
		//a.addMajorScore(ms);
		//a.addMajorScore(ss);
		
		Student b = new Student("102","œƒ∫Ó‘®");
		MathScore ms2 = new MathScore(212, b); 
		//b.addMajorScore(ms2);
		
		Student c = new Student("103","’≈Ú¢");
		MathScore ms3 = new MathScore(90.1,c);
		//c.addMajorScore(ms3);
		
		MathScore msa = new MathScore(80, a); 
		a.changeMajorScore(msa);
		studentManager.addStudent(a);
		studentManager.addStudent(b);
		studentManager.addStudent(c);
		Student d = studentManager.getStudent("101");
		d.changeMajorScore(new MathScore(900,d));
		studentManager.printAllStudent();
		
		
		SaveStudentInfo.save(studentManager);
		StudentManager sm2 = ReadStudentInfo.read();
		System.out.println("!!=====in && out========!!");
		Iterator<Entry<String, Student>> iter = sm2.iterator();
		while(iter.hasNext()){
			Entry<String, Student> entry = iter.next();
			Student s = entry.getValue();
			System.out.println("!-------"+s+"---------!");
			s.printMajorScores();
		}
		sm2.printAllStudent();
		Student liguang = sm2.getStudent("101");
		sm2.changeStudentMajorScore("101", new MathScore(91.2, liguang));
		sm2.getStudent("101").printMajorScores();
		
		/*
		set.add(a);
		set.add(b);
		set.add(c);
		SaveStudentInfo.save(set);
		set = ReadStudentInfo.read();
		Iterator<Student> iterator = set.iterator();
		while(iterator.hasNext()){
			Student studentInSet = iterator.next(); 
			System.out.println("!!" + studentInSet);
			studentInSet.printMajorScores();
		}
		/*
		Statistic statistic = new Statistic();
		statistic.statistic(set);
		statistic.statisticMathScore.printStudent();
		*/
		
	}
}
