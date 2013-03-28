package com.example.helloandroid;

import android.app.Activity;
import android.os.Bundle;
import android.widget.TextView;

public class ApplicationDataActivity extends Activity {
	private TextView textView;
	private ApplicationData applicationData;
	public ApplicationDataActivity() {
		// TODO Auto-generated constructor stub
	}
	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.other);
		textView = (TextView)this.findViewById(R.id.msg);
		applicationData = (ApplicationData)getApplication();
		textView.setText("应用程序数据--》"+applicationData.getName());
	}

}
