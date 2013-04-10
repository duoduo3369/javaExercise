package com.sinaapp.skbanji.test;

import static org.junit.Assert.*;

import java.sql.SQLException;
import java.util.ArrayList;
import java.util.List;
import java.util.Random;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import com.sinaapp.skbanji.banji.dao.SchoolDao;
import com.sinaapp.skbanji.banji.model.School;
import com.sinaapp.skbanji.db.util.DBManager;
import com.sinaapp.skbanji.db.util.DriverManagerConnection;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class TestSchoolDao {
	private DBManager dbManager;
	private SchoolDao schoolDao;

	@Before
	public void setUp() throws Exception {
		dbManager = new DBManager();
		dbManager.setConnection(new DriverManagerConnection());
		dbManager.getConnection();
		schoolDao = new SchoolDao();
		schoolDao.setDbManager(dbManager);
	}

	@After
	public void tearDown() throws Exception {
		dbManager.releaseConnection();
	}

	@Test
	public void testSave() {
		String schoolName = ServletUtills.GetRandomString(10);
		School school = new School(schoolName);
		schoolDao.save(school);
		Assert.assertEquals(schoolDao.getSchool(schoolName).getId() > 0, true);
	}

	@Test
	public void testGetSchoolById() {
		School school = schoolDao.getSchool(1);
		Assert.assertEquals(school.getId() == 1, true);
	}

	@Test
	public void testGetSchoolByName() {
		String name = "山东科技大学";
		School school = schoolDao.getSchool(name);
		Assert.assertEquals(school.getName(), name);
	}
	@Test
	public void testGetSchools() {
		List<School> list = schoolDao.getSchools();
		Assert.assertEquals(list.size()>0, true);
		System.out.println(ServletUtills.ListObjToJson(list));
	}
}
