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

public class AddMajor extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = -870664614291166166L;

	/**
	 * Constructor of the object.
	 */
	public AddMajor() {
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
		String college_id = request.getParameter("college_id");
		String major_name = request.getParameter("majorname");

		System.out.println("try to add college " + success + " " + major_name);
		if (success == null || success.equals("")) {
			return;
		}
		MajorDao majorDao = new MajorDao();
		majorDao.save(college_id,major_name);
		Major major = majorDao.getMajor(college_id, major_name);
		if(major!=null){
			System.out.println("add major " + major.getName() + " sucess!");
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
