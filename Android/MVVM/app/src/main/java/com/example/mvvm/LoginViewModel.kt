package com.example.mvvm

import android.text.Editable
import android.text.TextWatcher
import android.view.View
import androidx.lifecycle.ViewModel

class LoginViewModel(private val listener:LoginResultCallBacks): ViewModel() {
    private val user: User
    init{
        this.user = User("","")
    }

    val emailTextWatcher: TextWatcher
    get() = object:TextWatcher {
        override fun afterTextChanged(s: Editable?) {
            user.setEmail(s.toString())
        }

        override fun beforeTextChanged(p0: CharSequence?, p1: Int, p2: Int, p3: Int) {

        }

        override fun onTextChanged(p0: CharSequence?, p1: Int, p2: Int, p3: Int) {

        }
    }

    val passwodTextWatcher: TextWatcher
        get() = object:TextWatcher {
            override fun afterTextChanged(s: Editable?) {
                user.setPassword(s.toString())
            }

            override fun beforeTextChanged(p0: CharSequence?, p1: Int, p2: Int, p3: Int) {
            }

            override fun onTextChanged(p0: CharSequence?, p1: Int, p2: Int, p3: Int) {
            }
        }

    fun onLoginClicked(v:View){
        if(user.isDataValid)
            listener.onSuccess("Авторизация прошла успешно")
        else
            listener.onError("Ошибка")
    }
}