package com.example.helloandroid;

import java.io.ByteArrayInputStream;
import java.io.ObjectInputStream;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.os.Bundle;
import android.text.ClipboardManager;
import android.util.Base64;
import android.widget.TextView;

public class ClipboardAcitivity extends Activity {
	private TextView textView;

	public ClipboardAcitivity() {
		// TODO Auto-generated constructor stub
	}

	@SuppressLint("NewApi")
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.other);
		textView = (TextView) this.findViewById(R.id.msg);
		ClipboardManager clipboardManager = (ClipboardManager) getSystemService(Context.CLIPBOARD_SERVICE);
		String msgString = clipboardManager.getText().toString();
		byte[] base64_byte = Base64.decode(msgString, Base64.DEFAULT);
		ByteArrayInputStream byteArrayInputStream = new ByteArrayInputStream(
				base64_byte);
		try {
			ObjectInputStream objectInputStream = new ObjectInputStream(
					byteArrayInputStream);
			MyData myData = (MyData) objectInputStream.readObject();
			textView.setText(myData.toString());

		} catch (Exception e) {
		}

	}

}
