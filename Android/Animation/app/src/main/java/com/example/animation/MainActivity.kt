package com.example.animation

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        frameAnimBtn.setOnClickListener {
                startActivity(Intent(this, FrameAnim::class.java))
        }
        tweenAnimBtn.setOnClickListener {
            startActivity(Intent(this, TweenAnim::class.java))
        }
    }
}
