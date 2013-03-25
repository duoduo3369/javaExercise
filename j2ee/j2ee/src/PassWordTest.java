import java.io.BufferedReader;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.PrintWriter;
import java.io.Reader;

import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.xml.parsers.*;

import org.w3c.dom.*;
import org.xml.sax.SAXException;

public class PassWordTest extends HttpServlet {

	/**
	 * Constructor of the object.
	 */
	public PassWordTest() {
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
		/*
		response.setContentType("text/html");
		PrintWriter out = response.getWriter();
		out.println("<!DOCTYPE HTML PUBLIC \"-//W3C//DTD HTML 4.01 Transitional//EN\">");
		out.println("<HTML>");
		out.println("  <HEAD><TITLE>A Servlet</TITLE></HEAD>");
		out.println("  <BODY>");
		out.print("    This is ");
		out.print(this.getClass());
		out.println(", using the GET method");
		out.println("  </BODY>");
		out.println("</HTML>");
		out.flush();
		out.close();
		//*/
		doPost(request,response);
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
		// BufferedReader reader = new BufferedReader(reader);
		// response.setContentType("text/html");
		request.setCharacterEncoding("utf-8");
		response.setCharacterEncoding("utf-8");
		// response.setHeader("ContentType", "text/xml");
		// response.setContentType("text/xml");

		String username = request.getParameter("username");
		String password = request.getParameter("password");

		PrintWriter out = response.getWriter();
		String rootpath = this.getServletContext().getRealPath("/");
		String path = rootpath + "data/password.xml";
		Document doc = null;
		try {
			doc = getDocumentRoot(path);
		} catch (ParserConfigurationException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (SAXException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		NodeList nodeList = doc.getElementsByTagName("infomation");
		int length = nodeList.getLength();
		boolean isVaild = false;

		for (int i = 0; i < length; i++) {

			String un = ((Element) (nodeList.item(i).getFirstChild()))
					.getTextContent();

			String pw = ((Element) (nodeList.item(i).getLastChild()))
					.getTextContent();

			if (username.equals(un) && password.equals(pw)) {
				isVaild = true;
				break;
			}

		}

		if (isVaild) {
			out.write("OK");
		} else {
			out.write("NOT OK");
		}
		out.flush();

		out.close();
	}

	private String readXmlFile(String path) throws FileNotFoundException,
			IOException {
		File xmlFile = new File(path);
		BufferedReader inFile = new BufferedReader(new InputStreamReader(
				new FileInputStream(xmlFile), "utf-8"));
		StringBuffer sb = new StringBuffer();
		String temp;
		while ((temp = inFile.readLine()) != null) {
			sb.append(temp);
		}

		inFile.close();
		return sb.toString();
	}

	public Document getDocumentRoot(String path)
			throws ParserConfigurationException, SAXException, IOException {
		File file = new File(path);
		DocumentBuilderFactory factory = DocumentBuilderFactory.newInstance();
		DocumentBuilder builder = factory.newDocumentBuilder();
		Document doc = builder.parse(file);
		return doc;
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
