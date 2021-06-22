package com.example.unittest

import android.app.DownloadManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import okhttp3.*
import org.json.JSONObject
import java.io.IOException

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

    }
}
