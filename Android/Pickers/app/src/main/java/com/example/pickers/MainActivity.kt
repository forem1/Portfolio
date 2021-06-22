package com.example.pickers

import android.app.DatePickerDialog
import android.app.TimePickerDialog
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.format.DateUtils
import android.view.View
import android.widget.TextView
import java.util.*

class MainActivity : AppCompatActivity() {

    var currentDateTime: TextView? = null
    private var dateAndTime = Calendar.getInstance()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        currentDateTime = findViewById<View>(R.id.currentDateTime) as TextView
        setInitialDateTime()
    }

    fun setDate(v: View?) {
        DatePickerDialog(this@MainActivity, date, dateAndTime[Calendar.YEAR], dateAndTime[Calendar.MONTH], dateAndTime[Calendar.DAY_OF_MONTH]).show()
    }

    fun setTime(v: View?) {
        TimePickerDialog(this@MainActivity, time, dateAndTime[Calendar.HOUR_OF_DAY], dateAndTime[Calendar.MINUTE], true).show()
    }

    private fun setInitialDateTime() {
        currentDateTime!!.text = DateUtils.formatDateTime(this, dateAndTime.timeInMillis, DateUtils.FORMAT_SHOW_DATE or DateUtils.FORMAT_SHOW_YEAR or DateUtils.FORMAT_SHOW_TIME)
    }

    var time = TimePickerDialog.OnTimeSetListener { view, hourOfDay, minute ->
        dateAndTime[Calendar.HOUR_OF_DAY] = hourOfDay
        dateAndTime[Calendar.MINUTE] = minute
        setInitialDateTime()
    }

    var date = DatePickerDialog.OnDateSetListener { view, year, monthOfYear, dayOfMonth ->
        dateAndTime[Calendar.YEAR] = year
        dateAndTime[Calendar.MONTH] = monthOfYear
        dateAndTime[Calendar.DAY_OF_MONTH] = dayOfMonth
        setInitialDateTime()
    }
}
