package com.sinaapp.skbanji.banji.dao;

import java.util.ArrayList;
import java.util.List;

import com.sinaapp.skbanji.banji.model.College;
import com.sinaapp.skbanji.banji.model.School;
import com.sinaapp.skbanji.db.util.DBManager;

public class CollegeDao {
	private DBManager dbManager = null;
	public CollegeDao() {
		dbManager = new DBManager();
	}
	public void setDbManager(DBManager dbManager) {
		this.dbManager = dbManager;
	}
	public College getCollege(String school_id,String name){
		List<College> list = null;
		try {
			dbManager.getConnection();
			String sql = "select * from college where school_id = ? and name = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(school_id);
			params.add(name);

			list = dbManager.findMoreRefResultSet(sql, params, College.class);
			
			dbManager.releaseConnection();
			if(list.size() > 0){
				return list.get(0);
			}
		} catch (Exception e) {
			
			e.printStackTrace();
		}
		return null;
	}
	public College getCollege(int school_id,String collge_name){
		return this.getCollege(Integer.toString(school_id),collge_name);
	}
	public College getCollege(School school,String name){
		return getCollege(school.getId(), name);
	}
	public List<College> getColleges(School school){
		return getColleges(school.getId());
	}
	public List<College> getColleges(int school_id) {
		return getColleges(Integer.toString(school_id));
	}
	public List<College> getColleges(String school_id){
		List<College> list = null;
		try {
			dbManager.getConnection();
			String sql = "SELECT * FROM  college WHERE school_id = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(school_id);
			list = dbManager.findMoreRefResultSet(sql, params, College.class);
			dbManager.releaseConnection();
		} catch (Exception e) {
			// TODO: handle exception
		}
		return list;
	}
	public College save(College college){
		try {
			dbManager.getConnection();
			String sql = "INSERT INTO  college (name,school_id) VALUES (?,?)";
			List<Object> params = new ArrayList<Object>();

			params.add(college.getName());
			params.add(college.getSchool_id());

			dbManager.updateByPreparedStatement(sql, params);
			dbManager.releaseConnection();
		} catch (Exception e) {
			e.printStackTrace();
		}
		return college;
	}
	public College save(School school,String college_name){
		College college = new College(school,college_name);
		this.save(college);
		return college;
	}
	public College save(int school_id,String name){
		College college = new College(school_id,name);
		this.save(college);
		return college;		
	}
	
}
