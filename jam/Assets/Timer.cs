﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private TMPro.TextMeshProUGUI text;

    public bool running;
    private float time;
    // Start is called before the first frame update
    void Awake()
    {
        text = GetComponent<TMPro.TextMeshProUGUI>();
        text.text = "";
        running = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(running)
        {
            time += Time.deltaTime;
            var t = TimeSpan.FromSeconds(time);
            text.text = string.Format("{0:D2}:{1:D2}", t.Minutes, t.Seconds);
        }
    }

    public void StartTimer()
    {
        running = true;
    }

    public void Reset()
    {
        running = false;
        text.text = "";
    }
}
