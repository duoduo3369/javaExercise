package com.sinaapp.skbanji.servlet.util;

import java.io.UnsupportedEncodingException;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class ServletUtills {
	public static void SetEncondingUtf8(HttpServletRequest request,
			HttpServletResponse response) throws UnsupportedEncodingException {
		request.setCharacterEncoding("utf-8");
		response.setCharacterEncoding("utf-8");
	}
}
