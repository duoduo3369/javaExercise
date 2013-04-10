package com.sinaapp.skbanji.test;

import static org.junit.Assert.*;

import java.util.List;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import com.sinaapp.skbanji.banji.dao.CollegeDao;
import com.sinaapp.skbanji.banji.dao.SchoolDao;
import com.sinaapp.skbanji.banji.model.College;
import com.sinaapp.skbanji.banji.model.School;
import com.sinaapp.skbanji.db.util.DBManager;
import com.sinaapp.skbanji.db.util.DriverManagerConnection;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class TestCollegeDao {
	private DBManager dbManager;
	private CollegeDao collegeDao;
	private SchoolDao schoolDao;

	@Before
	public void setUp() throws Exception {
		dbManager = new DBManager();
		dbManager.setConnection(new DriverManagerConnection());
		schoolDao = new SchoolDao();
		schoolDao.setDbManager(dbManager);
		collegeDao = new CollegeDao();
		collegeDao.setDbManager(dbManager);
	}

	@After
	public void tearDown() throws Exception {

	}

	//@Test
	public void testSave() {
		School school = schoolDao.getSchool(3);
		String name = ServletUtills.GetRandomString(10);
		//College college = new College(school, name);
		 College college = new College(school, "信息学院");
		collegeDao.save(college);
		College savedCollege = collegeDao.getCollege(school, college.getName());
		Assert.assertEquals(savedCollege.getId() > 0, true);
		System.out.println("testSave:" + savedCollege);
	}

	@Test
	public void testGetCollege() {
		School school = schoolDao.getSchool("山东科技大学");
		College college = collegeDao.getCollege("3", "信息学院");
		//Assert.assertEquals(college.getSchool_id(), school.getId());
		Assert.assertEquals(college.getSchool_id(), 3);
		System.out.println("testGetCollege:" + college);
	}

	@Test
	public void testGetColleges() {
		School school = schoolDao.getSchool("山东科技大学");
		List<College> list = collegeDao.getColleges(2);
		Assert.assertEquals(list.size() > 0, true);

		System.out.println("testGetColleges:" + list);
		List<College> noneList = collegeDao.getColleges(-1);
		Assert.assertEquals(noneList.size() > 0, false);
	}

}
