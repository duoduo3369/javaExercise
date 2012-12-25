package ui;

import java.awt.Dimension;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import org.jfree.chart.ChartPanel;
import org.jfree.chart.plot.PlotOrientation;

import sys.StatisticMajorScore;

public class MathBarChart extends BarChart {

	public MathBarChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
		// TODO Auto-generated constructor stub
	}

	protected void fillChartInfo() {
		this.chart = ChartFactory.createBarChart(
				"��ѧ�ɼ�", // chart title
				"����", // domain axis label
				"����", // range axis label
				dataset, // data
				PlotOrientation.VERTICAL, // orientation
				true, // include legend
				true, // tooltips?
				false // URLs?
				);
		/*
		ChartPanel chartPanel = new ChartPanel(chart, false);
		chartPanel.setPreferredSize(new Dimension(500, 270));
		setContentPane(chartPanel);
		*/
		this.frame = new ChartFrame("��ѧ�ɼ�������", chart);

	}

}
