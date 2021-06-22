package com.example.firebase

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import com.google.firebase.auth.FirebaseAuth
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {

    private lateinit var auth: FirebaseAuth

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        auth = FirebaseAuth.getInstance()

        btn_signup.setOnClickListener {
            signUpUser()
        }

        btn_login.setOnClickListener {
            signInUser()
        }
    }

    private fun signInUser() {
        auth.signInWithEmailAndPassword(edt_login.text.toString(), edt_password.text.toString()).addOnCompleteListener(this) { task ->
            if(task.isSuccessful) {
                Toast.makeText(baseContext, "Авторизовались", Toast.LENGTH_SHORT).show()
            }
            else {
                Toast.makeText(baseContext, "Ошибка", Toast.LENGTH_SHORT).show()
            }
        }
    }

    private fun signUpUser() {
        auth.createUserWithEmailAndPassword(edt_login.text.toString(), edt_password.text.toString()).addOnCompleteListener(this) { task ->
            if(task.isSuccessful) {
                Toast.makeText(baseContext, "Авторизовались", Toast.LENGTH_SHORT).show()
            }
            else {
                Toast.makeText(baseContext, task.exception.toString(), Toast.LENGTH_SHORT).show()
            }
        }
    }
}
