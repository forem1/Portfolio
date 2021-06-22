package com.dryupin.widgets

import android.app.PendingIntent
import android.appwidget.AppWidgetManager
import android.appwidget.AppWidgetProvider
import android.content.Context
import android.content.Intent
import android.graphics.Camera
import android.util.Log
import android.widget.Button
import android.widget.RemoteViews
import java.security.Policy

/**
 * Implementation of App Widget functionality.
 */
class NewAppWidget : AppWidgetProvider() {
    override fun onUpdate(
        context: Context,
        appWidgetManager: AppWidgetManager,
        appWidgetIds: IntArray
    ) {
        // There may be multiple widgets active, so update all of them
        for (appWidgetId in appWidgetIds) {
            updateAppWidget(context, appWidgetManager, appWidgetId)
        }

        appWidgetIds.forEach { appWidgetId ->
            val pendingIntent: PendingIntent = Intent(context, NewAppWidget::class.java)
                .let { intent -> PendingIntent.getActivity(context, 0, intent, 0) }
            Log.i("asd", "hoor")

            val views: RemoteViews = RemoteViews(context.packageName, R.layout.new_app_widget).apply {
                setOnClickPendingIntent(R.id.button, pendingIntent)
            }

            appWidgetManager.updateAppWidget(appWidgetId, views)
        }
    }

    override fun onEnabled(context: Context) {
        // Enter relevant functionality for when the first widget is created
    }

    override fun onDisabled(context: Context) {
        // Enter relevant functionality for when the last widget is disabled
    }
}

internal fun updateAppWidget(
    context: Context,
    appWidgetManager: AppWidgetManager,
    appWidgetId: Int
) {
    //val widgetText = context.getString(R.string.appwidget_text)
    // Construct the RemoteViews object
    val views = RemoteViews(context.packageName, R.layout.new_app_widget)
        //views.setTextViewText(R.id.appwidget_text, widgetText)
    //views.setOnClickPendingIntent(R.id.button, onOff)
    // Instruct the widget manager to update the widget
    appWidgetManager.updateAppWidget(appWidgetId, views)
}

fun onOff() {

}
