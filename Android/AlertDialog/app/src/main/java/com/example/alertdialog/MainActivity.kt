package com.example.alertdialog

import android.graphics.Color
import android.os.Bundle
import android.view.View
import android.widget.LinearLayout
import android.widget.Toast
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import androidx.constraintlayout.widget.ConstraintLayout


class MainActivity : AppCompatActivity(), ExampleDialog.ExampleDialogListener {

    private val mBackground: ConstraintLayout? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
    }

    fun showDialog(view: View) {
        val builder = AlertDialog.Builder(this@MainActivity)
        builder.setTitle("App background color")

        builder.setMessage("Вы хотите сменить фон на зеленый7")

        builder.setPositiveButton("Да") {dialog, which ->
            Toast.makeText(applicationContext, "Фон именился на красный. Зеленый - фу", Toast.LENGTH_SHORT).show()
            mBackground?.setBackgroundColor(Color.GREEN)
        }

        builder.setNegativeButton("Нет") {dialog, which ->
            Toast.makeText(applicationContext, "Правильно!!", Toast.LENGTH_SHORT).show()
        }

        builder.setNeutralButton("Отмена") {dialog, which ->
            Toast.makeText(applicationContext, "Ну и ладно!!", Toast.LENGTH_SHORT).show()
        }

        val dialog: AlertDialog = builder.create()
        dialog.show()
    }

    fun showDialogRadioButtons(view: View) {
        val namesArray = arrayOf("Первый", "Второй", "Третий")

        val builder = AlertDialog.Builder(this@MainActivity)
        builder.setTitle("Выберите поле из списка")
            .setSingleChoiceItems(namesArray, -1) {
                dialog, item ->
                Toast.makeText(this@MainActivity, "Вы выбрали "+namesArray[item], Toast.LENGTH_SHORT).show()
            }
            .setPositiveButton("OK") {dialog, id ->  }
            .setNegativeButton("Отмена"){dialog, id ->  }

        val dialog: AlertDialog = builder.create()
        dialog.show()
    }

    fun showAlertTextFields(view: View) {
        val exampleDialog = ExampleDialog()
        exampleDialog.show(supportFragmentManager, "example dialog")
    }

    override fun applyTexts(address: String?, city: String?, comment: String?) {
        Toast.makeText(this@MainActivity, "Вы ввели $address, $city, $comment", Toast.LENGTH_SHORT).show()
    }
}
