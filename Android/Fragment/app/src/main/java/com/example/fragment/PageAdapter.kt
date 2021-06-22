package com.example.fragment

import androidx.fragment.app.Fragment
import androidx.fragment.app.FragmentManager
import androidx.fragment.app.FragmentPagerAdapter

class PageAdapter(manager: FragmentManager): (manager) {
private val fragmentList : MutableList<Fragment> = ArrayList()
    private val titleList : MutableList<String> = ArrayList()
    fun getItem(position: Int): Fragment {
        return fragmentList[position]
    }

     fun getCount(): Int {
        return fragmentList.size
    }

    fun addFragment(fragment: Fragment, title:String){
        fragmentList.add(fragment)
        titleList.add(title)
    }

     fun getPageTitle(position: Int): CharSequence? {
        return titleList[position]
    }
}

interface manager {

}
