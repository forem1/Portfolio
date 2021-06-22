package com.example.email

import android.content.Context
import android.content.DialogInterface
import android.content.Intent
import android.os.Bundle
import android.provider.MediaStore
import android.widget.ImageView
import androidx.appcompat.app.AlertDialog
import androidx.appcompat.app.AppCompatActivity
import kotlinx.android.synthetic.main.activity_main.*


class MainActivity : AppCompatActivity() {

    private var imageView: ImageView? = null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        btnSend.setOnClickListener { sendMail() }
    }

    private fun sendMail() {
        val recipientList: String = edtTo.text.toString()
        val recipients = recipientList.split(",").toTypedArray()
        val subject: String = edtSubject.text.toString()
        val message: String = edtMessage.text.toString()

        val intent = Intent(Intent.ACTION_SEND)
        intent.putExtra(Intent.EXTRA_EMAIL, recipients)
        intent.putExtra(Intent.EXTRA_SUBJECT, subject)
        intent.putExtra(Intent.EXTRA_TEXT, message)
        intent.type = "message/rfc822"

        startActivity(Intent.createChooser(intent, "Через какого почтового клиента отправить письмо?"))
    }
}