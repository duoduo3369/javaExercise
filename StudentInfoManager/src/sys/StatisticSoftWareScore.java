package sys;

import chart.MathBarChart;
import chart.MathPieChart;

public class StatisticSoftWareScore extends StatisticMajorScore {

	public StatisticSoftWareScore() {
		super();
		name = "软件工程成绩分析";
		pieChart = new MathPieChart(this);
		barChart = new MathBarChart(this);
	}
	public void printAverageScore(){
		System.out.println("软件工程:");
		super.printAverageScore();
	}
	public void printStudent() {
		System.out.println("---软件工程成绩分析排名---");
		System.out.println("分析时间: " + statisedTime);
		super.printStudent();
	}

	public void showPieChart() {
		pieChart.showChart();
	}

	public void showBarChart() {
		barChart.showChart();
	}
}
