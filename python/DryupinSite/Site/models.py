from django import db
from django.db import models

class Tag(models.Model):
    name= models.TextField(max_length=50, verbose_name='Тег')

    def __str__(self):
        return self.name

    class Meta:
        db_table = 'tag'
        verbose_name = 'Тег'
        verbose_name_plural = 'Теги'

class Post(models.Model):
    title = models.CharField(max_length=150, verbose_name='Название статьи')
    text = models.TextField(max_length=500, verbose_name='Текст статьи')
    author = models.CharField(max_length=50, verbose_name='Автор')
    pub_date = models.DateTimeField(verbose_name='Дата публикации', auto_now=True)
    fk_tag = models.ManyToManyField(Tag, verbose_name='Теги')

    def __str__(self):
        return self.title

    class Meta:
        verbose_name = 'Статья'
        verbose_name_plural = 'Статьи'

class Comment(models.Model):
    text = models.TextField(max_length=500, verbose_name='Текст комментария')
    author = models.CharField(max_length=50, verbose_name='Автор')
    pub_date = models.DateTimeField(verbose_name='Дата публикации', auto_now=True)
    fk_post = models.ForeignKey(to=Post, on_delete=models.CASCADE)

    def __str__(self):
        return '{} - {}'.format(self.fk_post, self.author)

    class Meta:
        db_table = 'comment'
        verbose_name = 'Комментарий'
        verbose_name_plural = 'Комментарии'