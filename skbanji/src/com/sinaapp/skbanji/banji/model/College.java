package com.sinaapp.skbanji.banji.model;

import java.io.Serializable;

public class College implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7108069535001873765L;
	private int id;
	private String name;
	private int school_id;

	public College() {

	}

	public College(School school,String name) {
		school_id = school.getId();
		this.name = name;
	}
	public College(int school_id,String name) {
		this.school_id = school_id;
		this.name = name;
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

	public int getSchool_id() {
		return school_id;
	}

	public void setSchool_id(int school_id) {
		this.school_id = school_id;
	}

	@Override
	public String toString() {
		return "{\"id\":\""+id+"\",\"name\":\""+name+"\",\"school_id\":\""+school_id+"\"}";
	}

}
