package chart;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;

import statistic.StatisticMajorScore;

public class MathPieChart extends PieChart {

	public MathPieChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
	}

	protected void fillChartInfo() {
		this.chart = ChartFactory.createPieChart("��ѧ�ɼ�", dataset, true, true,
				false);
		this.frame = new ChartFrame("��ѧ�ɼ�������", chart);
	}
}
