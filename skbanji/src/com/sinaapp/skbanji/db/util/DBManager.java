package com.sinaapp.skbanji.db.util;

import java.lang.reflect.Field;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
import java.sql.ResultSetMetaData;

import javax.naming.InitialContext;
import javax.naming.NamingException;
import javax.sql.DataSource;

public class DBManager {
	private IConnection iConnection;
	private Connection connection;
	private PreparedStatement pstmt;
	private ResultSet resultSet;

	public DBManager() {
		iConnection = new TomcatPoolConnection();
		//iConnection = new DriverManagerConnection();
	}

	public Connection getConnection() throws NamingException {
		try {
			connection = iConnection.getConnection();
		} catch (Exception e) {

			e.printStackTrace();
		}
		return connection;
	}

	public void releasePreparedStatement() throws SQLException {
		if (pstmt != null) {
			pstmt.close();
		}
	}

	public void releaseResultSet() throws SQLException {
		if (resultSet != null) {
			resultSet.close();
		}
	}

	public boolean releaseConnection(Connection connection) throws SQLException {
		return iConnection.releaseConnection(connection);
	}

	public void releaseConnection() throws SQLException {
		releaseResultSet();
		releasePreparedStatement();
		releaseConnection(connection);
	}

	private void setParamsToPreparedStatement(PreparedStatement pstmt,
			List<Object> params) throws SQLException {
		int index = 1;
		if (params != null && !params.isEmpty()) {
			for (int i = 0; i < params.size(); i++) {
				pstmt.setObject(index++, params.get(i));
			}
		}
	}

	public boolean updateByPreparedStatement(String sql, List<Object> params)
			throws SQLException {
		boolean flag = false;
		// result:当用户执行添加删除修改时所影响数据库的行数
		int result = -1;

		pstmt = connection.prepareStatement(sql);
		setParamsToPreparedStatement(pstmt, params);
		result = pstmt.executeUpdate();
		flag = result > 0 ? true : false;
		return flag;
	}

	public Map<String, Object> findSimpleResult(String sql, List<Object> params)
			throws SQLException {
		Map<String, Object> map = new HashMap<String, Object>();
		// index:占位符地址
		pstmt = connection.prepareStatement(sql);
		setParamsToPreparedStatement(pstmt, params);
		resultSet = pstmt.executeQuery();

		ResultSetMetaData metaData = resultSet.getMetaData();
		int col_len = metaData.getColumnCount();
		while (resultSet.next()) {
			for (int i = 0; i < col_len; i++) {
				String cols_name = metaData.getColumnName(i + 1);
				Object cols_value = resultSet.getObject(cols_name);
				if (cols_value == null) {
					cols_value = "";
				}
				map.put(cols_name, cols_value);
			}
		}

		return map;

	}

	public List<Map<String, Object>> findMoreResultSet(String sql,
			List<Object> params) throws SQLException {
		List<Map<String, Object>> list = new ArrayList<Map<String, Object>>();

		pstmt = connection.prepareStatement(sql);
		setParamsToPreparedStatement(pstmt, params);
		resultSet = pstmt.executeQuery();
		ResultSetMetaData metaData = resultSet.getMetaData();
		int col_len = metaData.getColumnCount();

		while (resultSet.next()) {
			Map<String, Object> map = new HashMap<String, Object>();
			for (int i = 0; i < col_len; i++) {
				String cols_name = metaData.getColumnName(i + 1);
				Object cols_value = resultSet.getObject(cols_name);
				if (cols_value == null) {
					cols_value = "";
				}
				map.put(cols_name, cols_value);
			}
			list.add(map);
		}
		return list;

	}

	private <T> void ReflectSetFieldVale(Object target, String column,
			Object value, Class<T> cls) throws Exception {
		Field field = cls.getDeclaredField(column);
		field.setAccessible(true);
		field.set(target, value);
	}

	// 反射的方式封装
	public <T> T findSimpleRefResult(String sql, List<Object> params,
			Class<T> cls) throws Exception {
		T resultObject = null;

		pstmt = connection.prepareStatement(sql);
		setParamsToPreparedStatement(pstmt, params);
		resultSet = pstmt.executeQuery();
		ResultSetMetaData metaData = resultSet.getMetaData();
		int col_len = metaData.getColumnCount();

		while (resultSet.next()) {
			resultObject = cls.newInstance();
			for (int i = 0; i < col_len; i++) {
				String cols_name = metaData.getColumnName(i + 1);
				Object cols_value = resultSet.getObject(cols_name);
				if (cols_value == null) {
					cols_value = "";
				}
				// Field field = cls.getDeclaredField(cols_name);
				// field.setAccessible(true);
				// field.set(resultObject, cols_value);
				ReflectSetFieldVale(resultObject, cols_name, cols_value, cls);
			}
		}
		return resultObject;
	}

	public <T> List<T> findMoreRefResultSet(String sql, List<Object> params,
			Class<T> cls) throws Exception {
		List<T> list = new ArrayList<T>();

		pstmt = connection.prepareStatement(sql);
		setParamsToPreparedStatement(pstmt, params);
		resultSet = pstmt.executeQuery();
		ResultSetMetaData metaData = resultSet.getMetaData();
		int col_len = metaData.getColumnCount();

		while (resultSet.next()) {
			T resultObject = cls.newInstance();
			for (int i = 0; i < col_len; i++) {
				String cols_name = metaData.getColumnName(i + 1);
				Object cols_value = resultSet.getObject(cols_name);
				if (cols_value == null) {
					cols_value = "";
				}
				ReflectSetFieldVale(resultObject, cols_name, cols_value, cls);
			}
			list.add(resultObject);
		}
		return list;

	}

}
