package com.example.tic_tac_toe

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.core.content.ContextCompat.getSystemService
import android.icu.lang.UCharacter.GraphemeClusterBreak.T
import androidx.core.content.ContextCompat.getSystemService
import android.icu.lang.UCharacter.GraphemeClusterBreak.T
import android.widget.Button
import android.widget.PopupMenu
import kotlinx.android.synthetic.main.activity_game.*
import kotlinx.android.synthetic.main.activity_main.*
import android.widget.Toast
import androidx.core.content.ContextCompat.getSystemService
import android.icu.lang.UCharacter.GraphemeClusterBreak.T
import android.view.View
import androidx.appcompat.app.AppCompatDelegate
import androidx.core.content.ContextCompat.getSystemService
import android.icu.lang.UCharacter.GraphemeClusterBreak.T
import android.R.attr.y
import android.R.attr.x
import android.app.Activity
import android.app.AlertDialog
import android.content.Context
import android.graphics.Point
import android.view.Display
import androidx.core.app.ComponentActivity
import androidx.core.app.ComponentActivity.ExtraData
import androidx.core.content.ContextCompat.getSystemService
import android.icu.lang.UCharacter.GraphemeClusterBreak.T


class GameActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_AUTO);
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_game)
    }

    var xO = true
    var count = 0
    fun move(view: View) {
        val btns: Array<Button> = arrayOf(btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9)

        if (xO) (view as Button).text = "X"
        else (view as Button).text = "O"
        xO = !xO
        (view as Button).isEnabled = false
        matchXO()
    }

    fun matchXO() {
        count++
        if ((btn1.text == "X" && btn2.text == "X" && btn3.text == "X") || (btn4.text == "X" && btn5.text == "X" && btn6.text == "X") || (btn7.text == "X" && btn8.text == "X" && btn9.text == "X") || (btn1.text == "X" && btn4.text == "X" && btn7.text == "X") || (btn2.text == "X" && btn5.text == "X" && btn8.text == "X") || (btn3.text == "X" && btn6.text == "X" && btn9.text == "X") || (btn1.text == "X" && btn5.text == "X" && btn9.text == "X") || (btn3.text == "X" && btn5.text == "X" && btn7.text == "X")) {
            val builder = android.app.AlertDialog.Builder(this)
            builder.setTitle("Крестики победили!")
            //builder.setPositiveButton("OK", DialogInterface.OnClickListener(function = x))

            builder.setNeutralButton("Выйти") { dialog, which ->
                onBackPressed()
            }
            builder.show()
        }
        if ((btn1.text == "O" && btn2.text == "O" && btn3.text == "O") || (btn4.text == "O" && btn5.text == "O" && btn6.text == "O") || (btn7.text == "O" && btn8.text == "O" && btn9.text == "O") || (btn1.text == "O" && btn4.text == "O" && btn7.text == "O") || (btn2.text == "O" && btn5.text == "O" && btn8.text == "O") || (btn3.text == "O" && btn6.text == "O" && btn9.text == "O") || (btn1.text == "O" && btn5.text == "O" && btn9.text == "O") || (btn3.text == "O" && btn5.text == "O" && btn7.text == "O")) {
            val builder = android.app.AlertDialog.Builder(this) // сделать через побочные диагонали
            builder.setTitle("Нолики победили!")
            //builder.setPositiveButton("OK", DialogInterface.OnClickListener(function = x))

            builder.setNeutralButton("Выйти") { dialog, which ->
                onBackPressed()
            }

            builder.show()
        }
        if (count >= 9) {
            val builder = android.app.AlertDialog.Builder(this) // сделать через побочные диагонали
            builder.setTitle("Ничья!")
            //builder.setPositiveButton("OK", DialogInterface.OnClickListener(function = x))

            builder.setNeutralButton("Выйти") { dialog, which ->
                onBackPressed()
            }
            builder.show()
        }
    }

}
