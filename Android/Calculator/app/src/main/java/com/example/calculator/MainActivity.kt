package com.example.calculator

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.widget.Button
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {


    var stateError = true

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun changeText(view: View) {
       // val btns: Array<Button> = arrayOf(btn1, btn2, btn3, btn4, btn5, btn6, btn7, btn8, btn9, btn0, btnClear, btnEqual, btnSumm, btnMinus, btnMultiply, btnDivision, btnPi, btnSquare, btnX2, btnFactorial)

        if(stateError) {
            lbl.text = ((view as Button).text)
            stateError = false
        }
        else {
            lbl.append((view as Button).text)
        }
    }
}