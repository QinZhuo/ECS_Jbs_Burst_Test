﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowInfo : MonoBehaviour {
	public float updateInterval = 0.5F;
    private double lastInterval;
    private int frames = 0;
    private float fps;
    void Start()
    {
        lastInterval = Time.realtimeSinceStartup;
        frames = 0;
    }
    void OnGUI()
    {
        GUIStyle style=new GUIStyle();
        style.fontSize=40;
        GUILayout.Label("FPS: " + fps.ToString("f2"),style);
    }
    void Update()
    {
        ++frames;
        float timeNow = Time.realtimeSinceStartup;
        if (timeNow > lastInterval + updateInterval)
        {
            fps = (float)(frames / (timeNow - lastInterval));
            frames = 0;
            lastInterval = timeNow;
        }
    }
}
