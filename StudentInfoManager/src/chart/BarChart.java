package chart;

import org.jfree.data.category.DefaultCategoryDataset;

import statistic.StatisticMajorScore;
import sys.PercentObject;

public abstract class BarChart extends Chart {
	protected DefaultCategoryDataset dataset;

	public BarChart(StatisticMajorScore statisticMajorScore) {
		super(statisticMajorScore);
		this.dataset = new DefaultCategoryDataset();
	}

	protected void setValue() {
		this.percentArray = this.statisticMajorScore.getPercentArray();
		for (PercentObject po : percentArray) {
			this.dataset.addValue(po.percent,statisticMajorScore.getName(), po.name);
		}
	}
}
