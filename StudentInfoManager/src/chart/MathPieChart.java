package chart;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import sys.StatisticMajorScore;

public class MathPieChart extends PieChart {

	public MathPieChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
	}

	public void fillChartInfo() {
		this.chart = ChartFactory.createPieChart("数学成绩", dataset, true, true,
				false);
		this.frame = new ChartFrame("数学成绩分析表", chart);
	}
}
