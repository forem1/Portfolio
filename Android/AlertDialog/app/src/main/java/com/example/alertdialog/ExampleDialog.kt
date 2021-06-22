package com.example.alertdialog

import android.app.AlertDialog
import android.app.Dialog
import android.content.Context
import android.content.DialogInterface
import android.os.Bundle
import android.view.View
import android.widget.EditText
import androidx.appcompat.app.AppCompatDialog
import androidx.appcompat.app.AppCompatDialogFragment
import java.lang.ClassCastException

class ExampleDialog : AppCompatDialogFragment(){
    private var editTextAddress: EditText? = null
    private var editTextCity: EditText? = null
    private var editTextComment: EditText? = null
    private var listener: ExampleDialogListener? = null

    fun OnCreateDialog(savedInstanceState: Bundle?): Dialog {
       val builder = AlertDialog.Builder(activity)
        val inflater = activity!!.layoutInflater
        val view: View = inflater.inflate(R.layout.alert, null)

        builder.setView(view)
            .setTitle("")
            .setNegativeButton(""){DialogInterface, i ->  }
            .setPositiveButton(""){DialogInterface, i ->
                val address = editTextAddress!!.text.toString()
                val city = editTextCity!!.text.toString()
                val comment = editTextComment!!.text.toString()
                listener!!.applyTexts(address, city, comment)
            }

        editTextAddress = view.findViewById(R.id.edtAddress)
        editTextCity = view.findViewById(R.id.edtCity)
        editTextComment = view.findViewById(R.id.edtComment)
        return builder.create()
    }

    override fun onAttach(context: Context) {
        super.onAttach(context)
        listener = try {
            context as ExampleDialogListener
        } catch (e: ClassCastException) {
            throw ClassCastException(context.toString() + "must implement")
        }
    }

    interface ExampleDialogListener {
        fun applyTexts(address: String?, city: String?, comment: String?)
    }
}