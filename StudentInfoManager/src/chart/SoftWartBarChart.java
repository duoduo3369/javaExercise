package chart;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import org.jfree.chart.plot.PlotOrientation;

import statistic.StatisticMajorScore;

public class SoftWartBarChart extends BarChart {

	public SoftWartBarChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
	}

	protected void fillChartInfo() {
		this.chart = ChartFactory.createBarChart(
				"������̳ɼ�", // chart title
				"����", // domain axis label
				"����", // range axis label
				dataset, // data
				PlotOrientation.VERTICAL, // orientation
				true, // include legend
				true, // tooltips?
				false // URLs?
				);
		this.frame = new ChartFrame("������̳ɼ�������", chart);

	}

}
