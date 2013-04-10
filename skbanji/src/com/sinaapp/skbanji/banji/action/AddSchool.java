package com.sinaapp.skbanji.banji.action;

import java.io.IOException;
import java.io.PrintWriter;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import com.sinaapp.skbanji.banji.dao.SchoolDao;
import com.sinaapp.skbanji.banji.model.School;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class AddSchool extends HttpServlet {

	/**
	 * 
	 */
	private static final long serialVersionUID = -226995548593930198L;

	/**
	 * Constructor of the object.
	 */
	public AddSchool() {
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
	 * This method is called when a form has its tag value method equals to
	 * post.
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
	public void doPost(HttpServletRequest request, HttpServletResponse response)
			throws ServletException, IOException {
		ServletUtills.SetEncondingUtf8(request, response);
		String success = request.getParameter("success");
		String schoolName = request.getParameter("schoolname");
		System.out.println("try to add school " + success + " " + schoolName);
		if (success == null || success.equals("")) {
			return;
		}
		SchoolDao schoolDao = new SchoolDao();
		schoolDao.save(new School(schoolName));
		School school = schoolDao.getSchool(schoolName);
		if(school!=null){
			System.out.println("add college " + school.getName() + " sucess!");
		}
		String updateScriptString = String.format(
				ServletUtills.updateSelectScriptFormat,"#schoolSelect", school.getId(),
				school.getName());
		PrintWriter out = response.getWriter();
		out.write(updateScriptString);
		out.write(ServletUtills.colseWindowScript);
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
