using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndUIController : MonoBehaviour
{
    public Text scoreText;
    public AudioSource audioSourceGameOver;
    public AudioSource buttonClick;

    void Start()
    {
        audioSourceGameOver.Play();
    }

    void Update()
    {
         scoreText.text = "Total Kills: " + ManagerScript.Instance.Score.ToString();
    }

    public void Replay(){
        buttonClick.Play();
        StartCoroutine(Wait());
            
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(buttonClick.clip.length);
        SceneManager.LoadScene("Game");
    }
}
