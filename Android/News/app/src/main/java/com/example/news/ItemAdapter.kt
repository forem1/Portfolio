package com.example.news

import android.media.Image
import android.view.ContextThemeWrapper
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.ImageView
import android.widget.TextView
import androidx.recyclerview.widget.RecyclerView

class ItemAdapter (
    private val context: ContextThemeWrapper,
    private val images: List<ItemOfList>,
    val listener: (ItemOfList) -> Unit
) : RecyclerView.Adapter<ItemAdapter.ImageViewHolder>() {
    class ImageViewHolder(view: View) : RecyclerView.ViewHolder(view) {
        val imageSrc = view.findViewById<ImageView>(R.id._image)
        val title = view.findViewById<TextView>(R.id._title)

        fun bindView(image: ItemOfList, listener: (ItemOfList) -> Unit) {
            imageSrc.setImageResource(image.imageScr)
            title.text = image.imageTitle
            itemView.setOnClickListener {listener(image)}
        }
    }

    override fun onCreateViewHolder(parent: ViewGroup, viewType: Int): ImageViewHolder =
        ImageViewHolder(LayoutInflater.from(context).inflate(R.layout.item_list, parent, false))

    override fun getItemCount(): Int = images.size

    override fun onBindViewHolder(holder: ImageViewHolder, position: Int) {
        holder.bindView(images[position], listener)
    }
}