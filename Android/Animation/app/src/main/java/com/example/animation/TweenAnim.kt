package com.example.animation

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.animation.AnimationUtils
import kotlinx.android.synthetic.main.activity_tween_anim.*

class TweenAnim : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_tween_anim)

        startAnimBtn.setOnClickListener {
            startAnimBtn.startAnimation(AnimationUtils.loadAnimation(this, R.anim.opacity_anim))
        }
    }
}
