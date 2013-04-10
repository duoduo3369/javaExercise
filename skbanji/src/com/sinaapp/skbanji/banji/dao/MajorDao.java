package com.sinaapp.skbanji.banji.dao;

import java.util.ArrayList;
import java.util.List;

import com.sinaapp.skbanji.banji.model.Major;
import com.sinaapp.skbanji.db.util.DBManager;

public class MajorDao {
	private DBManager dbManager = null;

	public MajorDao() {
		dbManager = new DBManager();
	}

	public void setDbManager(DBManager dbManager) {
		this.dbManager = dbManager;
	}
	public Major getMajor(int college_id,String major_name){
		return getMajor(Integer.toString(college_id), major_name);
	}
	
	public Major getMajor(String college_id, String major_name) {
		List<Major> list = null;

		try {
			dbManager.getConnection();
			String sql = "select * from major where college_id = ? and name = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(college_id);
			params.add(major_name);

			list = dbManager.findMoreRefResultSet(sql, params, Major.class);

			dbManager.releaseConnection();
			if (list.size() > 0) {
				return list.get(0);
			}
		} catch (Exception e) {

			e.printStackTrace();
		}
		return null;
	}
	public List<Major> getMajors(int college_id){
		return getMajors(Integer.toString(college_id));
	}
	public List<Major> getMajors(String college_id) {
		List<Major> list = null;
		try {
			dbManager.getConnection();
			String sql = "SELECT * FROM  major WHERE college_id = ?";
			List<Object> params = new ArrayList<Object>();
			params.add(college_id);
			list = dbManager.findMoreRefResultSet(sql, params, Major.class);
			dbManager.releaseConnection();
		} catch (Exception e) {
			// TODO: handle exception
		}
		return list;
	}
	public void save(Major major){
		save(major.getCollege_id(),major.getName());
	}
	public void save(int college_id,String major_name){
		save(Integer.toString(college_id),major_name);
	}
	public void save(String college_id,String major_name){
		try {
			dbManager.getConnection();
			String sql = "INSERT INTO  major (name,college_id) VALUES (?,?)";
			List<Object> params = new ArrayList<Object>();

			params.add(major_name);
			params.add(college_id);

			dbManager.updateByPreparedStatement(sql, params);
			dbManager.releaseConnection();
		} catch (Exception e) {
			e.printStackTrace();
		}
	}
}
