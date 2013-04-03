package com.sinaapp.skbanji.db.util;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class DriverManagerConnection implements IConnection {
	private final String DRIVER = "com.mysql.jdbc.Driver";
	private final String URL = "jdbc:mysql://127.0.0.1:3306/skbanji";
	private final String PASSWORD = "duoduo";
	private final String USER = "root";

	@Override
	public Connection getConnection() {
		Connection connection = null;
		try {
			connection = DriverManager.getConnection(URL, USER, PASSWORD);
		} catch (SQLException e) {

			e.printStackTrace();
		}
		return connection;
	}

	public DriverManagerConnection() {
		try {
			Class.forName(DRIVER);
		} catch (Exception e) {
			e.printStackTrace();
		}
	}

	@Override
	public boolean releaseConnection(Connection connection) {
		boolean flag = false;
		if (connection != null) {
			try {
				connection.close();
				flag = true;
			} catch (SQLException e) {
				e.printStackTrace();
			}
		}
		return flag;
	}

}
