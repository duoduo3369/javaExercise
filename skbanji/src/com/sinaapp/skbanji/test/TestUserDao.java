package com.sinaapp.skbanji.test;

import static org.junit.Assert.*;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.util.Random;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import com.sinaapp.skbanji.account.model.User;
import com.sinaapp.skbanji.db.util.DBManager;
import com.sinaapp.skbanji.db.util.DriverManagerConnection;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class TestUserDao {
	private DBManager dbManager;
	private String sql;
	private List<Object> params;

	@Before
	public void setUp() throws Exception {
		dbManager = new DBManager();
		dbManager.setConnection(new DriverManagerConnection());
		dbManager.getConnection();
	}

	@After
	public void tearDown() throws Exception {
		dbManager.releaseConnection();
	}

	// @Test
	public void testInsert() {
		sql = "INSERT INTO  user (username,password,email) VALUES (?,?,?)";
		params = new ArrayList<Object>();
		
		params.add(ServletUtills.GetRandomString(10));
		params.add("1234567");
		params.add("123w@qq.com");
		boolean flag = false;
		try {
			flag = dbManager.updateByPreparedStatement(sql, params);
		} catch (SQLException e) {
			e.printStackTrace();
		}
		Assert.assertEquals(flag, true);
	}

	@Test
	public void testFindSimpleResult() {
		sql = "select * from user where id = ?";
		params = new ArrayList<Object>();
		params.add("9");
		Map<String, Object> map = new HashMap<String, Object>();
		try {
			map = dbManager.findSimpleResult(sql, params);
			System.out.println("testFindSimpleResult");
			System.out.println(map);
		} catch (SQLException e) {
			e.printStackTrace();
		}
		Assert.assertEquals(map.size() > 0, true);
	}

	@Test
	public void testFindMoreResultSet() {
		sql = "select * from user where id between 0 and 10";

		List<Map<String, Object>> list = new ArrayList<Map<String, Object>>();
		try {
			list = dbManager.findMoreResultSet(sql, null);
			System.out.println("testFindMoreResultSet");
			System.out.println(list);

		} catch (SQLException e) {
			e.printStackTrace();
		}
		Assert.assertEquals(list.size() > 0, true);
	}
	
	@Test
	public void testFindSimpleRefResult(){
		sql = "select * from user where id = ?";
		params = new ArrayList<Object>();
		params.add("9");
		User user = new User();
		try {
			user = dbManager.findSimpleRefResult(sql, params,User.class);
			System.out.println("testFindSimpleRefResult");
			System.out.println(user);
		} catch (Exception e) {			
			e.printStackTrace();
		}
		Assert.assertEquals(user.getId() == 9, true);
	}
	@Test
	public void testFindMoreRefResultSet(){
		sql = "select * from user where id between 0 and 10";
		
		List<User> list = new ArrayList<User>();
		try {
			list = dbManager.findMoreRefResultSet(sql, null, User.class);
			System.out.println("testFindMoreRefResultSet");
			System.out.println(list);
		} catch (Exception e) {			
			e.printStackTrace();
		}
		Assert.assertEquals(list.size() > 0, true);
	}

}
