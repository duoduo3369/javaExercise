package sys;

import java.util.Iterator;
import java.util.Map.Entry;

public class Statistic {
	public StatisticMathScore statisticMathScore; 
	private StudentManager studentManager;
	public Statistic(StudentManager studentManager){
		statisticMathScore = new StatisticMathScore();
		this.studentManager = studentManager;
	}
	public void statistic(){
		Iterator<Entry<String, Student>> iteratorStudent = studentManager.iterator();
		while(iteratorStudent.hasNext()){
			Entry<String, Student> entryStudent = iteratorStudent.next();
			Student student = entryStudent.getValue();
			Iterator<Entry<String, MajorScore>> iteratorMajorMap = student.getMajorScoreMapIteratro();
			while(iteratorMajorMap.hasNext()){
				Entry<String, MajorScore> entryScore = iteratorMajorMap.next();
				MajorScore ms = entryScore.getValue();
				String className = ms.getClass().getName();
				switch(className){
				case "sys.MathScore":{
					statisticMathScore.add(ms);
					break;
				}
				}
			}
		}
	}
}
