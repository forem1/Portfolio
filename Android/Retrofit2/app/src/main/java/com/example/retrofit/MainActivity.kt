package com.example.retrofit

import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.util.Log
import com.bumptech.glide.Glide
import com.example.retrofit.Models.UrlImageModels
import kotlinx.android.synthetic.main.activity_main.*
import retrofit2.Response
import retrofit2.Retrofit
import retrofit2.converter.gson.GsonConverterFactory
import java.net.CacheResponse

class MainActivity : AppCompatActivity() {
    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        button.setOnClickListener{
            sendNetworkRequest()
        }
    }

    private fun sendNetworkRequest() {
        val builder = Retrofit.Builder().baseUrl("https://aws.random.cat/").addConverterFactory(GsonConverterFactory.create())
        val retrofit = builder.build()
        val apiInterface: ApiInterfaces = retrofit.create<ApiInterfaces>(ApiInterfaces::class.java)
        val call: retrofit2.Call<UrlImageModels> = apiInterface.getFiles()
        call.enqueue(object : retrofit2.Callback<UrlImageModels>{
            override fun onFailure(call: retrofit2.Call<UrlImageModels?>, t:Throwable){
                Log.i("Error", t.message.toString())
            }
            override fun onResponse(call: retrofit2.Call<UrlImageModels?>, response: Response<UrlImageModels>){
                Glide
                    .with(this@MainActivity)
                    .load(response.body()!!.file)
                    .into(imageView);
            }
        })
    }

}
