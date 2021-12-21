from django.urls import path, include
from . import views

urlpatterns = [
    path('', views.index, name='index_url'),
    path('<int:post_id>/', views.post_detail, name='post_detail_url'),
    path('tags/', views.tags, name='tags_url'),
    path('accounts/', include('django_registration.backends.one_step.urls')),
    path('accounts/', include('django.contrib.auth.urls'))
]