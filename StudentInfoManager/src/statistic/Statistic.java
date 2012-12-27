package statistic;

import java.util.Iterator;
import java.util.Map.Entry;

import score.MajorScore;
import score.MathScore;
import score.SoftWareScore;
import sys.Student;
import sys.StudentManager;

public class Statistic {
	public StatisticMathScore statisticMathScore; 
	public StatisticSoftWareScore statisticSoftWareScore;
	private StudentManager studentManager;
	public Statistic(StudentManager studentManager){
		statisticMathScore = new StatisticMathScore();
		statisticSoftWareScore = new StatisticSoftWareScore();
		this.studentManager = studentManager;
	}
	public void statistic(){
		Iterator<Entry<String, Student>> iteratorStudent = studentManager.iterator();
		statisticMathScore.setStatisedTime();
		statisticSoftWareScore.setStatisedTime();
		while(iteratorStudent.hasNext()){
			Entry<String, Student> entryStudent = iteratorStudent.next();
			Student student = entryStudent.getValue();
			Iterator<Entry<String, MajorScore>> iteratorMajorMap = student.getMajorScoreMapIteratro();
			while(iteratorMajorMap.hasNext()){
				Entry<String, MajorScore> entryScore = iteratorMajorMap.next();
				MajorScore ms = entryScore.getValue();
				if(ms instanceof MathScore){
					statisticMathScore.add(ms);
				}else if(ms instanceof SoftWareScore){
					statisticSoftWareScore.add(ms);
				}
			}
		}
	}
}
