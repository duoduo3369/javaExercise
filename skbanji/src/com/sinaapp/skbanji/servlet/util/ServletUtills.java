package com.sinaapp.skbanji.servlet.util;

import java.io.UnsupportedEncodingException;
import java.util.List;
import java.util.Random;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class ServletUtills {
	public static void SetEncondingUtf8(HttpServletRequest request,
			HttpServletResponse response) throws UnsupportedEncodingException {
		request.setCharacterEncoding("UTF-8");
		response.setCharacterEncoding("UTF-8");
	}
	public static String ListObjToJson(List list){
		StringBuffer out = new StringBuffer("[");
		for(Object obj:list){
			out.append(obj).append(",");
			
		}
		return out.substring(0,out.length()-1)+"]"; 
	}
	public static String GetRandomString(int length) {
		String s = " qwertyuiopasdfghjklzxcvbnm";
		Random random = new Random();
		int len = random.nextInt(length);
		StringBuffer out = new StringBuffer();
		for (int i = 0; i < len; i++) {
			out.append(s.charAt(random.nextInt(25)));
		}
		return out.toString();
	}
	public static final String updateSelectScriptFormat = "<script type=\"text/javascript\">window.opener.updateSelect(\"%s\",\"%s\",\"%s\");</script>";
	public  static final String colseWindowScript = "<script type=\"text/javascript\">window.opener.dismissChildWindow(window);</script>";
}
