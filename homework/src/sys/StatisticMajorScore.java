package sys;

import java.text.DateFormat;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Iterator;
import java.util.TreeSet;

public abstract class StatisticMajorScore {
	public String statisedTime;
	protected int excellentNumber;
	protected int wellNumber;
	protected int middleNumber;
	protected int passNumber;
	protected int failNumber;
	protected int totalNumber;
	protected double GPA;
	protected TreeSet<MajorScore> majorSet;

	public StatisticMajorScore() {
		excellentNumber = 0;
		wellNumber = 0;
		middleNumber = 0;
		passNumber = 0;
		failNumber = 0;
		totalNumber = 0;
		majorSet = new TreeSet<MajorScore>();
	}

	public void add(MajorScore ms) {
		double score = ms.getScore() / 10;
		switch ((int) (Math.floor(score))) {
		case 10:
		case 9: {
			excellentNumber++;
			break;
		}
		case 8: {
			wellNumber++;
			break;
		}
		case 7: {
			middleNumber++;
			break;
		}
		case 6: {
			passNumber++;
			break;
		}
		case 5:
		case 4:
		case 3:
		case 2:
		case 1:
		case 0: {
			failNumber++;
			break;
		}

		}
		totalNumber++;
		majorSet.add(ms);
	}
	public double getExcellentPercent(){
		if(totalNumber == 0){
			return 0;
		}
		return excellentNumber / totalNumber;
	}
	public double getfailPercent(){
		if(totalNumber == 0){
			return 0;
		}
		return failNumber / totalNumber;
	}
	public double getWellPercent(){
		if(totalNumber == 0){
			return 0;
		}
		return wellNumber / totalNumber;
	}
	public double getMiddlePercent(){
		if(totalNumber == 0){
			return 0;
		}
		return middleNumber / totalNumber;
	}
	public double getPassPercent(){
		if(totalNumber == 0){
			return 0;
		}
		return passNumber / totalNumber;
	}

	public void setStatisedTime() {
		statisedTime = getCurrentDatetime();
	}

	public double calculateGPA(){
		if(totalNumber == 0){
			return 0;
		}
		double totalScore = 0;
		Iterator<MajorScore> iterator = majorSet.iterator();
		while (iterator.hasNext()) {
			MajorScore ms = (MajorScore) (iterator.next());
			totalScore += ms.getScore();
		}
		return totalScore / totalNumber;
	}
	public String getCurrentDatetime() {
		Date currentTime = new Date();
		DateFormat df = DateFormat.getDateTimeInstance(DateFormat.LONG,
				DateFormat.LONG);
		String dateString = df.format(currentTime);
		return dateString;
	}

	public void printStudent() {
		Iterator<MajorScore> iterator = majorSet.iterator();
		while (iterator.hasNext()) {
			MajorScore ms = (MajorScore) (iterator.next());
			System.out.print(ms.getStudent());
			System.out.println(": " + ms.getScore());
		}
	}

	public double getGPA() {
		GPA = calculateGPA();
		return GPA;
	}
}
