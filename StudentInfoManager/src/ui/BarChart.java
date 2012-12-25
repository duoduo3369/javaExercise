package ui;

import org.jfree.data.category.DefaultCategoryDataset;

import sys.PercentObject;
import sys.StatisticMajorScore;

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
