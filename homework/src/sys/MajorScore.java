package sys;

import java.io.Serializable;

public abstract class MajorScore implements Serializable,Comparable{
	
	public MajorScore(double score,Student student) {
		super();
		this.score = score;
		this.student = student;
		this.student.addMajorScore(this);
	}

	protected double score;
	protected Student student;
	public int hashCode(){
		return this.student.hashCode();
	}
	
	public double getScore() {
		return score;
	}
	public Student getStudent(){
		return student;
	}
	public void setScore(double score) {
		this.score = score;
	}
	public boolean equals(Object obj){
		if(obj instanceof MathScore){
			MathScore ms = (MathScore)obj;
			System.out.println("majorscore.java"+"ms.student.equals(this.student)" + ms.student.equals(this.student));
			return ms.student.equals(this.student);
		}
		return false;
	}
	public int compareTo(Object obj) {
		if(obj instanceof MajorScore){
			MajorScore ms = (MajorScore)obj;
			if(ms.getScore() > this.score){
				return 1;
			}
			else if(ms.getScore() == this.score){
				return 0;
			}else{
				return -1;
			}
		}
		return 0;
	}
}
