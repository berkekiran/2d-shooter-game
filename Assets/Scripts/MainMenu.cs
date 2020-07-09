using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource buttonClick;

    void Start()
    {
   
    }

    void Update()
    {
        
    }

    public void Play(){
        buttonClick.Play();
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(buttonClick.clip.length);
        SceneManager.LoadScene("Game");
    }
}
