package chart;

import org.jfree.data.general.DefaultPieDataset;

import statistic.StatisticMajorScore;
import sys.PercentObject;

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
