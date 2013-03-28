package com.example.helloandroid;

import android.R.string;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.text.ClipboardManager;
import android.widget.TextView;

public class OtherActivity extends Activity {

	private TextView textView;

	public OtherActivity() {
	}

	@Override
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.other);
		textView = (TextView) this.findViewById(R.id.msg);
		Intent intent = getIntent();
		int age = intent.getIntExtra("age", 0);
		String name = intent.getStringExtra("name");
		textView.setText("ÄêÁä-->" + age + "\n" + "ÐÕÃû-->" + name + "\n");

	}

}
