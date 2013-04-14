package com.duoduo.action;

import org.apache.struts2.ServletActionContext;
import org.springframework.context.ApplicationContext;
import org.springframework.web.context.support.WebApplicationContextUtils;

import com.duoduo.test.Uuser;
import com.duoduo.test.UuserDAO;
import com.opensymphony.xwork2.ActionSupport;

public class RegisterAction extends ActionSupport {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7795609743062649571L;

	private Uuser user;
	private UuserDAO userDAO;

	public Uuser getUser() {
		return user;
	}

	public void setUser(Uuser user) {
		this.user = user;
	}

	public UuserDAO getUserDAO() {
		return userDAO;
	}

	public void setUserDAO(UuserDAO userDAO) {
		this.userDAO = userDAO;
	}

	public String execute() {
		System.out.println("execute");
		if (user != null) {
			System.out.println("user:" + user);
			userDAO.save(user);
			return SUCCESS;
		} else {
			System.out.println("no user");
			return ERROR;
		}
	}
}
