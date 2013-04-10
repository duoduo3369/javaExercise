package com.sinaapp.skbanji.banji.model;

import java.io.Serializable;

public class Banji implements Serializable {
	/**
	 * 
	 */
	private static final long serialVersionUID = -1123402423571478287L;
	private int id;
	private String name;
	private int major_id;
	public Banji() {
		// TODO Auto-generated constructor stub
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	public int getMajor_id() {
		return major_id;
	}
	public void setMajor_id(int major_id) {
		this.major_id = major_id;
	}

}
