package com.sinaapp.skbanji.banji.action;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.sinaapp.skbanji.banji.dao.CollegeDao;
import com.sinaapp.skbanji.banji.dao.MajorDao;
import com.sinaapp.skbanji.banji.model.College;
import com.sinaapp.skbanji.banji.model.Major;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class IsMajorExisted extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = 7650787635799799271L;

	/**
	 * Constructor of the object.
	 */
	public IsMajorExisted() {
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
	 * @param request
	 *            the request send by the client to the server
	 * @param response
	 *            the response send by the server to the client
	 * @throws ServletException
	 *             if an error occurred
	 * @throws IOException
	 *             if an error occurred
	 */
	public void doGet(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {

		ServletUtills.SetEncondingUtf8(request, response);

		String college_id = request.getParameter("college_id");
		String major_name = request.getParameter("majorname");

		MajorDao majorDao = new MajorDao();
		Major major = majorDao.getMajor(college_id, major_name);
		

		PrintWriter out = response.getWriter();
		System.out.println("major:is existed:" + major_name + " obj: " + major);
		if (major != null) {
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
	 * @throws ServletException
	 *             if an error occurs
	 */
	public void init() throws ServletException {
		// Put your code here
	}

}
