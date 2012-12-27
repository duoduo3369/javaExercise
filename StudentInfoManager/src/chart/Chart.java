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
