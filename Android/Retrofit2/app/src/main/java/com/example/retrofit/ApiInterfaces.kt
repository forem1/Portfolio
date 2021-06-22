package com.example.retrofit

import com.example.retrofit.Models.UrlImageModels
import retrofit2.Call
import retrofit2.http.GET

interface ApiInterfaces {
    @GET("meow")
    fun getFiles(): Call<UrlImageModels>
}