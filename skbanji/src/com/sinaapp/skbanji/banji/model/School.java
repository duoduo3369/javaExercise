package com.sinaapp.skbanji.banji.model;

import java.io.Serializable;

public class School implements Serializable {

	/**
	 * 
	 */
	private static final long serialVersionUID = -5879161889335579778L;
	private int id;
	private String name;

	public School() {
		super();
	}

	public School(String name) {
		super();
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

	@Override
	public String toString() {
		return "{\"id\":\""+id+"\",\"name\":\""+name+"\"}";
	}
}
