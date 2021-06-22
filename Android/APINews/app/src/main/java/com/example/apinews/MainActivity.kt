package com.example.apinews

import android.content.Intent
import android.os.Bundle
import androidx.appcompat.app.AppCompatActivity
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView
import kotlinx.android.synthetic.main.activity_main.*
import okhttp3.OkHttpClient
import okhttp3.Request
import okhttp3.Response
import org.json.JSONArray
import org.json.JSONObject


class MainActivity : AppCompatActivity() {
    var imageList = listOf<ItemOfList>(
            //ItemOfList(
            //        R.drawable.ic_launcher_background,
             //       "Стримы по программированию на Twitch: что на них происходит и зачем их смотреть?",
             //       "В апреле 2020 Twitch побил все рекорды — его смотрели 4,5 миллиона человек одновременно. Конечно, львиная доля просмотров приходится на игры или болталки, но есть на Твиче небольшой уголок, где собираются программисты и стримят процесс разработки либо наблюдают за ним."
            //))
    )
    val URL = "https://newsapi.org/v2/top-headlines?country=ru&apiKey=ea17b7b200244183a644f0a940a62a91";
    var okHttpClient: OkHttpClient = OkHttpClient()

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        thread.start()


        val recyclerView = findViewById<RecyclerView>(R.id._imageRecyclerView)
        recyclerView.layoutManager = LinearLayoutManager(this)
        recyclerView.setHasFixedSize(true)
        recyclerView.adapter = ItemAdapter(this, imageList) {
            val intent = Intent(this, DetailActivity::class.java)
            intent.putExtra("OBJECT_INTENT", it)
            startActivity(intent)
        }
    }

    var thread = Thread(Runnable {
        try {
            val jObject = JSONObject(okHttpClient.newCall(Request.Builder().url(URL).build()).execute()!!.body()!!.string());

            //if (!jObject.isNull("articles")) {
                val submissions: JSONArray = jObject.getJSONArray("articles")
                for (i in 0 until submissions.length()) {
                    val submission = submissions.getJSONObject(i)
                    val NewsTitle = submission.getString("title")
                    val NewsDescription = submission.getString("description")
                    val NewsImg = submission.getString("urlToImage")


                    imageList += listOf<ItemOfList>(
                            ItemOfList(
                                    R.drawable.ic_launcher_background,
                                    NewsTitle,
                                    NewsDescription
                            ))
                }
            //}
        } catch (e: Exception) {
            e.printStackTrace()
        }
    })
}

