package sys;

import java.text.DateFormat;
import java.util.Date;
import java.util.Iterator;
import java.util.TreeSet;

import chart.BarChart;
import chart.PieChart;

public abstract class StatisticMajorScore {
	protected String name;
	public String statisedTime;
	protected int excellentNumber;
	protected int wellNumber;
	protected int middleNumber;
	protected int passNumber;
	protected int failNumber;
	protected int totalNumber;
	protected double GPA;
	protected TreeSet<MajorScore> majorSet;
	protected PercentObject[] percentArray;
	protected PieChart pieChart;
	protected BarChart barChart;

	public StatisticMajorScore() {
		excellentNumber = 0;
		wellNumber = 0;
		middleNumber = 0;
		passNumber = 0;
		failNumber = 0;
		totalNumber = 0;
		majorSet = new TreeSet<MajorScore>();
		initPercentArray();
	}

	public String getName() {
		return this.name;
	}

	private void initPercentArray() {
		percentArray = new PercentObject[5];
		percentArray[0] = new PercentObject("优秀");
		percentArray[1] = new PercentObject("良好");
		percentArray[2] = new PercentObject("中等");
		percentArray[3] = new PercentObject("及格");
		percentArray[4] = new PercentObject("不及格");
	}

	public void add(MajorScore ms) {
		double score = ms.getScore() / 10;
		totalNumber++;
		majorSet.add(ms);
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
		default: {
			totalNumber--;
		}

		}

	}

	protected void updatePercentArray() {
		/*
		 * percentArray[0].percent = getExcellentPercent();
		 * percentArray[1].percent = getWellPercent(); percentArray[2].percent =
		 * getMiddlePercent(); percentArray[3].percent = getPassPercent();
		 * percentArray[4].percent = getfailPercent();
		 */
		percentArray[0].percent = this.excellentNumber;
		percentArray[1].percent = this.wellNumber;
		percentArray[2].percent = this.middleNumber;
		percentArray[3].percent = this.passNumber;
		percentArray[4].percent = this.failNumber;
	}

	public PercentObject[] getPercentArray() {
		updatePercentArray();
		return percentArray;
	}

	public double getExcellentPercent() {
		if (totalNumber == 0) {
			return 0;
		}
		return excellentNumber * 1.0 / totalNumber;
	}

	public double getfailPercent() {
		if (totalNumber == 0) {
			return 0;
		}
		return failNumber * 1.0 / totalNumber;
	}

	public double getWellPercent() {
		if (totalNumber == 0) {
			return 0;
		}
		return wellNumber * 1.0 / totalNumber;
	}

	public double getMiddlePercent() {
		if (totalNumber == 0) {
			return 0;
		}
		return middleNumber * 1.0 / totalNumber;
	}

	public abstract void showPieChart();

	public abstract void showBarChart();

	public double getPassPercent() {
		if (totalNumber == 0) {
			return 0;
		}
		return passNumber * 1.0 / totalNumber;
	}

	public void setStatisedTime() {
		statisedTime = getCurrentDatetime();
	}

	public double calculateGPA() {
		if (totalNumber == 0) {
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

	public void printAverageScore() {
		System.out
				.println("平均成绩：" + getAverageScore() + "\t总人数:" + totalNumber);
	}

	public double getGPA() {
		GPA = calculateGPA();
		return GPA;
	}

	public int getExcellentNumber() {
		return excellentNumber;
	}

	public int getWellNumber() {
		return wellNumber;
	}

	public int getMiddleNumber() {
		return middleNumber;
	}

	public int getPassNumber() {
		return passNumber;
	}

	public int getFailNumber() {
		return failNumber;
	}

	public int getTotalNumber() {
		return totalNumber;
	}

	public double getAverageScore() {
		if (totalNumber == 0) {
			return 0;
		}
		double totalScore = 0;
		Iterator<MajorScore> iter = majorSet.iterator();
		while (iter.hasNext()) {
			totalScore += iter.next().getScore();
		}
		return totalScore / totalNumber;
	}

	public TreeSet<MajorScore> getMajorSet() {
		return majorSet;
	}
}
