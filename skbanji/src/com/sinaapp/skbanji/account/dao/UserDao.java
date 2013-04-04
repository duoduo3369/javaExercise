package com.sinaapp.skbanji.account.dao;

import java.sql.Connection;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;

import javax.naming.NamingException;

import com.sinaapp.skbanji.account.model.User;
import com.sinaapp.skbanji.db.util.DBManager;

public class UserDao {
	private DBManager dbManager = null;

	public UserDao() {
		dbManager = new DBManager();
	}

	public User getUser(int id) {
		User user = null;
		try {
			dbManager.getConnection();
			String sql = "select * from user where id = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(id);

			user = dbManager.findSimpleRefResult(sql, params, User.class);

			dbManager.releaseConnection();
		} catch (Exception e) {
			// TODO: handle exception
		}
		return user;
	}

	public User getUser(String username) {
		List<User> list = null;
		try {
			dbManager.getConnection();
			String sql = "select * from user where username = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(username);

			list = dbManager.findMoreRefResultSet(sql, params, User.class);
			dbManager.releaseConnection();
			if (list.size() > 0) {
				return list.get(0);
			}
		} catch (Exception e) {
			// TODO: handle exception
		}
		// 没有用户返回null
		return null;
	}

	public User save(User user) {
		try {
			dbManager.getConnection();
			String sql = "INSERT INTO  user (username,password,email) VALUES (?,?,?)";
			List<Object> params = new ArrayList<Object>();
			params.add(user.getName());
			params.add(user.getPassword());
			params.add(user.getEmail());

			dbManager.updateByPreparedStatement(sql, params);
			dbManager.releaseConnection();
		} catch (Exception e) {
			e.printStackTrace();
		}

		return user;
	}

}
