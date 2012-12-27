package score;

import java.awt.Font;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.StandardChartTheme;

import sys.Student;

public class MathScore extends MajorScore {
	private static final String courseName = "ÊýÑ§³É¼¨";
	public MathScore(double score,Student student) {
		super(score, student);
	}
	/*
	public boolean equals(Object obj){
		if(obj instanceof MathScore){
		
		
		
			MathScore ms = (MathScore)obj;
			System.out.println("mathscore.java"+"ms.student.equals(this.student)" + ms.student.equals(this.student));
			return ms.student.equals(this.student);
		}
		return false;
	}
	*/
	public String toString(){
		return courseName + ": " + score;
	}
	
}
