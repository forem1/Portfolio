package com.dryupin.currentposition;

import android.content.Context
import android.content.SharedPreferences
import android.content.pm.PackageManager
import android.location.Location
import android.os.Bundle
import android.widget.Button
import android.widget.EditText
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import androidx.core.app.ActivityCompat
import com.google.android.gms.location.FusedLocationProviderClient
import com.google.android.gms.location.LocationServices
import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.MarkerOptions


class MapsActivity : AppCompatActivity(), OnMapReadyCallback {

    private lateinit var currentLocation: Location
    private lateinit var fusedLocationProviderClient: FusedLocationProviderClient
    private val permissionCode = 101
    private lateinit var mMap: GoogleMap

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_maps)
        fusedLocationProviderClient = LocationServices.getFusedLocationProviderClient(this)
        fetchLocation()
        var addBtn = findViewById<Button>(R.id.addBtn)
        addBtn.setOnClickListener{
            addMark()
        }
    }

    private fun fetchLocation() {
        if (ActivityCompat.checkSelfPermission(
                        this, android.Manifest.permission.ACCESS_FINE_LOCATION) !=
                PackageManager.PERMISSION_GRANTED && ActivityCompat.checkSelfPermission(
                        this, android.Manifest.permission.ACCESS_COARSE_LOCATION) !=
                PackageManager.PERMISSION_GRANTED) {
            ActivityCompat.requestPermissions( this,
                    arrayOf(android.Manifest.permission.ACCESS_FINE_LOCATION), permissionCode)
            return
        }
        val task = fusedLocationProviderClient.lastLocation
        task.addOnSuccessListener { location ->
            if (location != null) {
                currentLocation = location
                Toast.makeText(applicationContext, currentLocation.latitude.toString() + "" +
                        currentLocation.longitude, Toast.LENGTH_SHORT).show()
                val supportMapFragment = (supportFragmentManager.findFragmentById(R.id.map) as
                        SupportMapFragment?)!!
                supportMapFragment.getMapAsync(this)
            }
        }
    }

    override fun onMapReady(googleMap: GoogleMap) {
        mMap = googleMap

        // Add a marker in Sydney and move the camera
        var latLng = LatLng(currentLocation.latitude, currentLocation.longitude)
        var markerOptions = MarkerOptions().position(latLng).title("я тут")
        mMap.animateCamera(CameraUpdateFactory.newLatLng(latLng))
        mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng, 5f))
        mMap.addMarker(markerOptions)
        
        var lat = getPreferences(Context.MODE_PRIVATE).getString("lat", "")!!.toDouble()
        var long = getPreferences(Context.MODE_PRIVATE).getString("long", "")!!.toDouble()

        latLng = LatLng(lat, long)
        markerOptions = MarkerOptions().position(latLng).title("Новая точка")
        mMap.animateCamera(CameraUpdateFactory.newLatLng(latLng))
        mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng, 5f))
        mMap.addMarker(markerOptions)

    }

    private fun addMark() {
        var lat = findViewById<EditText>(R.id.latitudeText).text.toString().toDouble()
        var long = findViewById<EditText>(R.id.longitudeText).text.toString().toDouble()
        val latLng = LatLng(lat, long)
        val markerOptions = MarkerOptions().position(latLng).title("Новая точка")
        mMap.animateCamera(CameraUpdateFactory.newLatLng(latLng))
        mMap.animateCamera(CameraUpdateFactory.newLatLngZoom(latLng, 5f))
        mMap.addMarker(markerOptions)

        val ed = getPreferences(Context.MODE_PRIVATE).edit()
        ed.putString("lat", lat.toString())
        ed.putString("long", long.toString())
        ed.commit()
    }

    override fun onRequestPermissionsResult(requestCode: Int, permissions: Array<out String>, grantResults: IntArray) {
        when (requestCode) {
            permissionCode -> if (grantResults.isNotEmpty() && grantResults[0] ==
                    PackageManager.PERMISSION_GRANTED) {
                fetchLocation()
            }
        }
    }
}