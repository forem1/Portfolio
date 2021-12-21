from django.shortcuts import render
from .models import Post, Tag

def index(request):
    posts = Post.objects.all
    return render(request, 'news/index.html', context={'posts':posts})

def post_detail(request, post_id):
    post = Post.objects.get(id=post_id)
    return render(request, 'news/post_detail.html', context={'post':post})

def tags(request):
    tags = Tag.objects.all
    return render(request, 'news/tags.html', context={'tags':tags})
