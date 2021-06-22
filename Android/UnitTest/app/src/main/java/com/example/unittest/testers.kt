package com.example.unittest

import okhttp3.*

class testers {
    private val okHttpClient = OkHttpClient.Builder().build()
    fun req(url: String):Response {
        return okHttpClient.newCall(Request.Builder().url(url).build()).execute()
    }
}