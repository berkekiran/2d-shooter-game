using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{
    public Text scoreText;

    void Start()
    {
        
    }

    void Update()
    {
         scoreText.text = "Total Kills: " + ManagerScript.Instance.Score.ToString();
    }

    public void Replay(){
        SceneManager.LoadScene("Game");
    }
}
