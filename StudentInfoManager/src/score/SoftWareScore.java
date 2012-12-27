package score;

import sys.Student;

public class SoftWareScore extends MajorScore {
	private static final String courseName = "软件工程成绩";
	public SoftWareScore(double score, Student student) {
		super(score, student);
	}
	public String toString(){
		return courseName + ": " + score;
	}
}
