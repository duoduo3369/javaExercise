package com.sinaapp.skbanji.test;

import static org.junit.Assert.*;

import java.util.List;

import org.junit.After;
import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

import com.sinaapp.skbanji.banji.dao.CollegeDao;
import com.sinaapp.skbanji.banji.dao.MajorDao;
import com.sinaapp.skbanji.banji.dao.SchoolDao;
import com.sinaapp.skbanji.banji.model.College;
import com.sinaapp.skbanji.banji.model.Major;
import com.sinaapp.skbanji.banji.model.School;
import com.sinaapp.skbanji.db.util.DBManager;
import com.sinaapp.skbanji.db.util.DriverManagerConnection;
import com.sinaapp.skbanji.servlet.util.ServletUtills;

public class TestMajorDao {
	private DBManager dbManager;
	private CollegeDao collegeDao;
	private SchoolDao schoolDao;
	private MajorDao majorDao;

	@Before
	public void setUp() throws Exception {
		dbManager = new DBManager();
		dbManager.setConnection(new DriverManagerConnection());
		schoolDao = new SchoolDao();
		schoolDao.setDbManager(dbManager);
		collegeDao = new CollegeDao();
		collegeDao.setDbManager(dbManager);
		majorDao = new MajorDao();
		majorDao.setDbManager(dbManager);

	}

	@After
	public void tearDown() throws Exception {
	}

	//@Test
	public void testSave() {
		School school = schoolDao.getSchool("山东科技大学");
		if (school == null) {
			fail("居然木有山东科技大学");
		}
		College college = collegeDao.getCollege(school, "信息学院");
		if (college == null) {
			fail("居然木有山东科技大学  信息学院");
		}
		String major_name = "计算机网络";
		majorDao.save(college.getId(),major_name);
		Major major = majorDao.getMajor(college.getId(), major_name);
		Assert.assertEquals(major.getId() > 0, true);
	}

	@Test
	public void testGetMajor() {
		School school = schoolDao.getSchool("山东科技大学");
		if (school == null) {
			fail("居然木有山东科技大学");
		}

		College college = collegeDao.getCollege(school, "信息学院");
		if (college == null) {
			fail("居然木有山东科技大学  信息学院");
		}

		Major major = majorDao.getMajor(college.getId(), "软件工程");
		System.out.println("testGetMajor():" + major);
		Assert.assertEquals(major.getId() > 0, true);
	}

	@Test
	public void testGetMajors() {
		School school = schoolDao.getSchool("山东科技大学");
		if (school == null) {
			fail("居然木有山东科技大学");
		}

		College college = collegeDao.getCollege(school, "信息学院");
		if (college == null) {
			fail("居然木有山东科技大学  信息学院");
		}

		List<Major> list = majorDao.getMajors(college.getId());
		System.out.println("testGetMajors():" + ServletUtills.ListObjToJson(list));
		Assert.assertEquals(list.size() > 0, true);
	}

}
