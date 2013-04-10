package com.sinaapp.skbanji.article.model;

import java.io.Serializable;

public class Article implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = 8587685816614862269L;
	private int id;
	private String title;
	private String content;
	private String publish_date;
	private int banji_id;
	private int student_id;
	public Article() {
		// TODO Auto-generated constructor stub
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getTitle() {
		return title;
	}
	public void setTitle(String title) {
		this.title = title;
	}
	public String getContent() {
		return content;
	}
	public void setContent(String content) {
		this.content = content;
	}
	public String getPublish_date() {
		return publish_date;
	}
	public void setPublish_date(String publish_date) {
		this.publish_date = publish_date;
	}
	public int getBanji_id() {
		return banji_id;
	}
	public void setBanji_id(int banji_id) {
		this.banji_id = banji_id;
	}
	public int getStudent_id() {
		return student_id;
	}
	public void setStudent_id(int student_id) {
		this.student_id = student_id;
	}

}
