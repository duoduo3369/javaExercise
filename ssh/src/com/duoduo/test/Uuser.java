package com.duoduo.test;

/**
 * Uuser entity. @author MyEclipse Persistence Tools
 */

public class Uuser implements java.io.Serializable {

	// Fields

	/**
	 * 
	 */
	private static final long serialVersionUID = 2092667568083139904L;
	private Integer id;
	private String name;
	private String password;
	private String userEmail;

	// Constructors

	/** default constructor */
	public Uuser() {
	}

	/** minimal constructor */
	public Uuser(String name, String password) {
		this.name = name;
		this.password = password;
	}

	/** full constructor */
	public Uuser(String name, String password, String userEmail) {
		this.name = name;
		this.password = password;
		this.userEmail = userEmail;
	}

	// Property accessors

	public Integer getId() {
		return this.id;
	}

	public void setId(Integer id) {
		this.id = id;
	}

	public String getName() {
		return this.name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPassword() {
		return this.password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public String getUserEmail() {
		return this.userEmail;
	}

	public void setUserEmail(String userEmail) {
		this.userEmail = userEmail;
	}

	@Override
	public String toString() {
		return "Uuser [id=" + id + ", name=" + name + ", password=" + password
				+ ", userEmail=" + userEmail + "]";
	}

}