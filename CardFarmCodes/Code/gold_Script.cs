using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class gold_Script : MonoBehaviour
{
    // Start is called before the first
    Text txt;
    void Start()
    {
        txt = gameObject.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void printAddedGold(int a)
    {
        txt.text = Convert.ToString(a);
    }
}
