package ui;

import java.awt.Font;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.StandardChartTheme;
import org.jfree.data.general.DefaultPieDataset;

import sys.PercentObject;
import sys.Statistic;
import sys.StatisticMajorScore;

public abstract class PieChart extends Chart {
	protected DefaultPieDataset dataset;
	public PieChart(StatisticMajorScore statisticMajorScore){
		super(statisticMajorScore);
		this.dataset = new DefaultPieDataset();
	}
	protected void setValue(){
		this.percentArray = this.statisticMajorScore.getPercentArray();
		for (PercentObject po : percentArray) {
			this.dataset.setValue(po.name, po.percent);
		}
	}
}
