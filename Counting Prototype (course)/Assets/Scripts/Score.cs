using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private int points;

    private void Start()
    {
        points = 0;
    }
    public int Points
    {
        get => points;
        set => points = value;
    }
}
