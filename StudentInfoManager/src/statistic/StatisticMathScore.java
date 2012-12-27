package statistic;

import chart.MathBarChart;
import chart.MathPieChart;

public class StatisticMathScore extends StatisticMajorScore {

	public StatisticMathScore() {
		super();
		name = "��ѧ�ɼ�����";
		pieChart = new MathPieChart(this);
		barChart = new MathBarChart(this);
	}

	public void printStudent() {
		System.out.println("---��ѧ�ɼ���������---");
		System.out.println("����ʱ��: " + statisedTime);
		super.printStudent();
	}

	public void printAverageScore(){
		System.out.println("��ѧ:");
		super.printAverageScore();
	}
	public void showPieChart() {
		pieChart.showChart();
	}

	public void showBarChart() {
		barChart.showChart();
	}

}
