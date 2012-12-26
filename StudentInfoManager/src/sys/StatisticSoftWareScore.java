package sys;

import chart.MathBarChart;
import chart.MathPieChart;

public class StatisticSoftWareScore extends StatisticMajorScore {

	public StatisticSoftWareScore() {
		super();
		name = "������̳ɼ�����";
		pieChart = new MathPieChart(this);
		barChart = new MathBarChart(this);
	}
	public void printAverageScore(){
		System.out.println("�������:");
		super.printAverageScore();
	}
	public void printStudent() {
		System.out.println("---������̳ɼ���������---");
		System.out.println("����ʱ��: " + statisedTime);
		super.printStudent();
	}

	public void showPieChart() {
		pieChart.showChart();
	}

	public void showBarChart() {
		barChart.showChart();
	}
}
