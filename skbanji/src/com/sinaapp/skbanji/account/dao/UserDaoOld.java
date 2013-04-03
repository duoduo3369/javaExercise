package com.sinaapp.skbanji.account.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import javax.sql.DataSource;
import org.omg.CORBA.PRIVATE_MEMBER;

import com.sinaapp.skbanji.account.User;
import com.sinaapp.skbanji.db.util.DBHelper;

public class UserDaoOld {

	static Connection connection = null;
	static PreparedStatement preparedStatement = null;
	static ResultSet resultSet = null;

	private static void init() {

		connection = null;
		preparedStatement = null;
		resultSet = null;
	}

	public static User getUser(String id) throws SQLException {
		init();
		User user = null;
		String sql = "select * from user where id=?";

		connection = DBHelper.getConnection();
		preparedStatement = connection.prepareStatement(sql);
		preparedStatement.setString(1, id);

		resultSet = preparedStatement.executeQuery();
		if (resultSet.next()) {
			user = new User();
			user.setId(resultSet.getInt("id"));
			user.setName(resultSet.getString("username"));
			user.setPassword(resultSet.getString("password"));
			user.setEmail(resultSet.getString("email"));
		}

		resultSet.close();
		preparedStatement.close();
		DBHelper.releaseConnection(connection);

		return user;
	}

	public static void save(User user) throws SQLException {
		init();
		String sql = "INSERT INTO  user (username,password,email) VALUES (?,?,?)";
		connection = DBHelper.getConnection();
		preparedStatement = connection.prepareStatement(sql);
		preparedStatement.setString(1, user.getName());
		preparedStatement.setString(2, user.getPassword());
		preparedStatement.setString(3, user.getEmail());
		
		preparedStatement.executeUpdate();
		
		preparedStatement.close();
		DBHelper.releaseConnection(connection);
		
	} 
}
