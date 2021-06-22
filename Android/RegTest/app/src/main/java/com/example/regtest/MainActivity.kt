package com.example.regtest

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.text.Editable
import android.text.TextWatcher
import android.util.Log
import android.view.View
import android.widget.CheckBox
import android.widget.RadioButton
import android.widget.Toast
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {

    var resultSt = 0;

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        editText.addTextChangedListener(object: TextWatcher{
            override fun beforeTextChanged(p0: CharSequence?, p1: Int, p2: Int, p3: Int) {
            }

            override fun onTextChanged(p0: CharSequence?, p1: Int, p2: Int, p3: Int) {
            }
            override fun afterTextChanged(p0: Editable?) {
                if (editText.text.toString() == "Русский" || editText.text.toString() == "русский") {
                    resultSt = resultSt+1;
                }
                ChangeResult();
            }
        })
    }

    fun onRadioButtonClicked(view: View) {
        if (view is RadioButton) {
            // Is the button now checked?
            val checked = view.isChecked

            // Check which radio button was clicked
            when (view.getId()) {
                R.id.radio_2 ->
                    if (checked) {
                        Log.i("TagINFO", "Checked")
                        resultSt = resultSt+1;
                    }
            }
        }

        ChangeResult();
    }

    fun onCheckboxClicked(view: View) {
        if (view is CheckBox) {
            val checked: Boolean = view.isChecked

            when (view.id) {
                R.id.checkBox_1 -> {
                    if (checked) {
                        resultSt++;
                        Log.i("TagINFO", "Checked1")
                    } else {
                        resultSt++;
                    }
                }
                R.id.checkBox_2 -> {
                    if (checked) {
                        resultSt = resultSt+10;
                    } else {
                        resultSt = resultSt-10;
                    }
                }
                R.id.checkBox_3 -> {
                    if (checked) {
                        resultSt++;
                        Log.i("TagINFO", "Checked3")
                    } else {
                        resultSt--;
                    }
                }
            }
        }
        ChangeResult();
    }

    fun ChangeResult() {
        Log.i("TagINFO", resultSt.toString())
        if(resultSt == 4 ) {
        resultView.text = "Вы сдали";
        }
        else {
        resultView.text = "Вы не сдали";
        }
    }

}
