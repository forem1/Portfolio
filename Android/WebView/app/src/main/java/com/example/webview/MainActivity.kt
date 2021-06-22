package com.example.webview

import android.annotation.SuppressLint
import android.graphics.Bitmap
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.view.View
import android.webkit.WebResourceRequest
import android.webkit.WebView
import android.webkit.WebViewClient
import android.widget.ProgressBar
import kotlinx.android.synthetic.main.activity_main.*

class MainActivity : AppCompatActivity() {
    var progBar:ProgressBar? = null
    lateinit var web: WebView
    var url = "http://google.com"
    @SuppressLint("SetJavaScriptEnabled")

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)
        progBar = progressBar
        web = webView
        web.webViewClient = myWebClient()
        web.loadUrl(url)
        web.settings?.javaScriptEnabled = true
    }

    inner class myWebClient : WebViewClient() {
        override fun shouldOverrideUrlLoading(view: WebView?, url: String): Boolean {
            progBar!!.visibility = View.VISIBLE
            view!!.loadUrl(url);
            return true
        }

        override fun onPageStarted(view: WebView?, url: String?, favicon: Bitmap?) {
            progBar!!.visibility = View.VISIBLE
            super.onPageStarted(view, url, favicon)
        }

        override fun onPageFinished(view: WebView?, url: String?) {
            super.onPageFinished(view, url)
            progBar!!.visibility = View.GONE
        }
    }
}
