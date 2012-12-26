package chart;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import org.jfree.chart.plot.PlotOrientation;

import sys.StatisticMajorScore;

public class MathBarChart extends BarChart {

	public MathBarChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
	}

	protected void fillChartInfo() {
		this.chart = ChartFactory.createBarChart(
				"数学成绩", // chart title
				"分类", // domain axis label
				"人数", // range axis label
				dataset, // data
				PlotOrientation.VERTICAL, // orientation
				true, // include legend
				true, // tooltips?
				false // URLs?
				);
		this.frame = new ChartFrame("数学成绩分析表", chart);

	}

}
