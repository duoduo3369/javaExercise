package score;

import sys.Student;

public class MathScore extends MajorScore {
	private static final String courseName = "��ѧ�ɼ�";
	public MathScore(double score,Student student) {
		super(score, student);
	}
	public String toString(){
		return courseName + ": " + score;
	}
	
}
