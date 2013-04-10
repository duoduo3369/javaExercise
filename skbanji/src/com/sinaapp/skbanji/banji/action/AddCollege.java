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

public class AddCollege extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = -804417199221600830L;

	/**
	 * Constructor of the object.
	 */
	public AddCollege() {
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
	 * The doPost method of the servlet. <br>
	 *
	 * This method is called when a form has its tag value method equals to post.
	 * 
	 * @param request the request send by the client to the server
	 * @param response the response send by the server to the client
	 * @throws ServletException if an error occurred
	 * @throws IOException if an error occurred
	 */
	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		ServletUtills.SetEncondingUtf8(request, response);
		String success = request.getParameter("success");
		String school_id = request.getParameter("school_id");
		String collegename = request.getParameter("collegename");
		System.out.println("try to add college " + success + " " + collegename);
		if (success == null || success.equals("")) {
			return;
		}
		CollegeDao collegeDao = new CollegeDao();
		collegeDao.save(new College(Integer.parseInt(school_id), collegename));
		College college = collegeDao.getCollege(school_id, collegename);
		if(college!=null){
			System.out.println("add college " + college.getName() + " sucess!");
		}
		
		PrintWriter out = response.getWriter();
		out.write(ServletUtills.colseWindowScript);
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
