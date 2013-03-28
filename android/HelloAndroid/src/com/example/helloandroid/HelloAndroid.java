package com.example.helloandroid;

import java.io.ByteArrayOutputStream;
import java.io.IOException;
import java.io.ObjectOutputStream;

import android.os.Bundle;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.text.ClipboardManager;
import android.util.Base64;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.Button;

public class HelloAndroid extends Activity {
	public final static String TAG = "HelloAndroid";
	private Button button;
	private Button buttonClip;
	private Button buttonApplicationButton;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_hello_android);
		Log.i(TAG, "onCreate");
		button = (Button) this.findViewById(R.id.button);
		buttonClip = (Button) this.findViewById(R.id.buttonClip);
		buttonApplicationButton = (Button)this.findViewById(R.id.buttonApplicationData);
		button.setOnClickListener(new View.OnClickListener() {

			public void onClick(View v) {
				Intent intent = new Intent(HelloAndroid.this,
						OtherActivity.class);
				intent.putExtra("name", "duoduo");
				intent.putExtra("age", 22);
				startActivity(intent);
			}
		});
		buttonClip.setOnClickListener(new View.OnClickListener() {

			@SuppressLint("NewApi")
			public void onClick(View v) {
				ClipboardManager clipboardManager = (ClipboardManager) getSystemService(Context.CLIPBOARD_SERVICE);
				MyData data = new MyData(21, "duoduo");
				String base64String = "";
				ByteArrayOutputStream byteArrayOutputStream = new ByteArrayOutputStream();
				ObjectOutputStream objectOutputStream;
				try {
					objectOutputStream = new ObjectOutputStream(
							byteArrayOutputStream);
					objectOutputStream.writeObject(data);
					base64String = Base64.encodeToString(
							byteArrayOutputStream.toByteArray(), Base64.DEFAULT);
					objectOutputStream.close();
				} catch (IOException e) {
					// TODO Auto-generated catch block
					e.printStackTrace();
				}
				clipboardManager.setText(base64String);
				Intent intent = new Intent(HelloAndroid.this,
						ClipboardAcitivity.class);
				startActivity(intent);
			}
		});
		buttonApplicationButton.setOnClickListener(new View.OnClickListener() {
			
			public void onClick(View v) {
				ApplicationData applicationData = (ApplicationData)getApplication();
				applicationData.setName("修改之后的名字-》咄咄");
				Intent intent = new Intent(HelloAndroid.this,
						ApplicationDataActivity.class);
				startActivity(intent);
			}
		});
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.activity_hello_android, menu);
		return true;
	}

	@Override
	protected void onStart() {
		super.onStart();
		Log.i(TAG, "onStart");
	}

	@Override
	protected void onPause() {
		super.onPause();
		Log.i(TAG, "onPause");
	}

	@Override
	protected void onRestart() {
		super.onRestart();
		Log.i(TAG, "onRestart");
	}

	@Override
	protected void onResume() {
		super.onResume();
		Log.i(TAG, "onResume");
	}

	@Override
	protected void onStop() {
		super.onStop();
		Log.i(TAG, "onStop");
	}

	@Override
	protected void onDestroy() {
		super.onDestroy();
		Log.i(TAG, "onDestroy");
	}
}
