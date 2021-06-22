package com.example.mvvm

import android.database.Cursor
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.ArrayAdapter
import androidx.appcompat.app.AlertDialog
import kotlinx.android.synthetic.main.activity_data.*

class DataActivity : AppCompatActivity() {

    var usersDB: DataBaseHelper?=null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_data)

        usersDB = DataBaseHelper(this@DataActivity)

        val data :Cursor? = usersDB!!.showData()
        if(data!!.getCount()!=0) {
            var users = emptyArray<String>()
            val i:Int = 0
            while (data.moveToNext()){
                users+= data.getString(0)+" "+data.getString(1)+" "+data.getString(2)
            }
            ListData.adapter = ArrayAdapter(this, android.R.layout.simple_list_item_1, users)
        }else{
            display("Error", "Нет данных")
        }
    }
    fun display(title:String?, message: String?)
    {
        val builder: AlertDialog.Builder = AlertDialog.Builder(this)
        builder.setCancelable(true)
        builder.setTitle(title)
        builder.setMessage(message)
        builder.show()
    }
}