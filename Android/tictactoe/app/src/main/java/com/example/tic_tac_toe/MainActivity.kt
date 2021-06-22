package com.example.tic_tac_toe

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import androidx.appcompat.app.AppCompatDelegate
import kotlinx.android.synthetic.main.activity_main.*
import kotlinx.android.synthetic.main.activity_main.view.*

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {

        //AppCompatDelegate.setDefaultNightMode(AppCompatDelegate.MODE_NIGHT_AUTO);

        var GameAll = 0;
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        Score.text = GameAll.toString();

        NewGameButton.setOnClickListener {
            GameAll++;
            Score.text = GameAll.toString();
            startActivity(Intent(this, GameActivity::class.java))
        }
    }
}
