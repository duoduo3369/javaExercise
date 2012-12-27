package score;

import sys.Student;

public class MathScore extends MajorScore {
	private static final String courseName = "ÊýÑ§³É¼¨";
	public MathScore(double score,Student student) {
		super(score, student);
	}
	public String toString(){
		return courseName + ": " + score;
	}
	
}
