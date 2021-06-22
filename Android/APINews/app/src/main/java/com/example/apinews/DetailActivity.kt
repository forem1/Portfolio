package com.example.apinews

import android.os.Bundle
import android.os.PersistableBundle
import android.widget.ImageView
import android.widget.TextView
import androidx.appcompat.app.AppCompatActivity
import org.w3c.dom.Text

class DetailActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detail)

        val item = intent.getParcelableExtra<ItemOfList>("OBJECT_INTENT")

        val imgSrc = findViewById<ImageView>(R.id._imageDetail)
        val imgTitle = findViewById<TextView>(R.id._imageTitle)
        val imgDesc = findViewById<TextView>(R.id._imageDesc)

        imgSrc.setImageResource(item.imageScr)
        imgTitle.text = item.imageTitle
        imgDesc.text = item.imageDesc
    }
}