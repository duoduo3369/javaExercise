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

public abstract class PieChart {
	protected StatisticMajorScore statisticMajorScore;
	protected DefaultPieDataset dataset;
	protected JFreeChart chart;
	protected ChartFrame frame;
	protected PercentObject[] percentArray;
	public PieChart(StatisticMajorScore statisticMajorScore){
		this.statisticMajorScore = statisticMajorScore;
		this.dataset = new DefaultPieDataset();
	}
	protected void initChart(){
		this.percentArray = this.statisticMajorScore.getPercentArray();
		for (PercentObject po : percentArray) {
			this.dataset.setValue(po.name, po.percent);
		}
		// ����������ʽ
		StandardChartTheme standardChartTheme = new StandardChartTheme("CN");
		// ���ñ�������
		standardChartTheme.setExtraLargeFont(new Font("����", Font.BOLD, 20));
		// ����ͼ��������
		standardChartTheme.setRegularFont(new Font("����", Font.PLAIN, 15));
		// �������������
		standardChartTheme.setLargeFont(new Font("����", Font.PLAIN, 15));
		// Ӧ��������ʽ
		ChartFactory.setChartTheme(standardChartTheme);
	}
	public abstract void fillChartInfo();
	public void showChart(){
		initChart();
		fillChartInfo();
		frame.pack();
		frame.setVisible(true);
	}
}
