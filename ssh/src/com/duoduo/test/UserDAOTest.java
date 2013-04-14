package com.duoduo.test;

import org.junit.Test;

import junit.framework.TestCase;

public class UserDAOTest extends TestCase {

	@Test
	public void testUserDAO(){
		Uuser userUuser = new Uuser("123","adsfl","aklsd");
		userUuser.setId(1);
		UuserDAO uuserDAO = new UuserDAO();
		uuserDAO.save(userUuser);
		
	}
}
