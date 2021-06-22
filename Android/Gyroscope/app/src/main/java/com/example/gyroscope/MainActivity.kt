package com.example.gyroscope

import android.content.Context
import android.hardware.Sensor
import android.hardware.SensorEvent
import android.hardware.SensorEventListener
import android.hardware.SensorManager
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.animation.Animation
import android.view.animation.RotateAnimation
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity(), SensorEventListener {

    var manager: SensorManager? = null
    var current_degree:Int = 0
    var current_degree2:Int = 0
    var current_degree3:Int = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        manager = getSystemService(Context.SENSOR_SERVICE) as SensorManager
    }

    override fun onResume() {
        super.onResume()
        manager?.registerListener(this, manager?.getDefaultSensor(Sensor.TYPE_ORIENTATION), SensorManager.SENSOR_DELAY_GAME)
    }

    override fun onPause() {
        super.onPause()
        manager?.unregisterListener(this)
    }

    override fun onAccuracyChanged(p0: Sensor?, p1: Int) {

    }

    override fun onSensorChanged(p0: SensorEvent?) {
        val degree:Int = p0?.values?.get(0)?.toInt()!!
        val degree2:Int = p0?.values?.get(1)?.toInt()!!
        val degree3:Int = p0?.values?.get(2)?.toInt()!!
        izmer.text = degree.toString()
        izmer2.text = degree2.toString()
        izmer3.text = degree2.toString()

        val rotationAnim = RotateAnimation(current_degree.toFloat(), (-degree).toFloat(), Animation.RELATIVE_TO_SELF, 0.5f, Animation.RELATIVE_TO_SELF, 0.5f)
        rotationAnim.duration = 210
        rotationAnim.fillAfter = true
        current_degree = -degree

        val rotationAnim2 = RotateAnimation(current_degree2.toFloat(), (-degree2).toFloat(), Animation.RELATIVE_TO_SELF, 0.5f, Animation.RELATIVE_TO_SELF, 0.5f)
        rotationAnim2.duration = 210
        rotationAnim2.fillAfter = true
        current_degree2 = -degree2

        val rotationAnim3 = RotateAnimation(current_degree3.toFloat(), (-degree3).toFloat(), Animation.RELATIVE_TO_SELF, 0.5f, Animation.RELATIVE_TO_SELF, 0.5f)
        rotationAnim3.duration = 210
        rotationAnim3.fillAfter = true
        current_degree3 = -degree3
        image.startAnimation(rotationAnim)
        image2.startAnimation(rotationAnim2)
        image3.startAnimation(rotationAnim3)
    }
}
