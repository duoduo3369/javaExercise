package sys;

import ui.MathPieChart;

public class StatisticMathScore extends StatisticMajorScore {
	
	public StatisticMathScore(){
		super();{
		pieChart = new MathPieChart(this);
	}
	}
	public void printStudent(){
		System.out.println("---数学成绩分析---");
		System.out.println("分析时间: " + statisedTime);
		super.printStudent();
	}
	public void showPieChart() {
		pieChart.showChart();
	}
}
