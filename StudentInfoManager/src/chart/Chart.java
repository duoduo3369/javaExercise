package chart;

import java.awt.Font;

import org.jfree.chart.ChartFactory;
import org.jfree.chart.ChartFrame;
import org.jfree.chart.JFreeChart;
import org.jfree.chart.StandardChartTheme;

import statistic.StatisticMajorScore;
import sys.PercentObject;

public abstract class Chart {
	protected StatisticMajorScore statisticMajorScore;
	protected JFreeChart chart;
	protected ChartFrame frame;
	protected PercentObject[] percentArray;
	public Chart(StatisticMajorScore statisticMajorScore){
		this.statisticMajorScore = statisticMajorScore;
	}
	protected void initChart(){		
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
	protected abstract void setValue();
	protected abstract void fillChartInfo();
	public void showChart(){
		initChart();
		setValue();
		fillChartInfo();
		frame.pack();
		frame.setVisible(true);
	}
}
