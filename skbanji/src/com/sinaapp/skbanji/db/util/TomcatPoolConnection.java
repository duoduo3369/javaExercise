package com.sinaapp.skbanji.db.util;

import java.sql.Connection;
import java.sql.SQLException;

import javax.naming.InitialContext;
import javax.sql.DataSource;

public class TomcatPoolConnection implements IConnection {

	public TomcatPoolConnection() {
		// TODO Auto-generated constructor stub
	}

	@Override
	public Connection getConnection() {
		InitialContext ic;
		
		Connection connection = null;
		try {
			ic = new InitialContext();
			
			DataSource ds = (DataSource) ic.lookup("java:/comp/env/jdbc/skbanjiDB");
			connection = ds.getConnection();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return connection;
	}

	@Override
	public boolean releaseConnection(Connection connection) {
		boolean flag = false;
		if (connection != null) {
			try {
				connection.close();
				flag = true;
			} catch (SQLException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}

		}
		return flag;
	}

}
