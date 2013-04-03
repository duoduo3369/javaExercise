package com.sinaapp.skbanji.db.util;

import java.sql.Connection;

public interface IConnection {
	public Connection getConnection();
	public boolean releaseConnection(Connection connection);
}
