package score;

import sys.Student;

public class SoftWareScore extends MajorScore {
	private static final String courseName = "������̳ɼ�";
	public SoftWareScore(double score, Student student) {
		super(score, student);
	}
	public String toString(){
		return courseName + ": " + score;
	}
}
