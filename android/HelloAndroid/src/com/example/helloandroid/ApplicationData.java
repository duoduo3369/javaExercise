package com.example.helloandroid;

import android.app.Application;

public class ApplicationData extends Application {

	private String name;
	public ApplicationData() {
		// TODO Auto-generated constructor stub
	}
	public String getName() {
		return name;
	}
	public void setName(String name) {
		this.name = name;
	}
	@Override
	public void onCreate() {
		super.onCreate();
		setName("duoduo 应用程序数据");
	}

}
