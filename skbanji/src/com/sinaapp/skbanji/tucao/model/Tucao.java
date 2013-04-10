package com.sinaapp.skbanji.tucao.model;

import java.io.Serializable;

public class Tucao implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = -2476737178162773910L;
	private int id;
	private String content;
	private String publish_date;
	private int banji_id;
	private int student_id;
	public Tucao() {
		// TODO Auto-generated constructor stub
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
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
