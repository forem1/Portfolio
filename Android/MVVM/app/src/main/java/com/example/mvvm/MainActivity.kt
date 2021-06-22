package com.example.mvvm

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.widget.Toast
import androidx.databinding.DataBindingUtil
import androidx.lifecycle.ViewModelProviders
import com.example.mvvm.databinding.ActivityMainBinding
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity(), LoginResultCallBacks {

    var usersDB: DataBaseHelper?=null

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val activityMainBinding = DataBindingUtil.setContentView<ActivityMainBinding>(this, R.layout.activity_main)
        activityMainBinding.viewModel = ViewModelProviders.of(this, LoginViewModelFactory(this)).get(LoginViewModel::class.java)

        usersDB = DataBaseHelper(this@MainActivity)
    }

    override fun onSuccess(message: String) {
       Toast.makeText(this, message, Toast.LENGTH_LONG).show()
      val login: String = loginET.text.toString()
        val password:String = passwordET.text.toString()

        val insertData:Boolean = usersDB!!.addData(login, password)

        if(insertData)
        {
            Toast.makeText(this, message, Toast.LENGTH_LONG).show()
            val nextIntent = Intent(this, DataActivity::class.java)
            startActivity(nextIntent)
        }
        else

        {
            Toast.makeText(this, "Что-то пошло не так", Toast.LENGTH_LONG).show()
        }
    }

    override fun onError(message: String) {
        Toast.makeText(this, message, Toast.LENGTH_LONG).show()
    }
}