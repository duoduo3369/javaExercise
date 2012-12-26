package chart;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import sys.StatisticMajorScore;

public class MathPieChart extends PieChart {

	public MathPieChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
	}

	public void fillChartInfo() {
		this.chart = ChartFactory.createPieChart("��ѧ�ɼ�", dataset, true, true,
				false);
		this.frame = new ChartFrame("��ѧ�ɼ�������", chart);
	}
}
