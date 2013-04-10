package com.sinaapp.skbanji.account.action;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;

import org.hibernate.validator.constraints.impl.NullValidator;

import com.sinaapp.skbanji.account.dao.UserDao;
import com.sinaapp.skbanji.account.model.User;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class Login extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = 2910772852501331124L;

	/**
	 * Constructor of the object.
	 */
	public Login() {
		super();
	}

	/**
	 * Destruction of the servlet. <br>
	 */
	public void destroy() {
		super.destroy(); // Just puts "destroy" string in log
		// Put your code here
	}

	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		ServletUtills.SetEncondingUtf8(request, response);
		String username = request.getParameter("username");
		String password = request.getParameter("password");
		UserDao userDao = new UserDao();
		User user = userDao.getUser(username);
		
		if (user != null && user.getPassword().equals(password)) {
			HttpSession session = request.getSession();
			session.setAttribute("username", username);
			response.sendRedirect(request.getContextPath()
					+ "/banji/choice_banji.jsp");

		} else {
			request.getRequestDispatcher("/account/login_error.jsp").forward(request, response);
			
		}
		
	}

	/**
	 * Initialization of the servlet. <br>
	 * 
	 * @throws ServletException
	 *             if an error occurs
	 */
	public void init() throws ServletException {
		// Put your code here
	}

}
