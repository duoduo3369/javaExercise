package sys;

import ui.MathBarChart;
import ui.MathPieChart;

public class StatisticMathScore extends StatisticMajorScore {

	public StatisticMathScore() {
		super();
		name = "��ѧ�ɼ�����";
		pieChart = new MathPieChart(this);
		barChart = new MathBarChart(this);
	}

	public void printStudent() {
		System.out.println("---��ѧ�ɼ�����---");
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
