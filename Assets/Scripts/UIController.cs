﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Text scoreText;
    public Text levelText;
    private int levelCount = 0;
    public static bool levelUp = false;

    void Start()
    {

    }

    void Update()
    {
        scoreText.text = "Total Kills: " + ManagerScript.Instance.Score.ToString();
        levelText.text = ManagerScript.Instance.Level.ToString();

        if(ManagerScript.Instance.Score >= levelCount && levelUp) {
            ManagerScript.Instance.Level++;
            levelCount += 5;
            levelUp = false;
        }
    }
}
