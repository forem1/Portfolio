package com.example.testpair

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import android.widget.TextView
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {

    var counts = 0;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

            //button.setOnClickListener {
            counts++

            Log.i("TagINFO", "+1")

            //textView.text = counts.toString()
        }
    }

    /*override fun onRestoreInstanceState(savedInstanceState: Bundle) {
        super.onRestoreInstanceState(savedInstanceState)
        counts = savedInstanceState.getInt("numberCount")
        textView.text = counts.toString()
    }

    override fun onSaveInstanceState(outState: Bundle) {
        super.onSaveInstanceState(outState)
        Log.i("TagINFO", "Произошел переворот экрана")
        outState.run {
            putInt("numberCount", counts)
        }*/
    //}

