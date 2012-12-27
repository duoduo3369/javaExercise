package chart;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;

import statistic.StatisticMajorScore;

public class SoftWarePieChart extends PieChart {

	public SoftWarePieChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
	}

	public void fillChartInfo() {
		this.chart = ChartFactory.createPieChart("软件工程成绩", dataset, true, true,
				false);
		this.frame = new ChartFrame("软件工程成绩分析表", chart);
	}
}
