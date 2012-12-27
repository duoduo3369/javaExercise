package chart;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;

import statistic.StatisticMajorScore;

public class SoftWarePieChart extends PieChart {

	public SoftWarePieChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
	}

	public void fillChartInfo() {
		this.chart = ChartFactory.createPieChart("������̳ɼ�", dataset, true, true,
				false);
		this.frame = new ChartFrame("������̳ɼ�������", chart);
	}
}
