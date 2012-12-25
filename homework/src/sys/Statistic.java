package sys;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.Map.Entry;
import java.util.Set;

public class Statistic {
	public StatisticMathScore statisticMathScore; 
	public Statistic(){
		statisticMathScore = new StatisticMathScore();
	}
	public void statistic(HashSet<Student> studentSet){
		Iterator<Student> iteratorStudent = studentSet.iterator();
		while(iteratorStudent.hasNext()){
			Student student = iteratorStudent.next();
			Iterator<Entry<String, MajorScore>> iteratorMajorMap = student.getMajorScoreMapIteratro();
			while(iteratorMajorMap.hasNext()){
				Entry<String, MajorScore> entry = iteratorMajorMap.next();
				MajorScore ms = entry.getValue();
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
