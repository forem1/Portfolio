package com.example.news

import android.content.Intent
import androidx.appcompat.app.AppCompatActivity
import android.os.Bundle
import android.telecom.Call
import androidx.recyclerview.widget.LinearLayoutManager
import androidx.recyclerview.widget.RecyclerView

class MainActivity : AppCompatActivity() {

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        val imageList = listOf<ItemOfList>(
            ItemOfList(
                R.drawable.img1,
                "Стримы по программированию на Twitch: что на них происходит и зачем их смотреть?",
                "В апреле 2020 Twitch побил все рекорды — его смотрели 4,5 миллиона человек одновременно. Конечно, львиная доля просмотров приходится на игры или болталки, но есть на Твиче небольшой уголок, где собираются программисты и стримят процесс разработки либо наблюдают за ним."
            ),
            ItemOfList(
                R.drawable.img2,
                "Ломаем мозг: игровой движок для неевклидовых миров",
                "Неевклидовый мир — это мир, геометрия которого отличается от стандартной геометрии, к которой мы привыкли. Чтобы продемонстрировать все чудеса такого мира, автор не стал показывать скучные схемы, фигуры или формулы. Он создал игровой движок и пару сцен на нём.\n" +
                        "\n" +
                        "Видео на английском, но тут главное не слышать, а видеть: автор показал всё наглядно."
            ),
            ItemOfList(
                R.drawable.img3,
                "В Яндекс.Диалогах вышел большой пакет обновлений",
                "Яндекс.Диалоги — это платформа для создания чатов и автоматизированных навыков для Алисы. Навыки похожи на чат-боты для мессенджеров, только общение происходит голосом. Яндекс не только предоставляет инструменты для создания навыков, но и записывает простые уроки об их разработке.\n" +
                        "\n" +
                        "Недавно в Яндекс.Диалогах вышел большой пакет обновлений в формате Dev Preview для разработчиков голосовых приложений."
            ),
            ItemOfList(
                R.drawable.img4,
                "GitHub сделал приватные репозитории безлимитными для всех пользователей",
                "Год назад GitHub сделал приватные репозитории бесплатными для всех пользователей, но ограничил количество соавторов до трёх. Если вам нужно было больше участников для работы в одном репозитории, нужно было оплачивать подписку. Но вчера в своём блоге разработчики объявили, что ограничения на количество участников больше нет.\n" +
                        "\n" +
                        "Теперь команды любого размера могут создавать приватные репозитории и работать в них бесплатно.\n" +
                        "\n" +
                        "Кроме того, GitHub снизил цену на Team plan с 9\$ за участника в месяц до 4\$."
            )
        )

        val recyclerView = findViewById<RecyclerView>(R.id._imageRecyclerView)
            recyclerView.layoutManager = LinearLayoutManager(this)
            recyclerView.setHasFixedSize(true)
            recyclerView.adapter = ItemAdapter(this, imageList) {
                val intent = Intent(this, DetailActivity::class.java)
                intent.putExtra("OBJECT_INTENT", it)
                startActivity(intent)
        }
    }
}
