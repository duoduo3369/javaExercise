package sys;

import ui.MathPieChart;

public class StatisticMathScore extends StatisticMajorScore {
	
	public StatisticMathScore(){
		super();{
		pieChart = new MathPieChart(this);
	}
	}
	public void printStudent(){
		System.out.println("---��ѧ�ɼ�����---");
		System.out.println("����ʱ��: " + statisedTime);
		super.printStudent();
	}
	public void showPieChart() {
		pieChart.showChart();
	}
}
