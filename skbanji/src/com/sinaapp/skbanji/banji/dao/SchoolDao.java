package com.sinaapp.skbanji.banji.dao;

import java.util.ArrayList;
import java.util.List;

import com.sinaapp.skbanji.banji.model.School;
import com.sinaapp.skbanji.db.util.DBManager;

public class SchoolDao {
	private DBManager dbManager = null;

	public SchoolDao() {
		dbManager = new DBManager();
	}

	public School getSchool(int id) {
		School school = null;
		try {
			dbManager.getConnection();
			String sql = "select * from school where id = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(id);

			school = dbManager.findSimpleRefResult(sql, params, School.class);
			
			dbManager.releaseConnection();
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return school;
	}

	public School getSchool(String name) {
		List<School> list = null;
		try {
			dbManager.getConnection();
			String sql = "select * from school where name = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(name);

			list = dbManager.findMoreRefResultSet(sql, params, School.class);
			dbManager.releaseConnection();
			if (list.size() > 0) {
				return list.get(0);
			}
		} catch (Exception e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
		return null;
	}

	public List<School> getSchools(){
		List<School> list = null;
		try {
			dbManager.getConnection();
			String sql = "SELECT * FROM  school";
			list = dbManager.findMoreRefResultSet(sql, null, School.class);
			dbManager.releaseConnection();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return list;
	}
	public School save(School school) {
		try {
			dbManager.getConnection();
			String sql = "INSERT INTO  school (name) VALUES (?)";
			List<Object> params = new ArrayList<Object>();

			params.add(school.getName());

			dbManager.updateByPreparedStatement(sql, params);
			dbManager.releaseConnection();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return school;
	}

	public void setDbManager(DBManager dbManager) {
		this.dbManager = dbManager;
	}
}
