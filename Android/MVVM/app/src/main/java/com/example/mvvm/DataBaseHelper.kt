package com.example.mvvm

import android.content.ContentValues
import android.content.Context
import android.database.Cursor
import android.database.sqlite.SQLiteDatabase
import android.database.sqlite.SQLiteOpenHelper

class DataBaseHelper(context: Context):SQLiteOpenHelper(context,"user.db",null,1) {

    val TABLE_NAME= "user_table"
    val COL2 = "LOGIN"
    val COL3 ="PASSWORD"
    private val DROP_USER_TABLE = "DROP TABLE IF EXISTS $TABLE_NAME"

    override fun onCreate(db: SQLiteDatabase) {
        val createTable =
            "CREATE TABLE "+TABLE_NAME+" (ID INTEGER PRIMARY KEY AUTOINCREMENT, "+
                " LOGIN TEXT, PASSWORD TEXT)"
        db.execSQL(createTable)
    }

    override fun onUpgrade(db: SQLiteDatabase, oldVersion: Int, newVersion: Int) {
        db.execSQL(DROP_USER_TABLE)
        onCreate(db)
    }

    fun addData(login: String?, password:String?):Boolean{
        val db = this.writableDatabase
        val contentValues = ContentValues()
        contentValues.put(COL2, login)
        contentValues.put(COL3, password)
        val result = db.insert(TABLE_NAME, null, contentValues)

        return result!=-1L
    }

    fun showData(): Cursor?{
        val db = this.writableDatabase
        return  db.rawQuery("SELECT * FROM $TABLE_NAME",null)
    }
}