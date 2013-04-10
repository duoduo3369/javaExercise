package com.sinaapp.skbanji.banji.action;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.sinaapp.skbanji.banji.dao.CollegeDao;
import com.sinaapp.skbanji.banji.model.College;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class IsCollegeExisted extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = 3183777135888460794L;

	/**
	 * Constructor of the object.
	 */
	public IsCollegeExisted() {
		super();
	}

	/**
	 * Destruction of the servlet. <br>
	 */
	public void destroy() {
		super.destroy(); // Just puts "destroy" string in log
		// Put your code here
	}

	/**
	 * The doGet method of the servlet. <br>
	 *
	 * This method is called when a form has its tag value method equals to get.
	 * 
	 * @param request the request send by the client to the server
	 * @param response the response send by the server to the client
	 * @throws ServletException if an error occurred
	 * @throws IOException if an error occurred
	 */
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		ServletUtills.SetEncondingUtf8(request, response);
		
		String school_id = request.getParameter("school_id");
		String collegeName = request.getParameter("collegename");
		
		CollegeDao collegeDao = new CollegeDao();
		College college =  collegeDao.getCollege(school_id, collegeName);
		
		PrintWriter out = response.getWriter();
		System.out.println("is existed:"+collegeName + " obj: " + college);
		if (college != null) {
			out.write("true");
		} else {
			out.write("false");
		}
		out.flush();
		out.close();
	}

	/**
	 * Initialization of the servlet. <br>
	 *
	 * @throws ServletException if an error occurs
	 */
	public void init() throws ServletException {
		// Put your code here
	}

}
