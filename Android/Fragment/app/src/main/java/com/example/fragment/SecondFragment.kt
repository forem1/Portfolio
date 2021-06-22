package com.example.fragment

import android.os.Bundle
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import androidx.fragment.app.Fragment
import kotlinx.android.synthetic.main.secondfragment.*

class SecondFragment : Fragment() {

    override fun onCreateView(
        inflater: LayoutInflater,
        container: ViewGroup?,
        savedInstanceState: Bundle?
    ): View? {
        return inflater.inflate(R.layout.secondfragment, container, false)
    }

    override fun onViewCreated(view: View, savedInstanceState: Bundle?) {
        super.onViewCreated(view, savedInstanceState)

        btnMessage.setOnClickListener {
            val bundle = Bundle()
            bundle.putString("message", edtMessage.text.toString())
            val thirdFragment = ThirdFragment()
            thirdFragment.arguments = bundle
            fragmentManager!!.beginTransaction().replace(
                R.id.frame.thirdFragment).addToBackStack(null).commit()
        }
    }
}