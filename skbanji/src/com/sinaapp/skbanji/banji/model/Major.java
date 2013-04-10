package com.sinaapp.skbanji.banji.model;

import java.io.Serializable;

public class Major implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -7430386722548037402L;
	private int id;
	private String name;
	private int college_id;

	public Major() {

	}

	public Major(String name, int college_id) {
		super();
		this.name = name;
		this.college_id = college_id;
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

	public int getCollege_id() {
		return college_id;
	}

	public void setCollege_id(int college_id) {
		this.college_id = college_id;
	}

	@Override
	public String toString() {
		return "{\"id\":\"" + id + "\",\"name\":\"" + name
				+ "\",\"college_id\":\"" + college_id + "\"}";

	}

}
