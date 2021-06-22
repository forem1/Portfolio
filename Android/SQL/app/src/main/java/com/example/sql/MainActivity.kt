package com.example.sql

import android.database.Cursor
import android.icu.text.CaseMap
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import kotlinx.android.synthetic.main.activity_main.*
import java.lang.StringBuilder

class MainActivity : AppCompatActivity() {
    var peopleDB: DatabaseHelper? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        peopleDB = DatabaseHelper(this@MainActivity)

        btnAdd.setOnClickListener {
            addUser()
        }

        btnShow.setOnClickListener {
            showUsers()
        }

        deleteBtn.setOnClickListener {
            deleteUser()
        }

        updateBtn.setOnClickListener {
            updateUser()
        }
    }

    private fun addUser() {
        val name: String = edtName.text.toString()
        val email: String = edtEmail.text.toString()

        val insertData: Boolean = peopleDB!!.addData(name, email)

        if(insertData) {
            Toast.makeText(this@MainActivity, "Запись добавлена", Toast.LENGTH_LONG).show()
        }
        else {
            Toast.makeText(this@MainActivity, "Ошибка", Toast.LENGTH_LONG).show()
        }
    }

    private fun showUsers() {
        val data: Cursor? = peopleDB!!.showData()

        if (data!!.getCount() == 0) {
            display("Error", "no-data")
            return
        }
        val buffer = StringBuffer()
        while (data.moveToNext()) {
            buffer.append("ID: "+data.getString(0)+"\n")
            buffer.append("name: "+data.getString(1)+"\n")
            buffer.append("email: "+data.getString(2)+"\n")

            display("все пользователи", buffer.toString())
        }
    }

    private fun deleteUser() {
        val name: String = edtName.text.toString()
        peopleDB!!.deleteData(name)
    }

    private fun updateUser() {
        val name: String = edtName.text.toString()
        val email: String = edtEmail.text.toString()
        peopleDB!!.updateData(name, email)
    }

    private fun display(title: String?, message: String?) {
        val builder: AlertDialog.Builder = AlertDialog.Builder(this)
        builder.setCancelable(true)
        builder.setTitle(title)
        builder.setMessage(message)
        builder.show()
    }
}
