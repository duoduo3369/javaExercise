package sys;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedHashMap;
import java.util.Map.Entry;

import ui.MathPieChart;

public class StudentTest {

	public static void main(String[] args) {
		//HashSet<Student> set = new HashSet<Student>();
		
		StudentManager studentManager = new StudentManager();
		Student a = new Student("101","¿Óπ„");
		Student b = new Student("102","œƒ∫Ó‘®");
		Student c = new Student("103","’≈Ú¢");
		Student a1 = new Student("104","abc");
		Student b1 = new Student("105","c");
		Student c1 = new Student("106","bc");
		Student d1 = new Student("107","bc");
		
		MathScore ms = new MathScore(0, a); 
		MathScore ms2 = new MathScore(12, b); 
		MathScore ms3 = new MathScore(90.1,c);
		MathScore msa = new MathScore(80, a1); 
		MathScore msa1 = new MathScore(75, b1); 
		MathScore msb1 = new MathScore(62, c1); 
		MathScore msc1 = new MathScore(43, d1); 
		SoftWareScore ss = new SoftWareScore(79,a);
		
		
		a.changeMajorScore(msa);
		studentManager.addStudent(a);
		studentManager.addStudent(b);
		studentManager.addStudent(c);
		studentManager.addStudent(a1);
		studentManager.addStudent(b1);
		studentManager.addStudent(c1);
		studentManager.addStudent(d1);
		
		SaveStudentInfo.save(studentManager);
		StudentManager sm2 = ReadStudentInfo.read();
		sm2.printAllStudent();
		Student liguang = sm2.getStudent("101");
		sm2.changeStudentMajorScore("101", new MathScore(91.2, liguang));
		sm2.getStudent("101").printMajorScores();
		Statistic statistic = new Statistic(studentManager);
		statistic.statistic();
		statistic.statisticMathScore.showPieChart();
		statistic.statisticMathScore.printStudent();
		
	}
}
