package com.duoduo.test;

import static org.junit.Assert.fail;

import java.sql.Connection;
import java.sql.DriverManager;

import org.junit.Test;

public class SqlServerTest {
	String driverName = "com.microsoft.sqlserver.jdbc.SQLServerDriver"; // 加载JDBC驱动
	String dbURL = "jdbc:sqlserver://localhost:1433; DatabaseName=MyQQ"; // 连接服务器和数据库sample
	String userName = "sa"; // 默认用户名
	String userPwd = "sa"; // 密码
	Connection dbConn;

	@Test
	public void testConnection() {
		try {
			Class.forName(driverName);
			dbConn = DriverManager.getConnection(dbURL, userName, userPwd);
			System.out.println("Connection Successful!"); // 如果连接成功
															// 控制台输出Connection
															// Successful!
			dbConn.close();
		} catch (Exception e) {
			e.printStackTrace();
			fail("有异常，测试失败");
		}
	}

}
