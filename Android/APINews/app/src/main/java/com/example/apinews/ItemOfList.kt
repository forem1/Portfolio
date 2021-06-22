package com.example.apinews

import android.os.Parcelable
import kotlinx.android.parcel.Parcelize

@Parcelize
data class ItemOfList(
    val imageScr: Int,
    val imageTitle: String,
    val imageDesc: String
) : Parcelable