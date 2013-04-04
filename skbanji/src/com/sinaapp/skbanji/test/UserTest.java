package com.sinaapp.skbanji.test;
import java.sql.Connection;
import java.sql.SQLException;

import static org.junit.Assert.*;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import com.sinaapp.skbanji.account.dao.UserDaoOld;
import com.sinaapp.skbanji.account.model.User;
import com.sinaapp.skbanji.db.util.DBHelper;

public class UserTest {
	//Connection connection = null;
	User user = null;
	@Before
	public void setUp() throws Exception {
		//connection = DBHelper.getConnection();
	}

	@After
	public void tearDown() throws Exception {
		//DBHelper.releaseConnection(connection);
	}

	@Test
	public void testGetUser() {
		try {
			user = UserDaoOld.getUser("4");
		} catch (SQLException e) {
			
			e.printStackTrace();
		}
		System.out.println(user);
		Assert.assertEquals(user.getId(), 4);
		
	}
	//@Test
	public void testSaveUser() {
		user = new User();
		user.setName("sun hong hua");
		user.setPassword("123");
		user.setEmail("abc@163.com");
		try {
			UserDaoOld.save(user);
			
		} catch (SQLException e) {
			
			e.printStackTrace();
		}
		
	}

}
