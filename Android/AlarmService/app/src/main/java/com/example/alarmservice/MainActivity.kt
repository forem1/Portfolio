package com.example.alarmservice

import android.app.AlarmManager
import android.app.PendingIntent
import android.content.Context
import android.content.Intent
import android.os.Build
import android.os.Bundle
import android.widget.TimePicker.OnTimeChangedListener
import android.widget.Toast
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_main.*
import java.text.SimpleDateFormat
import java.util.*


class MainActivity : AppCompatActivity() {

    var minutes = 0
    var hours = 0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val now = Calendar.getInstance()
        timePicker.setCurrentHour(now.get(Calendar.HOUR_OF_DAY));
        timePicker.setCurrentMinute(now.get(Calendar.MINUTE));
        timePicker.setIs24HourView(true)

        timePicker.setOnTimeChangedListener(OnTimeChangedListener { view, hourOfDay, minute ->
            hours = hourOfDay - now.get(Calendar.HOUR_OF_DAY)
            minutes = minute - now.get(Calendar.MINUTE)
        })

        btn_timer.setOnClickListener {
            setAlarm(5)
        }
    }

    private fun setAlarm(number: Int) {
        val alarmManager = getSystemService(Context.ALARM_SERVICE) as AlarmManager

        val now = Calendar.getInstance()
        val calendarList = ArrayList<Calendar>()
            for (i in 1..number) calendarList.add(now)
            for (calendar in calendarList) {
                calendar.add(Calendar.MINUTE, hours*60+minutes)
                val requestCode = Random().nextInt()
                val intent = Intent(this, MyAlarmReciever::class.java)
                intent.putExtra("REQUEST_CODE", requestCode)
                intent.addFlags(Intent.FLAG_INCLUDE_STOPPED_PACKAGES)
                intent.addFlags(Intent.FLAG_RECEIVER_FOREGROUND)
                val pendingIntent = PendingIntent.getBroadcast(this, requestCode, intent, 0)

                if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
                    alarmManager.setExactAndAllowWhileIdle(
                        AlarmManager.RTC_WAKEUP,
                        calendar.timeInMillis,
                        pendingIntent
                    )
                } else {
                    alarmManager.setExact(
                        AlarmManager.RTC_WAKEUP,
                        calendar.timeInMillis,
                        pendingIntent
                    )
                }

                txt_timer.text = "Таймер сработает через: " + hours +"часов и "+ minutes + "минут"
                Toast.makeText(this, "Включено", Toast.LENGTH_LONG).show()
            }
        }
}
