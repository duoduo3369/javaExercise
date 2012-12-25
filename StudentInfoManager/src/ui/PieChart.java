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
		// 创建主题样式
		StandardChartTheme standardChartTheme = new StandardChartTheme("CN");
		// 设置标题字体
		standardChartTheme.setExtraLargeFont(new Font("隶书", Font.BOLD, 20));
		// 设置图例的字体
		standardChartTheme.setRegularFont(new Font("宋书", Font.PLAIN, 15));
		// 设置轴向的字体
		standardChartTheme.setLargeFont(new Font("宋书", Font.PLAIN, 15));
		// 应用主题样式
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
