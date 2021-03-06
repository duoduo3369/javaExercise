package statistic;

import chart.MathBarChart;
import chart.MathPieChart;

public class StatisticMathScore extends StatisticMajorScore {

	public StatisticMathScore() {
		super();
		name = "数学成绩分析";
		pieChart = new MathPieChart(this);
		barChart = new MathBarChart(this);
	}

	public void printStudent() {
		System.out.println("---数学成绩分析排名---");
		System.out.println("分析时间: " + statisedTime);
		super.printStudent();
	}

	public void printAverageScore(){
		System.out.println("数学:");
		super.printAverageScore();
	}
	public void showPieChart() {
		pieChart.showChart();
	}

	public void showBarChart() {
		barChart.showChart();
	}

}
