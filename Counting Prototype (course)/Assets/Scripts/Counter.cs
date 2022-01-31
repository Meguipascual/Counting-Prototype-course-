using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{

    [SerializeField] private Text CounterText;
    private Score score;
    private int Count;


    private void Start()
    {
        //Count = 0;
        score = FindObjectOfType<Score>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        Count = score.Points;
        switch(this.tag)
        {
            case "1": Count += 1; break;
            case "10": Count += 10; break;
            case "100": Count += 100; break;
            case "1000": Count += 1000; break;
            case "-200": Count -= 200; break;
            default: Debug.Log(this.tag + " is the number so, Someting went wrong."); break;

        }
        score.Points = Count;
        CounterText.text = "Points : " + Count;
    }
}
