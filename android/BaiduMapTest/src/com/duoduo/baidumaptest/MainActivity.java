package com.duoduo.baidumaptest;

import com.baidu.mapapi.BMapManager;
import com.baidu.mapapi.GeoPoint;
import com.baidu.mapapi.MKGeneralListener;
import com.baidu.mapapi.MapActivity;
import com.baidu.mapapi.MapController;
import com.baidu.mapapi.MapView;

import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;
import android.widget.Toast;

public class MainActivity extends MapActivity {

	private MapView mapView;
	private BMapManager bMapManager;
	private String keyString = "36570BFDE375F1440C00A09E40F23315044E3599";

	private MapController mapController;

	@Override
	public void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.activity_main);
		mapView = (MapView) this.findViewById(R.id.bmapView);
		bMapManager = new BMapManager(MainActivity.this);
		bMapManager.init(keyString, new MKGeneralListener() {

			public void onGetPermissionState(int state) {

				if (state == 300) {
					Toast.makeText(MainActivity.this, "输入的key有误！请核实", 1).show();

				}
			}

			public void onGetNetworkState(int arg0) {
				// TODO Auto-generated method stub

			}
		});
		initMapActivity(bMapManager);
		mapView.setBuiltInZoomControls(true);
		mapController = mapView.getController();
		GeoPoint geoPoint = new GeoPoint((int) (39.915 * 1E6),
				(int) (116.404 * 1E6));

		mapController.setCenter(geoPoint);
		mapController.setZoom(12);
	}

	@Override
	protected void onDestroy() {
		if (bMapManager != null) {
			bMapManager.destroy();
			bMapManager = null;
		}
		super.onDestroy();
	}

	@Override
	protected void onResume() {
		if (bMapManager != null) {
			bMapManager.start();
		}
		super.onResume();
	}
	@Override
	protected void onPause() {
		if (bMapManager != null) {
			bMapManager.stop();
		}
		super.onPause();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		getMenuInflater().inflate(R.menu.activity_main, menu);
		return true;
	}

	@Override
	protected boolean isRouteDisplayed() {
		// TODO Auto-generated method stub
		return false;
	}
}
